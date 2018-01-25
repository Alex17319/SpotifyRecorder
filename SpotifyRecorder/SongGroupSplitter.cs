using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyRec.Utils;

namespace SpotifyRec
{
	public class SongGroupSplitter
	{
		public RecordedSongGroup Group { get; }

		private readonly Logger _logger;

		private AsyncProcessHelper<RecordedSong, ValueTuple> _asyncProcessHelper;

		public bool InProgress => _asyncProcessHelper.InProgress;
		public bool Completed => _asyncProcessHelper.Completed;
		public bool Failed => _asyncProcessHelper.Failed;

		public ImmutableList<RecordedSong> CompletedSongs => _asyncProcessHelper.PartialResults;

		public SongGroupSplitter(RecordedSongGroup group, Logger logger, bool autostart = false)
		{
			this.Group = group;

			this._asyncProcessHelper = AsyncProcessHelper.Create<RecordedSong>(SplitGroup, logger, "split song group into songs");

			if (autostart) SplitGroupAsync();
		}

		/// <summary>
		/// Does nothing if the splitting process has completed/failed or is in progress
		/// </summary>
		public void SplitGroupAsync()
		{
			_asyncProcessHelper.RunTaskAsync();
		}

		private void SplitGroup(AsyncPartialResultCollector<RecordedSong> partialResults)
		{
			using (var groupReader = new WaveFileReader(Group.Path))
			{
				const int bufferSize = 256; //I'm guessing this power of 2 should work well
				byte[] buffer = new byte[bufferSize];

				int songNum = 1;
				foreach (var song in Group.Songs.Where(s => s.IsSong && s.HasStopped))
				{
					//Loop through songs, ignoring ads, durations where the music is paused, and incomplete songs

					string songPath = Path.Combine(
						Path.GetDirectoryName(Group.Path), 
						$"Song#{songNum} {song.CombinedName} (Group {Group.GroupID})"
					);
					// ^ Adding in the group id and song number avoids having to deal with
					// duplicates (they'll be dealt with later)

					using (var songWriter = new WaveFileWriter(songPath + ".wav-extracting", groupReader.WaveFormat))
					{
						ExtractSongToFile(buffer, groupReader, songWriter, song);
					}

					File.Move(songPath + ".wav-extracting", songPath + ".wav");

					partialResults.AddPartialResult(new RecordedSong(song, songPath + ".wav"));

					songNum++;
				}
			}

			//TODO: Fix this as deleting later no longer works (due to setting mutation)
			//Don't delete yet - clear up all the files later, where it's easier to make it customiseable etc.
			//This also ensures that if there's an error above the file should still get deleted.
		}

		private void ExtractSongToFile(byte[] reusedBuffer, WaveFileReader groupReader, WaveFileWriter songWriter, SongInfo song)
		{
			DateTime songEndTime = song.EndTime ?? Group.EndTime;
			TimeSpan songDuration = songEndTime - song.StartTime;
			int bytesPerMillisecond = Group.WaveFormat.AverageBytesPerSecond / 1000;
			long songLength = (long)songDuration.TotalMilliseconds * bytesPerMillisecond;
			long songStartPos = groupReader.Position;
			long songEndPos = songStartPos + songLength;

			//Stream variables use longs not ints, so use longs where possible/relevant
			//However, Stream.Read() takes ints, so we have to cast back there (with a checked cast)

			while (true)
			{
				long songBytesRemaining = songEndPos - groupReader.Position;
				long readerBytesRemaining = groupReader.Length - groupReader.Position;

				if (songBytesRemaining <= 0 || readerBytesRemaining <= 0) break;

				int numRead = groupReader.Read(
					reusedBuffer,
					offset: 0,
					count: checked((int)Math.Min(songBytesRemaining, readerBytesRemaining))
				);
				songWriter.Write(reusedBuffer, offset: 0, count: numRead);
			}
		}
	}
}
