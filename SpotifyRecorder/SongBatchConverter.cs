using SpotifyRec.SongEncoding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifyRec
{
	/// <summary>
	/// Converts a single batch of songs to the output format.
	/// The output and temp paths remain fixed during this operation
	/// </summary>
	public class SongBatchConverter
	{
		public IEnumerable<RecordedSong> Songs { get; }
		public string OutputFolder { get; }
		public ISongEncoder SongEncoder { get; }
		
		private Logger _logger;
		
		private Task _conversionTask;
		private object _lock = new object();

		public bool InProgress {
			get { lock (_lock) return TaskIsInProgress(_conversionTask); }
		}
		public bool Completed { get; private set; }

		public SongBatchConverter(IEnumerable<RecordedSong> songs, string outputFolder, ISongEncoder songEncoder, Logger logger)
		{
			this.Songs = songs;
			this.OutputFolder = outputFolder;
			this.SongEncoder = songEncoder;
			this._logger = logger;
		}

		/// <summary>
		/// Does nothing if the conversion is completed or in progress
		/// </summary>
		public void ConvertSongAsync()
		{
			lock (_lock)
			{
				if (this.Completed) return;
				if (this.InProgress) return;

				_conversionTask = Task.Run(
					() => {
						try {
							ConvertSongs();
						} catch (Exception ex) {
							_logger?.Invoke(
								"An error occurred while converting songs in a separate thread:" + Environment.NewLine + ex,
								LogType.Error
							);
						}
					}
				);
			}

			//	_logger?.Invoke(
			//		"An error occurred while converting the song \"" + Song.SongInfo.SongName + "\" "
			//		+ "by \"" + Song.SongInfo.Artist + "\" "
			//		+ "at temp path \"" + Song.TempPath + "\" "
			//		+ "with destination path \"" + DestPath + "\" "
			//		+ "in a separate thread:" + Environment.NewLine
			//		+ ex,
			//		LogType.Error
			//	);
		}

		private void ConvertSongs()
		{
			const int bufferSize = 256;
			byte[] reusedBuffer = new byte[bufferSize];

			foreach (var song in Songs)
			{
				ConvertSong(song, reusedBuffer);
			}
		}

		private void ConvertSong(RecordedSong song, byte[] reusedBuffer)
		{
			var destPath = GetDestPath(song);

			using (var source = File.OpenRead(song.TempPath))
			{
				this.SongEncoder.Encode(
					source,
					destPath,
					new SongTags(
						title: song.SongInfo.SongName,
						artist: song.SongInfo.Artist
					),
					reusedBuffer
				);
			}

			File.Delete(song.TempPath);
			
			//With mutable settings now added (so the temp path could change), it's a pain to delete the temp file later
			//	File.Move(song.TempPath, Path.ChangeExtension(song.TempPath, ".wav-converted"));
			//	//Don't delete yet as it's easier to control later, and this won't be reached if there was an error
			//	//Rename the file so that it won't be converted again

			this.Completed = true;
		}

		public string GetDestPath(RecordedSong song)
		{
			return Path.Combine(this.OutputFolder, song.SongInfo.CombinedName) + this.SongEncoder.Extension;
		}

		private static bool TaskIsInProgress(Task task)
		{
			return task != null && !task.IsCanceled && !task.IsCompleted && !task.IsFaulted;
		}

		//	private IEnumerable<string> GetSongFileNames()
		//	{
		//		var fileFilter = new Regex($@"G#\d+-S#\d+ = .*{SpotifySongInfo.ArtistAndNameSeparator}.*\.wav");
		//	
		//		return Directory.EnumerateFiles(this.TempFolder).Where(fName => fileFilter.IsMatch(fName));
		//	}

		//	private (string songPath, string songFullName) ParseSongFileName(string fileName)
		//	{
		//		return (
		//			songPath: this.TempFolder + fileName,
		//			songFullName: Path.GetFileNameWithoutExtension(fileName.Substring(fileName.IndexOf(" = ") + 3))
		//		);
		//	}
	}
}
