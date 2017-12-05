using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.SongEncoding
{
	public class WaveSongEncoder : ISongEncoder
	{
		public string Extension => ".wav";

		public WaveSongEncoder() { }

		public void Encode(Stream source, string outputPath, SongTags tags, byte[] reusedBuffer)
		{
			//If WaveFileWriter supported writing tags/metadata, we would need to decode and encode
			//the streams properly, rather than just copying the data across.
			//Unfortunately, it doesn't support tags.

			using (var destStream = File.OpenWrite(outputPath))
			{
				source.CopyTo(destStream);
			}
		}
	}
}
