using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Flac;

namespace SpotifyRec.SongEncoding
{
	[Obsolete("Not implemented - finding an easy way to encode to FLAC is difficult", error: true)]
	public class FlacSongEncoder : ISongEncoder
	{
		public string Extension => ".flac";

		public FlacSongEncoder()
		{

		}

		public void Encode(Stream source, string outputPath, SongTags tags, byte[] reusedBuffer)
		{
			
		}
	}
}
