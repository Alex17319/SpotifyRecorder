﻿using System;
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
		public DateTime TimeStarted { get; }
		public DateTime? TimeStopped { get; }
		public bool IsSong { get; }

		public TimeSpan? Duration => TimeStopped - TimeStarted;

		public bool HasStopped => TimeStopped != null;

		public SongInfo(string artist, string songName, DateTime timeStarted, DateTime? timeStopped, bool isSong)
		{
			this.Artist = artist;
			this.SongName = songName;
			this.TimeStarted = timeStarted;
			this.TimeStopped = timeStopped;
			this.IsSong = isSong;
		}

		public SongInfo(ISpotifySongInfo spotifySongInfo, DateTime timeStarted, DateTime? timeStopped, bool isSong)
			: this(spotifySongInfo.Artist, spotifySongInfo.SongName, timeStarted, timeStopped, isSong)
		{ }

		public SongInfo(string artist, string songName, DateTime timeStarted, DateTime? timeStopped, ISongClassifier adClassifier)
			: this(artist, songName, timeStarted, timeStopped, adClassifier.IsSong(artist, songName))
		{ }

		public SongInfo(ISpotifySongInfo spotifySongInfo, DateTime timeStarted, DateTime? timeStopped, ISongClassifier adClassifier)
			: this(spotifySongInfo.Artist, spotifySongInfo.SongName, timeStarted, timeStopped, adClassifier)
		{ }
	}
}