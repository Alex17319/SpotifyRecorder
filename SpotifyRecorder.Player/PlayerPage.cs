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

namespace SpotifyRec.Player
{
	public partial class PlayerPage : UserControl
	{
		public PlayState AssumedPlayState { get; private set; }

		public PlayerPage()
		{
			InitializeComponent();

			this.PlayPauseButton.Click += delegate
			{
				switch (AssumedPlayState)
				{
					case PlayState.Playing:
						AssumedPlayState = PlayState.Paused;
						PlayPauseButton.Text = "Play";
						PlayerTabController.SpotifyController.Pause();
						break;
					case PlayState.Paused:
						AssumedPlayState = PlayState.Playing;
						PlayPauseButton.Text = "Pause";
						PlayerTabController.SpotifyController.Play();
						break;
					default:
						PlayerTabController.Logger.Log("Assumed playing state was invalid ('" + AssumedPlayState + "'). Defaulting to play mode.", LogType.Warning);
						AssumedPlayState = PlayState.Playing;
						PlayerTabController.SpotifyController.Play();
						break;

				}
			};

			this.NextButton     .Click += delegate { PlayerTabController.SpotifyController.NextTrack (  ); };
			this.PrevButton     .Click += delegate { PlayerTabController.SpotifyController.PrevTrack (  ); };
			this.ReshuffleButton.Click += delegate { PlayerTabController.SpotifyController.NextTrack (50); };
			this.SkipManyButton .Click += delegate { PlayerTabController.SpotifyController.NextTrack (10); };
			this.VolUpButton    .Click += delegate { PlayerTabController.SpotifyController.VolumeUp  (  ); };
			this.VolDownButton  .Click += delegate { PlayerTabController.SpotifyController.VolumeDown(  ); };
			this.MuteButton     .Click += delegate { PlayerTabController.SpotifyController.MuteUnmute(  ); };
		}

		private PlayerTabController _playerTabController;
		public PlayerTabController PlayerTabController {
			get => _playerTabController;
			set {
				if (_playerTabController != null)
				{
					//Unsubscribe settings events (see Recording Page)
				}

				_playerTabController = value;

				if (_playerTabController != null)
				{
					//Subscribe settings events (see Recording Page)

					//Update UI values to match settings
					//(see Recording Page)
				}

				//Settings event eventhandler definitions (see Recording Page)
			}
		}
	}
}
