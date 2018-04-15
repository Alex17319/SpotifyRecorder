using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Utils
{
	public static class AudioUtils
	{
		public static (int startTime, int duration) GetLongestSilenceInMilliseconds(int minMilliseconds, int bytesPerSecond, IEnumerable<byte> audio, int bitsPerSample)
		{

		}

		public static (int firstSample, int count) GetLongestSilenceInSamples(int minSamples, IEnumerable<byte> audio, int bitsPerSample)
		{

		}

		public static (int firstByte, int count) GetLongestSilenceInBytes(int minBytes, IEnumerable<byte> audio)
		{

		}
	}
}
