using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyRecorder.Utils;
using System.Text.RegularExpressions;

namespace SpotifyRec.Player
{
	public partial class PlayerPage : UserControl
	{
		public SettingsHost SettingsHost => PlayerTabController.SettingsHost;

		private PlayerTabController _playerTabController;
		public PlayerTabController PlayerTabController {
			get => _playerTabController;
			set {
				//See RecordingPage for more examples to explain comments

				if (_playerTabController != null)
				{
					//Unsubscribe <controller>, <controller>.<whatever> (eg. SettingsHost), etc based events
					PlayerTabController.SongHistoryTracker.SongChanged -= OnHistoryTrackerSongChanged;
				}

				_playerTabController = value;

				if (_playerTabController != null)
				{
					//Subscribe to events of type above
					PlayerTabController.SongHistoryTracker.SongChanged += OnHistoryTrackerSongChanged;

					//Update UI values to match backing data (the event only gets fired when it *changes*)
					//Only needed for some events
				}

				//Define very simple one-line handlers for the events of the type above
			}
		}

		public PlayerPage()
		{
			InitializeComponent();

			this.PlayPauseButton.Click += delegate { PlayerTabController.SpotifyController.PlayPause (  ); };
			this.NextButton     .Click += delegate { PlayerTabController.SpotifyController.NextTrack (  ); };
			this.PrevButton     .Click += delegate { PlayerTabController.SpotifyController.PrevTrack (  ); };
			this.ReshuffleButton.Click += delegate { PlayerTabController.SpotifyController.NextTrack (80); };
			this.SkipManyButton .Click += delegate { PlayerTabController.SpotifyController.NextTrack (10); };
			this.VolUpButton    .Click += delegate { PlayerTabController.SpotifyController.VolumeUp  (  ); };
			this.VolDownButton  .Click += delegate { PlayerTabController.SpotifyController.VolumeDown(  ); };
			this.MuteButton     .Click += delegate { PlayerTabController.SpotifyController.MuteUnmute(  ); };

			this.RecordHistoryCheckBox.CheckedChanged += delegate
			{
				if (this.RecordHistoryCheckBox.Checked) {
					PlayerTabController.SongHistoryTracker.StartHistoryRecordingSession();
				} else {
					PlayerTabController.SongHistoryTracker.StopHistoryRecordingSession();
				}
			};
		}

		private void OnHistoryTrackerSongChanged(object sender, SongChangeEventArgs e)
		{
			var combinedNewSongName = e.NewSong?.CombinedName;
			if (string.IsNullOrEmpty(combinedNewSongName)) return;

			AddToHistory(combinedNewSongName);

			if (IsInHistory(combinedNewSongName)) {
				this.PlayerTabController.SpotifyController.NextTrack();
			}
		}

		private void AddToHistory(string combinedNewSongName)
		{
			if (this.HistoryTextBox.TextLength == 0) {
				this.HistoryTextBox.AppendText(combinedNewSongName);
			} else {
				this.HistoryTextBox.AppendText(Environment.NewLine + combinedNewSongName);
			}
		}

		private bool IsInHistory(string combinedNewSongName)
		{
			return Regex.IsMatch(combinedNewSongName, @"[\r\n]", RegexOptions.Multiline);
		}
	}
}
