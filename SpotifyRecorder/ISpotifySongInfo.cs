using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public interface ISpotifySongInfo
	{
		bool IsSong { get; }

		/// <summary>
		/// Returns null if the audio is an ad or paused
		/// </summary>
		string Artist { get; }
		/// <summary>
		/// Returns the name of the song, ad, or "Spotify" if paused
		/// </summary>
		string SongName { get; }
	}
}
