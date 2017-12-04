using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public struct SpotifySongInfo : ISpotifySongInfo
	{
		public string WindowTitle { get; }

		public string Artist   => WindowTitle.Substring(0, WindowTitle.IndexOf(" - ")    );
		public string SongName => WindowTitle.Substring(   WindowTitle.IndexOf(" - ") + 3);

		public SpotifySongInfo(string windowTitle)
		{
			this.WindowTitle = windowTitle;
		}
	}
}
