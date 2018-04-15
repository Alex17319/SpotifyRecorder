using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Gui;
using System.IO;
using System.Diagnostics;

namespace SpotifyRec
{
	//TODO: Fix problem where some dependency times out and stops recording after 10s of silence
	//(which will cause all the timings for when songs start and stop to be out of sync)

	public class AudioRecorder : IDisposable
	{
		public string OutputFolder { get; }
		public string RecordingName { get; }

		/// <summary>
		/// The output path, without an extension (as the extension changes while recording).
		/// </summary>
		public string OutputPath { get; }
		/// <summary>
		/// The extension currently appended to <see cref="OutputPath"/>.
		/// Can be ".wav-recording", ".wav-forcestopped", or ".wav".
		/// </summary>
		public string CurrentExtension { get; private set; }
		/// <summary>
		/// Returns <see cref="OutputPath"/> + <see cref="CurrentExtension"/>.
		/// </summary>
		public string FullOutputPath => OutputPath + CurrentExtension;

		private WasapiCapture _wasapiIn;
		private WaveFileWriter _wavOut;

		public bool HasStopped { get; private set; }
		public event EventHandler Stopped;

		public TimeSpan CurrentLength { get; private set; }

		public WaveFormat WaveFormat { get; }

		private Stopwatch _sampleDurationStopwatch;
		//Safe to use Stopwatch (which is from System.Diagnostics) in production code:
		//https://stackoverflow.com/questions/2805362/can-stopwatch-be-used-in-production-code

		public AudioRecorder(string outputFolder, string recordingName)
		{
			this.OutputFolder = outputFolder;
			this.RecordingName = recordingName;
			this.OutputPath = Path.Combine(this.OutputFolder, recordingName);
			this.CurrentExtension = ".wav-recording";

			//From original project:
			//	//	//Get Deivce
			//	//	MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
			//	//	MMDevice defaultAudioDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

			_wasapiIn = new WasapiLoopbackCapture(); //TODO: Check if WasapiCapture should/can be used instead
			_wasapiIn.DataAvailable += this.AudioDataAvailable;
			_wasapiIn.RecordingStopped += this.RecordingStopped;

			this.WaveFormat = _wasapiIn.WaveFormat;

			_wavOut = new WaveFileWriter(
				this.FullOutputPath,
				this.WaveFormat
			);

			_wasapiIn.StartRecording();

			_sampleDurationStopwatch = Stopwatch.StartNew();
		}

		private void AudioDataAvailable(object sender, WaveInEventArgs e)
		{
			_wavOut.Write(e.Buffer, 0, e.BytesRecorded);

			this.CurrentLength = TimeSpan.FromMilliseconds(
				_wavOut.Length / (_wavOut.WaveFormat.AverageBytesPerSecond/1000)
			);

			//TODO: FillInUncapturedSilence(e);

			//From original project:
			//	//	int sample_count = e.BytesRecorded / (waveIn.WaveFormat.BitsPerSample / 8);
			//	//	Single[] data = new Single[sample_count];
			//	//	for (int i = 0; i < sample_count; ++i)
			//	//	{
			//	//		data[i] = BitConverter.ToSingle(e.Buffer, i * 4);
			//	//	}
			//	//	
			//	//	int j = 0;
			//	//	Audio_Samples = new Double[sample_count / 2];
			//	//	for (int sample = 0; sample < data.Length; sample += 2)
			//	//	{
			//	//		Audio_Samples[j] = (Double)data[sample];
			//	//		Audio_Samples[j] += (Double)data[sample + 1];
			//	//		++j;
			//	//	}
			//	//	
			//	//	Data_Available = true;
			//	
			//	//	for (int i = 0; i < e.BytesRecorded; i += 8)
			//	//	{
			//	//		float sampleleft = BitConverter.ToSingle(e.Buffer, i);
			//	//		float sampleright = BitConverter.ToSingle(e.Buffer, i + 4);
			//	//		WaveformPainter.AddLeftRight(sampleleft, sampleright);
			//	//	}
		}

		/* TODO
		//If the audio from the computer is silent for about 10 seconds, either NAudio or Wasapi Capture
		//stops providing audio samples. This fixes this problem by:
		//	Detect if there is more than <varNameHere=5s> of silence in the clip.
		//	If so, check if the length of the current snippet is more than <varNameHere=0.2s> shorter
		//	than the time since the last snippet.
		//	If so, find the longest strech of silence within the current audio data snippet (this assumes
		//	that there is only ever one timeout within an audio data snippet, i.e. snippets are shorter than 20s).
		//	Then, insert the missing duration of silence into strech of silence (in the middle to be safe).
		private void FillInUncapturedSilence(WaveInEventArgs e)
		{
			var realtimeSampleDuration = _sampleDurationStopwatch.ElapsedMilliseconds;
			_sampleDurationStopwatch.Stop();

			e.

			_sampleDurationStopwatch.Restart();
		}
		*/

		private void RecordingStopped(object sender, StoppedEventArgs e)
		{
			_wasapiIn.Dispose();
			_wavOut.Dispose();

			File.Move(this.FullOutputPath, Path.ChangeExtension(this.FullOutputPath, ".wav"));
			this.CurrentExtension = ".wav";

			HasStopped = true;
			Stopped?.Invoke(this, EventArgs.Empty);
		}

		public void RequestStopRecording()
		{
			if (!HasStopped)
			{
				_wasapiIn.StopRecording(); //Doesn't stop instantly
			}
		}

		public void ForceStopRecording()
		{
			if (HasStopped) return;
			
			_wasapiIn.StopRecording();
			_wasapiIn.Dispose();
			_wavOut.Dispose();

			File.Move(this.FullOutputPath, Path.ChangeExtension(this.FullOutputPath, ".wav-forcestopped"));
			this.CurrentExtension = ".wav-forcestopped";

			this.HasStopped = true;
			Stopped?.Invoke(this, EventArgs.Empty);
		}

		public void Dispose()
		{
			ForceStopRecording();
		}
	}
}
