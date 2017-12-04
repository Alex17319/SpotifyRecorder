using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public static class MP3Duration
	{
		public static TimeSpan GetTotalDuration(string mp3Path)
		{
			return GetTotalMilliseconds_Fast(mp3Path);
		}

		//Fast, low memory method that might not work or could be unreliable
		//Eg. I don't know what units it uses
		private static TimeSpan GetTotalMilliseconds_Fast(string mp3Path)
		{
			//Adapted from https://stackoverflow.com/a/13269914/4149474 by Daniel Mošmondor

			double duration = 0.0;
			using (FileStream fs = File.OpenRead(mp3Path))
			{
				Mp3Frame frame = Mp3Frame.LoadFromStream(fs);
				//No idea what this was for
				//	if (frame != null)
				//	{
				//		_sampleFrequency = (uint)frame.SampleRate;
				//	}
				while (frame != null)
				{
					//According to the comments there's no need to multiply by 2 or 4 (will have to test though)
					//	if (frame.ChannelMode == ChannelMode.Mono)
					//	{
					//		duration += (double)frame.SampleCount * 2.0 / (double)frame.SampleRate;
					//	}
					//	else
					//	{
					//		duration += (double)frame.SampleCount * 4.0 / (double)frame.SampleRate;
					//	}

					duration += (double)frame.SampleCount / (double)frame.SampleRate;
					frame = Mp3Frame.LoadFromStream(fs);
				}
			}
			return TimeSpan.FromSeconds(duration); //This is a guess - have to test to find out what the actual units are
		}

		private static TimeSpan GetTotalMilliseconds_Safe(string mp3Path)
		{
			Mp3FileReader reader = new Mp3FileReader(mp3Path);
			return reader.TotalTime;
		}
	}
}
