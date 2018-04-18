using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.Player
{
	public partial class PlayerPage : UserControl
	{
		public PlayerPage()
		{
			InitializeComponent();
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
