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
	public class AiffSongEncoder : ISongEncoder
	{
		public string Extension => ".aif";

		public AiffSongEncoder() { }

		public void Encode(Stream source, string outputPath, SongTags tags, byte[] reusedBuffer)
		{
			using (var reader = new WaveFileReader(source))
			using (var writer = new AiffFileWriter(outputPath, reader.WaveFormat))
			{
				while (reader.Position < reader.Length)
				{
					int bytesRead = reader.Read(reusedBuffer, 0, reusedBuffer.Length);
					writer.Write(reusedBuffer, 0, bytesRead);
				}
			}
		}
	}
}
