using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road = System.Int32;

namespace SpotifyRec
{
	//A central point the UI uses to communicate with the backend. Also used to initialise the backend,
	//and (through events) allow communication between different parts of the backend. Something distributed
	//(i.e. not one big class) might be better, but could easily end up much more complex especially in
	//regard to initialisation and dependency injection.
	public class MainController
	{
		public SettingsHost SettingsHost { get; }
		public RecordingHost RecordingHost { get; }
		public SongGroupSplitterHost SongGroupSplitterHost { get; }
		public SongConversionHost SongConversionHost { get; }

		private readonly SpotifyProcessManager _spotifyProcessManager;
		private readonly Logger _logger;

		public event Logger LogMessageReceived;

		public MainController(SettingsHost settingsHost, SpotifyProcessManager spotifyProcessManager)
		{
			this.SettingsHost = settingsHost;

			this._spotifyProcessManager = spotifyProcessManager;

			this._logger = (mesage, messageType) => LogMessageReceived?.Invoke(mesage, messageType);

			this.RecordingHost = new RecordingHost(settingsHost, spotifyProcessManager, _logger);
			this.SongGroupSplitterHost = new SongGroupSplitterHost(settingsHost, _logger);
			this.SongConversionHost = new SongConversionHost(settingsHost, _logger);

			this.RecordingHost.GroupFinished += (sender, e) =>
			{
				this.SongGroupSplitterHost.Enqueue(sender.RecordedGroup);
			};
		}

		public void RefreshOngoingProcesses()
		{
			this.SongGroupSplitterHost.RefreshOngoingProcesses();

			this.SongConversionHost.EnqueueAll(this.SongGroupSplitterHost.CompletedSongs);

			this.SongConversionHost.RefreshOngoingProcesses();
		}
	}
}
