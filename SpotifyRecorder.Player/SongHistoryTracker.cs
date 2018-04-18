using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Player
{
	public class SongHistoryTracker
	{
		public SpotifyProcessManager SpotifyProcessManager { get; }
		public ISettingProvider SettingProvider { get; }
		private readonly Logger _logger;

		private SongTracker _songTracker;

		public event EventHandler<SongChangeEventArgs> SongChanged;

		public SongHistoryTracker(SpotifyProcessManager spotifyProcessManager, ISettingProvider settingProvider, Logger logger)
		{
			this.SpotifyProcessManager = spotifyProcessManager;
			this.SettingProvider = settingProvider;
			this._logger = logger;
		}

		public void StartHistoryRecordingSession()
		{
			if (_songTracker != null) {
				_logger.Log("Ignored attempt to start new history recording session while one was already running.", LogType.Warning);
				return;
			}

			_songTracker = new SongTracker(
				SpotifyProcessManager,
				SettingProvider.SongClassificationInfo,
				SettingProvider.SongRefreshInterval,
				_logger
			);
			_songTracker.SongChanged += OnSongChanged;
			_songTracker.StartTracking();
		}

		public void StopHistoryRecordingSession()
		{
			if (_songTracker == null) {
				_logger.Log("Ignored attempt to stop current history recording session when there wasn't one running.", LogType.Warning);
				return;
			}

			_songTracker.SongChanged -= OnSongChanged;
			_songTracker.Dispose();
			_songTracker = null;
		}

		private void OnSongChanged(object sender, SongChangeEventArgs e)
		{
			SongChanged?.Invoke(sender, e);
		}
	}
}
