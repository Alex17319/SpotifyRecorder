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
		private readonly Logger _logger;

		public SpotifyController SpotifyController { get; }

		public PlayerTabController(SettingsHost settingsHost, SpotifyProcessManager spotifyProcessManager, Logger logger)
		{
			this.SettingsHost = settingsHost;
			this.SpotifyProcessManager = spotifyProcessManager;
			this._logger = logger;

			this.SpotifyController = new SpotifyController(spotifyProcessManager);
		}

		public void RefreshOngoingProcesses()
		{
			_logger.Log("Refreshing player tab's ongoing processes... (none to refresh)", LogType.MinorMessage);
		}
	}
}
