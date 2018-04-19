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
					PlayerTabController.SongTracker.SongChanged -= OnSongChanged;
				}

				_playerTabController = value;

				if (_playerTabController != null)
				{
					//Subscribe to events of type above
					PlayerTabController.SongTracker.SongChanged += OnSongChanged;

					//Update UI values to match backing data (the event only gets fired when it *changes*)
					//Only needed for some events
					//Would be nice, but doesn't work, just have to pause and play again to add the first song
					//	var currentSong = PlayerTabController.SongTracker.CurrentSong;
					//	if (currentSong != null) AddToHistory(currentSong.Value.CombinedName);
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
		}

		private void OnSongChanged(object sender, SongChangeEventArgs e)
		{
			this.PlayerTabController.Logger.Log("Song changed. New song: " + e.NewSong?.CombinedName);

			if (e.NewSong?.IsSong != true) return;
			//No point attempting to skip ads, and definitely don't want to press skip when
			//when someone pauses and the song changes to "Spotify" as skipping makes it start
			//playing again...

			var combinedNewSongName = e.NewSong?.CombinedName;
			if (string.IsNullOrEmpty(combinedNewSongName)) return;

			if (
				(this.SkipDuplicatesCheckBox.Checked && IsInHistory(combinedNewSongName))
				||
				(this.FilterSongsCheckBox.Checked && IsInFilters(combinedNewSongName))
			) {
				this.PlayerTabController.SpotifyController.NextTrack();
			}

			//Make sure to do this AFTER checking to see if it should be skipped, otherwise every song gets skipped (oops)
			if (this.RecordHistoryCheckBox.Checked)
			{
				AddToHistory(combinedNewSongName);
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
			var sn = combinedNewSongName;
			return Regex.IsMatch(
				input: this.HistoryTextBox.Text,
				pattern: $@"(^{sn}$|{sn}[\r\n]|[\r\n]{sn})",
				options: RegexOptions.Multiline
			);
		}

		private bool IsInFilters(string combinedNewSongName)
		{
			foreach (var filter in this.FiltersTextBox.Lines) {
				if (Regex.IsMatch(combinedNewSongName, pattern: filter)) return true;
			}
			return false;
		}
	}
}
