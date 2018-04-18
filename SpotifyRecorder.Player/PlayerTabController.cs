using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Player
{
	public class PlayerTabController
	{
		public SettingsHost SettingsHost { get; }
		public SpotifyProcessManager SpotifyProcessManager { get; }
		public Logger Logger { get; }

		public SpotifyController SpotifyController { get; }
		public SongHistoryTracker SongHistoryTracker { get; }

		public PlayerTabController(SettingsHost settingsHost, SpotifyProcessManager spotifyProcessManager, Logger logger)
		{
			this.SettingsHost = settingsHost;
			this.SpotifyProcessManager = spotifyProcessManager;
			this.Logger = logger;

			this.SpotifyController = new SpotifyController(spotifyProcessManager);

			this.SongHistoryTracker = new SongHistoryTracker(
				spotifyProcessManager,
				settingsHost,
				logger
			);
		}

		public void RefreshOngoingProcesses()
		{
			Logger.Log("Refreshing player tab's ongoing processes... (none to refresh)", LogType.MinorMessage);
		}
	}
}
