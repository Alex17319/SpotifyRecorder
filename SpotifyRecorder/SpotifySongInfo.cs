using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public struct SpotifySongInfo : ISpotifySongInfo
	{
		public const string ArtistAndNameSeparator = " - ";

		public string WindowTitle { get; }
		public SongClassificationInfo SongClassificationInfo { get; }

		public bool IsSong { get; }
		public string Artist { get; }
		public string SongName { get; }

		public SpotifySongInfo(string windowTitle, SongClassificationInfo songClassificationInfo)
		{
			this.WindowTitle = windowTitle;
			this.SongClassificationInfo = songClassificationInfo;

			this.IsSong = WindowTitleIsSong(windowTitle, songClassificationInfo);
			(this.Artist, this.SongName) = ParseWindowTitle(windowTitle);
		}

		public static bool WindowTitleIsSong(
			string windowTitle,
			SongClassificationInfo songClassificationInfo
		) {
			//First check for exempt song names
			if (songClassificationInfo.SongNames.Contains(windowTitle)) return true;

			//Then check that the window title was in the correct song format ("artist - name")
			//Ok if there's nothing before or after the separator
			if (!windowTitle.Contains(ArtistAndNameSeparator)) return false;

			//Then check for ads that match the correct song format
			if (
				songClassificationInfo.AdNames.Contains(windowTitle)
				|| songClassificationInfo.AdKeywords.Contains(windowTitle)
			) {
				return false;
			}

			//If none of the prior tests matched, it's either a song or the classification info's incomplete
			return true;
		}

		public static (string artist, string songName) ParseWindowTitle(string windowTitle)
		{
			var separatorIndex = windowTitle.IndexOf(ArtistAndNameSeparator);
			if (separatorIndex >= 0)
			{
				return (
					artist: windowTitle.Substring(0, separatorIndex),
					songName: windowTitle.Substring(separatorIndex + ArtistAndNameSeparator.Length)
				);
			}
			else
			{
				return (
					artist: null,
					songName: windowTitle
				);
			}
		}
	}
}
