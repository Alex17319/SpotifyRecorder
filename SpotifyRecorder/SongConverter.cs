using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NAudio;
using NAudio.Wave;
using NAudio.Lame;
using System.Text.RegularExpressions;

namespace SpotifyRec
{
	public class SongConverter
	{
		public string OutputFolder { get; }
		public string TempFolder { get; }

		private Logger _logger;

		private Task _conversionTask;
		private object _lock = new object();

		public bool ConversionIsInProgress {
			get {
				lock (_lock) return TaskIsInProgress(_conversionTask);
			}
		}

		public SongConverter(string outputFolder, string tempFolder, Logger logger)
		{
			this.OutputFolder = outputFolder;
			this.TempFolder = tempFolder;
			this._logger = logger;
		}

		public void ConvertMoreAsyncIfDone()
		{
			lock (_lock)
			{
				if (TaskIsInProgress(_conversionTask)) return;

				_conversionTask = Task.Run((Action)ConvertSongs).ContinueWith(
					task => {
						if (task.Exception != null) {
							_logger?.Invoke(
								"An error occurred while converting songs in a separate thread:\r\n" + task.Exception,
								LogType.Error
							);
						}
					}
				);
			}
		}

		private void ConvertSongs()
		{
			const int bufferSize = 256;
			byte[] buffer = new byte[bufferSize];

			foreach (var (songPath, songFullName) in GetSongFileNames().Select(x => ParseSongFileName(x)))
			{
				var spotifySongInfo = new SpotifySongInfo(songFullName);

				var reader = new WaveFileReader(songPath);
				var writer = new LameMP3FileWriter(
					Path.Combine(this.OutputFolder, songFullName) + ".mp3",
					reader.WaveFormat,
					LAMEPreset.STANDARD,
					new ID3TagData() {
						Artist = spotifySongInfo.Artist,
						Title = spotifySongInfo.SongName,
					}
				);

				while (reader.Position < reader.Length)
				{
					int bytesRead = reader.Read(buffer, 0, buffer.Length);
					writer.Write(buffer, 0, bytesRead);
				}

				File.Move(songPath, Path.ChangeExtension(songPath, ".wav-converted"));
				//Don't delete yet as it's easier to control later, and this won't be reached if there was an error
				//Rename the file so that it won't be converted again
			}
		}

		private IEnumerable<string> GetSongFileNames()
		{
			var fileFilter = new Regex(@"G#\d+-S#\d+ = .* - .*\.wav");

			return Directory.EnumerateFiles(this.TempFolder).Where(fName => fileFilter.IsMatch(fName));
		}

		private (string songPath, string songFullName) ParseSongFileName(string fileName)
		{
			return (
				songPath: this.TempFolder + fileName,
				songFullName: Path.GetFileNameWithoutExtension(fileName.Substring(fileName.IndexOf(" = ") + 3))
			);
		}

		private static bool TaskIsInProgress(Task task)
		{
			return task != null && !task.IsCanceled && !task.IsCompleted && !task.IsFaulted;
		}
	}
}
