using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class RecordedSongGroup
	{
		public string Path { get; }
		public Guid GroupID { get; }
		public TimeSpan Duration { get; }
		public WaveFormat WaveFormat { get; }

		public RecordedSongGroup(string path, Guid groupID, TimeSpan duration, WaveFormat waveFormat)
		{
			this.Path = path;
			this.GroupID = groupID;
			this.Duration = duration;
			this.WaveFormat = waveFormat;
		}
	}
}
