using SpotifyRec.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec
{
	//A central point the UI uses to communicate with the backend. Also used to initialise the backend,
	//and (through events) allow communication between different parts of the backend. Something distributed
	//(i.e. not one big class) might be better, but could easily end up much more complex especially in
	//regard to initialisation and dependency injection.
	public class MainController : ILogProvider
	{
		public string SettingsFolder { get; }

		public SettingsHost SettingsHost { get; }
		public SettingsSaver SettingsSaver { get; }
		public RecordingHost RecordingHost { get; }
		public SongGroupSplitterHost SongGroupSplitterHost { get; }
		public SongConversionHost SongConversionHost { get; }

		private readonly SpotifyProcessManager _spotifyProcessManager;
		private readonly Logger _logger;

		public event Logger LogMessageReceived;

		public MainController()
		{
			this._logger = (mesage, messageType) => LogMessageReceived?.Invoke(mesage, messageType);


			this.SettingsFolder = Application.StartupPath; //StartupPath is just the folder, not the actual exe file path
			this.SettingsHost = new SettingsHost(
				SettingsLoader.Load(
					settingsFolder: this.SettingsFolder
				)
			);
			this.SettingsSaver = new SettingsSaver(
				settingsHost: this.SettingsHost,
				settingsFolder: this.SettingsFolder,
				saveDelay: 60000,
				logger: _logger
			);
			this.SettingsHost.AnySettingChanged += delegate { this.SettingsSaver.SaveAfterWaiting(); };

			this._spotifyProcessManager = new SpotifyProcessManager(_logger);
			this.RecordingHost = new RecordingHost(SettingsHost, _spotifyProcessManager, _logger);
			this.SongGroupSplitterHost = new SongGroupSplitterHost(SettingsHost, _logger);
			this.SongConversionHost = new SongConversionHost(SettingsHost, _logger);

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
