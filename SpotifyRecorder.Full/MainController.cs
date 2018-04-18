using SpotifyRec.Logging;
using SpotifyRec.Player;
using SpotifyRec.Recording;
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

		public RecordingTabController RecordingTabController { get; }
		public PlayerTabController PlayerTabController { get; }

		private readonly SpotifyProcessManager _spotifyProcessManager;
		private readonly Logger _logger;

		public event Logger LogMessageReceived;
		private void FireLogMessageReceived(string message, LogType logType) {
			lock (_lock) {
				LogMessageReceived.Invoke(message, logType);
			}
		}

		private object _lock = new object();

		public MainController(params LogHandler[] logHandlers)
			: this((IEnumerable<LogHandler>)logHandlers)
		{ }

		public MainController(IEnumerable<LogHandler> logHandlers)
		{
			foreach (var handler in logHandlers)
			{
				handler.Provider = this;
			}

			this._logger = (mesage, messageType) => LogMessageReceived?.Invoke(mesage, messageType);

			this.SettingsFolder = Application.StartupPath; //StartupPath is just the folder, not the actual exe file path
			this.SettingsHost = new SettingsHost(
				SettingsLoader.Load(
					settingsFolder: this.SettingsFolder,
					logger: _logger
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

			this.RecordingTabController = new RecordingTabController(this.SettingsHost, this._spotifyProcessManager, this._logger);
			this.PlayerTabController = new PlayerTabController(this.SettingsHost, this._spotifyProcessManager, this._logger);
		}

		//	bool ILogProvider.HasBuffer => false;
		//	IEnumerable<(string, LogType)> ILogProvider.Buffer => Enumerable.Empty<(string, LogType)>();
		//	bool ILogProvider.RerouteMesagesToBuffer { get => false; set { } }
		//	void ILogProvider.ClearBuffer() { }

		public void RefreshOngoingProcesses()
		{
			RecordingTabController.RefreshOngoingProcesses();
		}
	}
}
