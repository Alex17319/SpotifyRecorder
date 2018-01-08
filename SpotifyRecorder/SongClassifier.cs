using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public struct SongClassificationInfo
	{
		public IEnumerable<string> AdNames { get; }
		public IEnumerable<string> AdKeywords { get; }
		public IEnumerable<string> SongNames { get; }

		public SongClassificationInfo(IEnumerable<string> adNames, IEnumerable<string> adKeywords, IEnumerable<string> songNames)
		{
			this.AdNames = adNames;
			this.AdKeywords = adKeywords;
			this.SongNames = songNames;
		}

		//	//	/// <summary>
		//	//	/// Returns true if the specified window title represents a song,
		//	//	/// or false if it represents an ad or paused duration. Also parses
		//	//	/// the window title, and returns the artist and song name as out parameters.
		//	//	/// </summary>
		//	//	/// <param name="windowTitle">The title of the spotify window, which may or may not represent a song.</param>
		//	//	/// <param name="artist">The parsed artist of the song. Null if the audio is not a song.</param>
		//	//	/// <param name="songName">The parsed name of the song, or <paramref name="windowTitle"/> if the audio is not a song.</param>
		//	/// <summary>
		//	/// Returns true if the specified window title represents a song,
		//	/// or false if it represents an ad or paused duration.
		//	/// </summary>
		//	public void IsSong(
	}
}
