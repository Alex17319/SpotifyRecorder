﻿using SpotifyRec.SongEncoding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SpotifyRec.Utils;
using System.Collections.Immutable;

namespace SpotifyRec.Recording
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

		private AsyncProcessHelper<ConvertedSong, ValueTuple> _asyncProcessHelper;

		public bool InProgress => _asyncProcessHelper.InProgress;
		public bool Completed => _asyncProcessHelper.Completed;
		public bool Failed => _asyncProcessHelper.Failed;

		public ImmutableList<ConvertedSong> ConvertedSongs => _asyncProcessHelper.PartialResults;

		public SongBatchConverter(IEnumerable<RecordedSong> songs, string outputFolder, ISongEncoder songEncoder, Logger logger, bool autostart = false)
		{
			this.Songs = songs;
			this.OutputFolder = outputFolder;
			this.SongEncoder = songEncoder;
			this._logger = logger;

			this._asyncProcessHelper = AsyncProcessHelper.Create<ConvertedSong>(ConvertSongs, logger, "convert songs");

			if (autostart) ConvertSongsAsync();
		}

		/// <summary>
		/// Does nothing if the conversion has completed/failed or is in progress
		/// </summary>
		public void ConvertSongsAsync()
		{
			_asyncProcessHelper.RunTaskAsync();

			_logger.Log(
				$"Started new song conversion batch: {Songs.Count()} songs "
				+ $"to be converted to format '{SongEncoder.Extension}'. "
				+ $"First song: '{Songs.FirstOrDefault().SongInfo.CombinedName}'."
			);

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

		private void ConvertSongs(AsyncPartialResultCollector<ConvertedSong> partialResults)
		{
			const int bufferSize = 256;
			byte[] reusedBuffer = new byte[bufferSize];

			foreach (var song in Songs)
			{
				partialResults.AddPartialResult(
					ConvertSong(song, reusedBuffer)
				);
			}

			_logger.Log(
				$"Completed song conversion batch: {Songs.Count()} songs "
				+ $"were converted to format '{SongEncoder.Extension}'. "
				+ $"First song: '{Songs.FirstOrDefault().SongInfo.CombinedName}'."
			);
		}

		private ConvertedSong ConvertSong(RecordedSong song, byte[] reusedBuffer)
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

			return new ConvertedSong(
				songInfo: song.SongInfo,
				tempPath: song.TempPath,
				outputPath: destPath
			);
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
