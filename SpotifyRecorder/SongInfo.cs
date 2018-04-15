using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public struct SongInfo
	{
		public string Artist { get; }
		public string SongName { get; }
		public DateTime StartTime { get; }
		public DateTime? EndTime { get; }
		public bool IsSong { get; }

		public TimeSpan? Duration => EndTime - StartTime;

		public bool HasStopped => EndTime != null;

		public string CombinedName {
			get {
				if (Artist == null || SongName == null) return Artist ?? SongName;
				else return Artist + SpotifySongInfo.ArtistAndNameSeparator + SongName;
			}
		}

		public SongInfo(string artist, string songName, DateTime startTime, DateTime? endTime, bool isSong)
		{
			this.Artist = artist;
			this.SongName = songName;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.IsSong = isSong;
		}

		public SongInfo(ISpotifySongInfo spotifySongInfo, DateTime timeStarted, DateTime? timeStopped)
			: this(spotifySongInfo.Artist, spotifySongInfo.SongName, timeStarted, timeStopped, spotifySongInfo.IsSong)
		{ }
	}
}
