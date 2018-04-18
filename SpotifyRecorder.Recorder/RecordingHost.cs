using SpotifyRec.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Recording
{
	public class RecordingHost
	{
		public ISettingProvider SettingProvider { get; }

		private readonly SpotifyProcessManager _spotifyProcessManager;
		private readonly Logger _logger;

		public bool IsRecording => _currentSession != null;
		private RecordingSession _currentSession;

		public EventHandler<SongGroupRecorder, EventArgs> GroupFinished;

		public RecordingHost(ISettingProvider settingProvider, SpotifyProcessManager spotifyProcessManager, Logger logger)
		{
			this.SettingProvider = settingProvider;

			this._spotifyProcessManager = spotifyProcessManager;
			this._logger = logger;
		}

		public void StartStopRecording() {
			if (IsRecording) StopRecording();
			else StartRecording();
		}

		public void StartRecording()
		{
			if (IsRecording) throw new InvalidOperationException("Recording already started.");

			_currentSession = new RecordingSession(
				SettingProvider.TempFolder,
				_spotifyProcessManager,
				SettingProvider.SongClassificationInfo,
				SettingProvider.SongRefreshInterval,
				_logger
			);

			_currentSession.GroupFinished += OnGroupFinished;
		}

		public void StopRecording()
		{
			if (!IsRecording) throw new InvalidOperationException("Recording already stopped.");

			_currentSession.GroupFinished -= OnGroupFinished;

			_currentSession.Dispose();
			_currentSession = null;
		}

		private void OnGroupFinished(SongGroupRecorder sender, EventArgs e)
		{
			GroupFinished.Fire(sender, e);
		}
	}
}
