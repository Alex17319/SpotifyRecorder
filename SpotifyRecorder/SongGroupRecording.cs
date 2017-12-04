using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Gui;

namespace SpotifyRec
{
	public class SongGroupRecording : IDisposable
	{
		public string TempFolder { get; }
		public int GroupNumber { get; }

		private readonly SongTracker _songTracker;
		private readonly AudioRecorder _audioRecorder;

		public DateTime RecordingStartTime { get; }

		public ReadOnlyCollection<SongInfo> Songs => _songTracker.Songs;

		public event EventHandler GroupFinished;

		private Logger _logger;

		private bool _splittingCompleted = false;
		/// <summary>
		/// False until everything, including asynchronously splitting the recording into songs, has been completed
		/// </summary>
		public bool SplittingCompleted {
			get { lock (_lock) return _splittingCompleted; }
		}
		private object _lock = new object();

		public SongGroupRecording(string tempFolder, int groupNumber, SpotifyProcessManager spotifyProcessManager, ISongClassifier songClassifier, int songRefreshInterval, Logger logger)
		{
			this.TempFolder = tempFolder;
			this.GroupNumber = groupNumber;

			_songTracker = new SongTracker(spotifyProcessManager, songClassifier, songRefreshInterval);
			_audioRecorder = new AudioRecorder(tempFolder, "TempGroupRec#" + groupNumber);

			RecordingStartTime = DateTime.Now;

			_songTracker.SongChanged += this.OnSongChanged;
			_songTracker.StartTracking();
		}

		private void OnSongChanged(object sender, SongChangeEventArgs e)
		{
			if (e.NewSong == null || !e.NewSong.GetValueOrDefault().IsSong)
			{
				_songTracker.FinishTracking();
				_audioRecorder.RequestStopRecording();
				_audioRecorder.Stopped += OnRecordingStopped;
			}
		}

		public void StopRecordingEarly()
		{
			_songTracker.FinishTracking();
			_songTracker.Dispose(); //Not needed *currently* but always good to do
			_audioRecorder.RequestStopRecording();
			_audioRecorder.Stopped += OnRecordingStopped;
		}

		private void OnRecordingStopped(object sender, EventArgs e)
		{
			_audioRecorder.Stopped -= OnRecordingStopped;
			_audioRecorder.Dispose(); //Not needed *currently* but always good to do

			GroupFinished?.Invoke(this, EventArgs.Empty);

			Task.Run((Action)SplitSongs)
			.ContinueWith(
				task => {
					lock (_lock) {
						_splittingCompleted = true;
					}
					if (task.Exception != null) {
						_logger?.Invoke(
							"An error occurred while splitting the recording into songs in a separate thread:\r\n"
							+ task.Exception,
							LogType.Error
						);
					}
				}
			);
		}

		private void SplitSongs()
		{
			if (!_audioRecorder.HasStopped) throw new InvalidOperationException(
				"Cannot split songs if the AudioRecorder hasn't stopped."
			);
			if (_songTracker.State != SongTracker.TrackState.Finished) throw new InvalidOperationException(
				"Cannot split songs if the SongTracker hasn't finished tracking songs."
			);

			using (var groupReader = new WaveFileReader(_audioRecorder.FullOutputPath))
			{
				const int bufferSize = 256; //I'm guessing this power of 2 should work well
				byte[] buffer = new byte[bufferSize];

				int songNum = 1;
				foreach (var song in _songTracker.Songs.Where(s => s.IsSong && s.HasStopped))
				{
					//Loop through songs, ignoring ads, durations where the music is paused, and incomplete songs

					string songPath = Path.Combine(
						this.TempFolder, 
						$"G#{this.GroupNumber}-S#{songNum} = {song.Artist} - {song.SongName}"
					);
					// ^ Adding in the group and song numbers avoids having to deal with
					// duplicates (they'll be dealt with later)

					using (var songWriter = new WaveFileWriter(songPath + ".wav-extracting", groupReader.WaveFormat))
					{
						ExtractSongToFile(buffer, groupReader, songWriter, song);
					}

					File.Move(songPath + ".wav", songPath + ".wav-extracting");

					songNum++;
				}
			}

			//Don't delete yet - clear up all the files later, where it's easier to make it customiseable etc.
			//This also ensures that if there's an error above the file should still get deleted.
		}

		private void ExtractSongToFile(byte[] sharedTempBuffer, WaveFileReader groupReader, WaveFileWriter songWriter, SongInfo song)
		{
			DateTime songEndTime = song.TimeStopped ?? this.RecordingStartTime + _audioRecorder.CurrentLength;
			TimeSpan songDuration = songEndTime - song.TimeStarted;
			int bytesPerMillisecond = _audioRecorder.WaveFormat.AverageBytesPerSecond / 1000;
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
					sharedTempBuffer,
					offset: 0,
					count: checked((int)Math.Min(songBytesRemaining, readerBytesRemaining))
				);
				songWriter.Write(sharedTempBuffer, offset: 0, count: numRead);
			}
		}

		public void Dispose()
		{
			StopRecordingEarly(); //Should work even if it's already stopped recording
		}
	}
}
