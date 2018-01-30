using SpotifyRec.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class RecordingHost
	{
		public SettingsHost SettingsHost { get; }

		private readonly SpotifyProcessManager _spotifyProcessManager;
		private readonly Logger _logger;

		public bool IsRecording => _currentSession != null;
		private RecordingSession _currentSession;

		public EventHandler<SongGroupRecorder, EventArgs> GroupFinished;

		public RecordingHost(SettingsHost settingsHost, SpotifyProcessManager spotifyProcessManager, Logger logger)
		{
			this.SettingsHost = settingsHost;

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
				SettingsHost.TempFolder,
				_spotifyProcessManager,
				SettingsHost.SongClassificationInfo,
				SettingsHost.SongRefreshInterval,
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
