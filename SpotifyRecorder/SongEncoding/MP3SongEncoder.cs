using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Lame;
using System.IO;

namespace SpotifyRec.SongEncoding
{
	public class MP3SongEncoder : ISongEncoder
	{
		public string Extension => ".mp3";

		public LAMEPreset? LamePreset { get; }
		public int? BitRate { get; }

		public MP3SongEncoder(LAMEPreset lamePreset)
		{
			this.LamePreset = lamePreset;
		}
		public MP3SongEncoder(int bitRate)
		{
			this.BitRate = bitRate;
		}

		public void Encode(Stream source, string outputPath, SongTags tags, byte[] reusedBuffer)
		{
			WaveFileReader reader = null;
			LameMP3FileWriter writer = null;

			try //Idk if using captures the original instance - clearer to just use try-finally
			{
				reader = new WaveFileReader(source);

				var id3 = new ID3TagData() {
					Artist = tags.Artist,
					Title = tags.Title,
				};

				if      (LamePreset != null) writer = new LameMP3FileWriter(outputPath, reader.WaveFormat, LamePreset.GetValueOrDefault(), id3);
				else if (BitRate    != null) writer = new LameMP3FileWriter(outputPath, reader.WaveFormat, BitRate   .GetValueOrDefault(), id3);
				else                         writer = new LameMP3FileWriter(outputPath, reader.WaveFormat, LAMEPreset.STANDARD           , id3);

				while (reader.Position < reader.Length)
				{
					int bytesRead = reader.Read(reusedBuffer, 0, reusedBuffer.Length);
					writer.Write(reusedBuffer, 0, bytesRead);
				}
			}
			finally
			{
				reader?.Dispose();
				writer?.Dispose();
			}
		}
	}
}
