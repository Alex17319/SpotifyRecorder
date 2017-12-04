using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class SongChangeEventArgs : EventArgs
	{
		public SongInfo? OldSong { get; }
		public SongInfo? NewSong { get; }

		public SongChangeEventArgs(SongInfo? oldSong, SongInfo? newSong)
		{
			this.OldSong = oldSong;
			this.NewSong = newSong;
		}
	}
}
