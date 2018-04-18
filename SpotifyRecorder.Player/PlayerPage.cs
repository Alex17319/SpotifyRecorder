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
