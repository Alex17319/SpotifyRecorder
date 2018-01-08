using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyRec.SongEncoding;

namespace SpotifyRec
{
	public class SettingManager : ISettingProvider
	{
		private readonly object _lock = new object();

		public event EventHandler AdNamesChanged;
		private string _adNames;
		public string AdNames {
			get => GetSetting(ref _adNames);
			set => SetSetting(ref _adNames, value, AdNamesChanged);
		}

		public event EventHandler AdKeywordsChanged;
		private string _adKeywords;
		public string AdKeywords {
			get => GetSetting(ref _adKeywords);
			set => SetSetting(ref _adKeywords, value, AdKeywordsChanged);
		}

		public event EventHandler SongNamesChanged;
		private string _songNames;
		public string SongNames {
			get => GetSetting(ref _songNames);
			set => SetSetting(ref _songNames, value, SongNamesChanged);
		}

		public event EventHandler OutputFormatChanged;
		private OutputFormat _outputFormat;
		public OutputFormat OutputFormat {
			get => GetSetting(ref _outputFormat);
			set => SetSetting(ref _outputFormat, value, OutputFormatChanged);
		}

		public event EventHandler OutputFolderChanged;
		private string _outputFolder;
		public string OutputFolder {
			get => GetSetting(ref _outputFolder);
			set => SetSetting(ref _outputFolder, value, OutputFolderChanged);
		}

		public event EventHandler TempFolderChanged;
		private string _tempFolder;
		public string TempFolder {
			get => GetSetting(ref _tempFolder);
			set => SetSetting(ref _tempFolder, value, TempFolderChanged);
		}

		public SongClassificationInfo SongClassificationInfo {
			get {
				lock (_lock) return new SongClassificationInfo(
					adNames: _adNames.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries),
					adKeywords: _adKeywords.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries),
					songNames: _songNames.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
					//Note: TextBox.Lines also splits the internal string into an array on-demand
					//source: https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/TextBoxBase.cs,37cabfde1449b18f
				);
			}
		}

		public ISongEncoder SongEncoder {
			get {
				lock (_lock)
				{
					switch (this._outputFormat)
					{
						case OutputFormat.MP3: return new MP3SongEncoder(NAudio.Lame.LAMEPreset.STANDARD);
						case OutputFormat.WAV: return new WaveSongEncoder();
						case OutputFormat.WMA: return new WMASongEncoder();
						case OutputFormat.AAC: return new AACSongEncoder();
						case OutputFormat.AIFF: return new AiffSongEncoder();
						case OutputFormat.FLAC:
							//return new FlacSongEncoder();
							throw new InvalidOperationException("Flac encoding is not currently supported.");
						default:
							throw new InvalidOperationException(
								$"Invalid {nameof(SpotifyRec.OutputFormat)} '{this._outputFormat}'"
							);
					}
				}
			}
		}



		public SettingManager()
		{
			
		}

		private T GetSetting<T>(ref T field)
		{
			lock (_lock)
			{
				return field;
			}
		}
		private void SetSetting<T>(ref T field, T value, EventHandler ev)
		{
			lock (_lock)
			{
				field = value;
				ev?.Invoke(this, EventArgs.Empty); //Note that all handlers will run inside the lock
			}
		}
	}
}
