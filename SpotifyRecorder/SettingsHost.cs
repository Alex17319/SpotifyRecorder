using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyRec.SongEncoding;
using System.Collections.Immutable;
using System.IO;

namespace SpotifyRec
{
	public class SettingsHost : ISettingProvider
	{
		private readonly object _lock = new object();

		public event EventHandler AdNamesChanged;
		private ImmutableList<string> _adNames;
		public ImmutableList<string> AdNames {
			get => GetSetting(ref _adNames);
			set => SetSetting(ref _adNames, value, AdNamesChanged);
		}

		public event EventHandler AdKeywordsChanged;
		private ImmutableList<string> _adKeywords;
		public ImmutableList<string> AdKeywords {
			get => GetSetting(ref _adKeywords);
			set => SetSetting(ref _adKeywords, value, AdKeywordsChanged);
		}

		public event EventHandler SongNamesChanged;
		private ImmutableList<string> _songNames;
		public ImmutableList<string> SongNames {
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
			get {
				Directory.CreateDirectory(_outputFolder);
				return GetSetting(ref _outputFolder);
			}
			set => SetSetting(ref _outputFolder, value, OutputFolderChanged);
		}

		public event EventHandler TempFolderChanged;
		private string _tempFolder;
		public string TempFolder {
			get {
				Directory.CreateDirectory(_tempFolder);
				return GetSetting(ref _tempFolder);
			}
			set => SetSetting(ref _tempFolder, value, TempFolderChanged);
		}

		public event EventHandler SongRefreshIntervalChanged;
		private int _songRefreshInterval;
		public int SongRefreshInterval {
			get => GetSetting(ref _songRefreshInterval);
			set => SetSetting(ref _songRefreshInterval, value, SongRefreshIntervalChanged);
		}

		public SongClassificationInfo SongClassificationInfo {
			get {
				lock (_lock) return new SongClassificationInfo(
					adNames: _adNames,
					adKeywords: _adKeywords,
					songNames: _songNames
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



		public SettingsHost(RawSettings raw)
		{
			this._adNames = raw.AdNames;
			this._adKeywords = raw.AdKeywords;
			this._songNames = raw.SongNames;
			this._outputFormat = raw.OutputFormat;
			this._outputFolder = raw.OutputFolder;
			this._tempFolder = raw.TempFolder;
			this._songRefreshInterval = raw.SongRefreshInterval;
		}

		public RawSettings ToRaw()
		{
			lock (_lock) {
				return new RawSettings(
					adNames: this.AdNames,
					adKeywords: this.AdKeywords,
					songNames: this.SongNames,
					outputFormat: this.OutputFormat,
					outputFolder: this.OutputFolder,
					tempFolder: this.TempFolder,
					songRefreshInterval: this.SongRefreshInterval
				);
			}
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
				T oldValue = field;
				field = value;

				//Note: only firing the event when the value actually changes seems to be the only way
				//to do bug-free synchronisation of values (eg. between the ui and a database). Otherwise,
				//this event would fire, then the synced object would handle it and fire it's own event, and
				//then some other code could go and update the value inside this class. That stops any kind of
				//'unsubscribe from the synced object while firing' or 'disable firing again while it's
				//currently firing' strategy from working as that'll produce bugs.
				bool equal = (
					oldValue == null && value == null
					|| oldValue != null && oldValue.Equals(value)
				);
				if (!equal) {
					ev?.Invoke(this, EventArgs.Empty);
					//Note that all handlers will run inside the lock (I *think* this is good, but idk)
				}
			}
		}

		public static IEnumerable<string> SplitIntoLines(string multilineText)
		{
			return multilineText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			//Note: TextBox.Lines also splits the internal string into an array on-demand
			//source: https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/TextBoxBase.cs,37cabfde1449b18f
		}


	}
}
