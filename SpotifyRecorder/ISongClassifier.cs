using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public interface ISongClassifier
	{
		/// <summary>
		/// Returns true if the specified audio name represents a song,
		/// or false if it is an ad or paused.
		/// </summary>
		bool IsSong(string artist, string songName);
	}
}
