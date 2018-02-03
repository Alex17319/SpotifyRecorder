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
		public RichTextBoxLogger RichTextBoxLogger { get; }
		public StreamLogger FileLogger { get; }

		public MainForm()
		{
			InitializeComponent();

			this.MainController = new MainController();

			this.settingsPage1.MainController = this.MainController;
			this.recordingPage1.MainController = this.MainController;

			this.RichTextBoxLogger = new RichTextBoxLogger(
				provider: MainController,
				textBox: this.LogTextBox
			);
			this.FileLogger = new StreamLogger(
				provider: MainController,
				streamWriter: new StreamWriter(
					File.Create(
						Path.Combine(
							MainController.SettingsHost.TempFolder, //TODO: Improve this
							"Log " + DateTime.Now.ToString("yyyy-mm-dd HH-mm-ss.fff") + ".log"
						)
					)
				)
			);
		}
	}
}
