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
using System.Collections.Immutable;

namespace SpotifyRec
{
	public class SongGroupRecorder : IDisposable
	{
		//	public const string GroupNumberPrefix = "G#";
		//	public const string SongNumberPrefix = "S#";
		//	public const string GroupAndSongNumSeparator = "-";
		//	public const string SongNumAndWinTitleSeparator = " = ";

		public string TempFolder { get; }
		public Guid GroupID { get; }

		private readonly SongTracker _songTracker;
		private readonly AudioRecorder _audioRecorder;

		public DateTime RecordingStartTime { get; }

		public ReadOnlyCollection<SongInfo> Songs => _songTracker.Songs;

		public event EventHandler GroupFinished;
		/// <summary>Note: Null when <see cref="IsGroupFinished"/> is false.</summary>
		public RecordedSongGroup RecordedGroup { get; private set; }
		public bool IsGroupFinished => RecordedGroup != null;

		private Logger _logger;

		private bool _splittingCompleted = false;
		/// <summary>
		/// False until everything, including asynchronously splitting the recording into songs, has been completed
		/// </summary>
		public bool SplittingCompleted {
			get { lock (_lock) return _splittingCompleted; }
		}
		private object _lock = new object();

		public SongGroupRecorder(string tempFolder, SpotifyProcessManager spotifyProcessManager, SongClassificationInfo songClassificationInfo, int songRefreshInterval, Logger logger)
		{
			this.TempFolder = tempFolder;
			this.GroupID = Guid.NewGuid();
			this._logger = logger;

			_songTracker = new SongTracker(spotifyProcessManager, songClassificationInfo, songRefreshInterval);
			_audioRecorder = new AudioRecorder(tempFolder, "TempGroupRec#" + this.GroupID);

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

			this.RecordedGroup = new RecordedSongGroup(
				path: _audioRecorder.FullOutputPath,
				groupID: GroupID,
				startTime: RecordingStartTime,
				duration: _audioRecorder.CurrentLength,
				waveFormat: _audioRecorder.WaveFormat,
				songs: Songs.ToImmutableList()
			);
			GroupFinished?.Invoke(this, EventArgs.Empty);

			//	Task.Run((Action)SplitSongs)
			//	.ContinueWith(
			//		task => {
			//			lock (_lock) {
			//				_splittingCompleted = true;
			//			}
			//			if (task.Exception != null) {
			//				_logger?.Invoke(
			//					"An error occurred while splitting the recording into songs in a separate thread:\r\n"
			//					+ task.Exception,
			//					LogType.Error
			//				);
			//			}
			//		}
			//	);
		}

		//	private void SplitSongs()
		//	{
		//		if (!_audioRecorder.HasStopped) throw new InvalidOperationException(
		//			"Cannot split songs if the AudioRecorder hasn't stopped."
		//		);
		//		if (_songTracker.State != SongTracker.TrackState.Finished) throw new InvalidOperationException(
		//			"Cannot split songs if the SongTracker hasn't finished tracking songs."
		//		);
		//	}

		public void Dispose()
		{
			StopRecordingEarly(); //Should work even if it's already stopped recording
		}
	}
}
