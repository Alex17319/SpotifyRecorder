using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Recording
{
	public class RecordingTabController
	{
		public SettingsHost SettingsHost { get; }
		public SpotifyProcessManager SpotifyProcessManager { get; }
		private readonly Logger _logger;

		public RecordingHost RecordingHost { get; }
		public SongGroupSplitterHost SongGroupSplitterHost { get; }
		public SongConversionHost SongConversionHost { get; }


		public RecordingTabController(SettingsHost settingsHost, SpotifyProcessManager spotifyProcessManager, Logger logger)
		{
			this.SettingsHost = settingsHost;
			this.SpotifyProcessManager = spotifyProcessManager;
			this._logger = logger;

			this.RecordingHost = new RecordingHost(settingsHost, spotifyProcessManager, logger);
			this.SongGroupSplitterHost = new SongGroupSplitterHost(settingsHost, logger);
			this.SongConversionHost = new SongConversionHost(settingsHost, logger);

			this.RecordingHost.GroupFinished += (sender, e) =>
			{
				this.SongGroupSplitterHost.Enqueue(sender.RecordedGroup);
			};

			this.SongGroupSplitterHost.SongGroupSplit += (sender, e) =>
			{
				this.SongConversionHost.EnqueueAll(e.Splitter.CompletedSongs);
			};
		}

		public void RefreshOngoingProcesses()
		{
			_logger.Log("Refreshing recording tab's ongoing processes...", LogType.MinorMessage);

			this.SongGroupSplitterHost.RefreshOngoingProcesses();

			this.SongConversionHost.RefreshOngoingProcesses();
		}
	}
}
