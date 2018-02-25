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

namespace SpotifyRec
{
	public partial class MainForm : Form
	{
		public MainController MainController { get; }
		public RichTextBoxLogHandler RichTextBoxLogger { get; }
		public StreamLogHandler FileLogger { get; }

		public MainForm()
		{
			InitializeComponent();

			this.MainController = new MainController(
				logHandlers: new LogHandler[] {
					new RichTextBoxLogHandler(
						textBox: this.LogTextBox
					),
					new StreamLogHandler(
						streamWriter: new StreamWriter(
							new FileStream(
								Path.Combine(
									MainController.SettingsHost.TempFolder, //TODO: Make this a setting
									"Log " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".log"
								),
								FileMode.CreateNew,
								FileAccess.ReadWrite,
								FileShare.Read
							)
						)
					)
				}
			);

			this.SettingsPage.MainController = this.MainController;
			this.RecordingPage.MainController = this.MainController;

			this.MainTabs.SelectedIndexChanged += delegate { this.MainController.SettingsSaver.SaveNow(); };
			this.Deactivate += delegate { this.MainController.SettingsSaver.SaveNow(); };
			this.FormClosing += delegate { this.MainController.SettingsSaver.SaveNow(); };
		}

		//Look at this when you add lyrics:
		//https://www.alfredforum.com/topic/5927-force-im-feeling-lucky/
	}
}
