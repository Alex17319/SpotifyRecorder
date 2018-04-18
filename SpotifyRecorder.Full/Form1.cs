using SpotifyRec.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.Full
{
	public partial class MainForm : Form
	{
		public const int OngoingProcessesRefreshInterval = 10000;

		public MainController MainController { get; private set; }
		private RichTextBoxLogHandler _richTextBoxLogger;
		private StreamLogHandler _fileLogger;

		private Timer _ongoingProcessesRefreshTimer;

		public MainForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			//The file log needs the temporary path, which is part of the settings,
			//which are part of MainController, so it can't be created until later.
			//This is used to store the messages logged before that point, and it
			//might as well be used for all logs for consistency & neatness
			var tempLog = new ListLogHandler();
			tempLog.LogMessage("Starting up...", LogType.Message);

			this.MainController = new MainController(
				logHandlers: new LogHandler[] { tempLog }
			);

			this.SettingsPage.MainController = this.MainController;
			this.RecordingPage.RecordingTabController = this.MainController;

			this.MainTabs.SelectedIndexChanged += delegate { this.MainController.SettingsSaver.SaveNow(); };
			this.Deactivate += delegate { this.MainController.SettingsSaver.SaveNow(); };
			this.FormClosing += delegate { this.MainController.SettingsSaver.SaveNow(); };

			this._ongoingProcessesRefreshTimer = new Timer() { Interval = OngoingProcessesRefreshInterval };
			this._ongoingProcessesRefreshTimer.Tick += delegate { MainController.RefreshOngoingProcesses(); };
			this._ongoingProcessesRefreshTimer.Start();

			this._richTextBoxLogger = new RichTextBoxLogHandler(
				textBox: this.LogTextBox
			) {
				Provider = this.MainController,
				FullMessagesToLog = tempLog.List
			};

			this._fileLogger = new StreamLogHandler(
				streamWriter: new StreamWriter(
					new FileStream(
						Path.Combine(
							MainController.SettingsHost.TempFolder, //TODO: Make this a separate setting
							"Log " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".log"
						),
						FileMode.CreateNew,
						FileAccess.ReadWrite,
						FileShare.Read
					)
				)
			) {
				Provider = this.MainController,
				FullMessagesToLog = tempLog.List
			};
		}

		//Look at this when you add lyrics:
		//https://www.alfredforum.com/topic/5927-force-im-feeling-lucky/
	}
}
