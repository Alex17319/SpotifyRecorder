using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public struct ConvertedSong
	{
		public SongInfo SongInfo { get; }
		public string TempPath { get; }
		public string OutputPath { get; }

		public ConvertedSong(SongInfo songInfo, string tempPath, string outputPath)
		{
			this.SongInfo = songInfo;
			this.TempPath = tempPath;
			this.OutputPath = outputPath;
		}
	}
}
