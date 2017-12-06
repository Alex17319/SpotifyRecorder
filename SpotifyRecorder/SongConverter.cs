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
using NAudio.Vorbis;
using NAudio.Flac;
using SpotifyRec.SongEncoding;

namespace SpotifyRec
{
	public class SongConverter
	{
		public string OutputFolder { get; }
		public string TempFolder { get; }
		public ISongEncoder SongEncoder { get; }

		private Logger _logger;

		private Task _conversionTask;
		private object _lock = new object();

		public bool ConversionIsInProgress {
			get {
				lock (_lock) return TaskIsInProgress(_conversionTask);
			}
		}

		public SongConverter(string outputFolder, string tempFolder, ISongEncoder songEncoder, Logger logger)
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
				(var artist, var songName) = SpotifySongInfo.ParseWindowTitle(songFullName);

				var destPath = Path.Combine(this.OutputFolder, songFullName) + SongEncoder.Extension;

				using (var source = File.OpenRead(songPath))
				{
					SongEncoder.Encode(
						source,
						destPath,
						new SongTags(
							title: artist,
							artist: songName
						),
						buffer
					);
				}

				File.Move(songPath, Path.ChangeExtension(songPath, ".wav-converted"));
				//Don't delete yet as it's easier to control later, and this won't be reached if there was an error
				//Rename the file so that it won't be converted again
			}
		}

		private IEnumerable<string> GetSongFileNames()
		{
			var fileFilter = new Regex($@"G#\d+-S#\d+ = .*{SpotifySongInfo.ArtistAndNameSeparator}.*\.wav");

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
