using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Recording
{
	public struct RecordedSong
	{
		public SongInfo SongInfo { get; }
		public string TempPath { get; }
		
		public RecordedSong(SongInfo songInfo, string tempPath)
		{
			this.SongInfo = songInfo;
			this.TempPath = tempPath;
		}
	}
}
