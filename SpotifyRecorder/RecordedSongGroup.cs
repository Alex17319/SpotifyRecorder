using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class RecordedSongGroup
	{
		public string Path { get; }
		public Guid GroupID { get; }
		public DateTime StartTime { get; }
		public TimeSpan Duration { get; }
		public DateTime EndTime => StartTime + Duration;
		public WaveFormat WaveFormat { get; }
		public ImmutableList<SongInfo> Songs { get; }

		public RecordedSongGroup(string path, Guid groupID, DateTime startTime, TimeSpan duration, WaveFormat waveFormat, ImmutableList<SongInfo> songs)
		{
			this.Path = path;
			this.GroupID = groupID;
			this.StartTime = startTime;
			this.Duration = duration;
			this.WaveFormat = waveFormat;
			this.Songs = songs;
		}
	}
}
