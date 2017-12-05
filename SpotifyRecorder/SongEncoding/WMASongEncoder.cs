using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace SpotifyRec.SongEncoding
{
	public class WMASongEncoder : ISongEncoder
	{
		public string Extension => ".wma";

		public WMASongEncoder() { }

		public void Encode(Stream source, string outputPath, SongTags tags, byte[] reusedBuffer)
		{
			using (var reader = new WaveFileReader(source))
			{
				MediaFoundationEncoder.EncodeToWma(
					reader,
					outputPath
				);
			}
		}
	}
}
