using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.UI
{
	public partial class RecordingPage : UserControl
	{
		public bool IsRecordingEnabled { get; private set; }

		public event EventHandler RecordingEnabled;
		public event EventHandler RecordingDisabled;

		public SettingsHost _settingsHost;

		public RecordingPage(SettingsHost settingsHost)
		{
			InitializeComponent();

			this._settingsHost = settingsHost;

			StartStopButton.Click += delegate
			{
				IsRecordingEnabled = !IsRecordingEnabled;

				if (IsRecordingEnabled) RecordingEnabled?.Invoke(this, EventArgs.Empty);
				else RecordingDisabled?.Invoke(this, EventArgs.Empty);
			};

			OuputFolderPanel.PathChanged     += delegate { _settingsHost.OutputFolder = OuputFolderPanel.Path;      };
			settingsHost.OutputFolderChanged += delegate { OuputFolderPanel.Path      = _settingsHost.OutputFolder; };

		}
	}
}
