﻿using System;
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
		public bool IsRecording { get; private set; }

		public event EventHandler RecordingStarted;
		public event EventHandler RecordingStopped;

		public SettingsHost SettingsHost => MainController.SettingsHost;

		public RecordingPage()
		{
			InitializeComponent();

			StartStopButton.Click += delegate
			{
				if (IsRecording)
				{
					StopRecording();
				}
				else
				{
					StartRecording();
				}
			};
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.ParentForm.FormClosing += OnParentFormClosing;
		}

		private void StartRecording()
		{
			IsRecording = true;
			StartStopButton.Text = "Stop Recording";

			MainController?.RecordingHost.StartRecording();
			RecordingStarted?.Invoke(this, EventArgs.Empty);
		}

		private void StopRecording()
		{
			IsRecording = false;
			StartStopButton.Text = "Start Recording";

			MainController?.RecordingHost.StopRecording();
			RecordingStopped?.Invoke(this, EventArgs.Empty);
		}

		private void OnParentFormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsRecording) StopRecording();
		}

		private MainController _mainController;
		public MainController MainController {
			get => _mainController;
			set {
				if (_mainController != null)
				{
					OuputFolderPanel.PathChanged     += OnOutputFolderUIChanged;
					SettingsHost.OutputFolderChanged += OnOutputFolderSettingChanged;
				}

				_mainController = value;

				if (_mainController != null)
				{
					OuputFolderPanel.PathChanged     += OnOutputFolderUIChanged;
					SettingsHost.OutputFolderChanged += OnOutputFolderSettingChanged;

					//Update UI values to match settings
					OnOutputFolderSettingChanged(this, EventArgs.Empty);
				}

				void OnOutputFolderUIChanged     (object sender, EventArgs e) => SettingsHost.OutputFolder = OuputFolderPanel.Path;
				void OnOutputFolderSettingChanged(object sender, EventArgs e) => OuputFolderPanel.Path     = SettingsHost.OutputFolder;
			}
		}
	}
}
