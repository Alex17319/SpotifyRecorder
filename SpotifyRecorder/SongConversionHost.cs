using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NAudio;
using NAudio.Wave;
using NAudio.Lame;
using System.Text.RegularExpressions;
using NAudio.Vorbis;
using NAudio.Flac;
using SpotifyRec.SongEncoding;

namespace SpotifyRec
{
	public class SongConversionHost
	{
		public ISettingProvider SettingProvider { get; }

		private Logger _logger;

		private SongBatchConverter _currentConverter;

		public IReadOnlyCollection<RecordedSong> PendingSongs => _pendingSongs;
		private readonly Queue<RecordedSong> _pendingSongs;

		public ReadOnlyCollection<ConvertedSong> CompletedSongs { get; }
		private readonly List<ConvertedSong> _completedSongs;

		public SongConversionHost(ISettingProvider settingProvider, Logger logger)
		{
			this.SettingProvider = settingProvider;
			this._logger = logger;

			this._pendingSongs = new Queue<RecordedSong>();
			this._completedSongs = new List<ConvertedSong>();
			this.CompletedSongs = this._completedSongs.AsReadOnly();
		}

		/// <summary>
		/// If the current conversion batch has completed (and is not null), updates the completed songs list.
		/// Then, if the current conversion batch has completed or is null, starts converting a new batch of pending songs
		/// </summary>
		public void ContinueIfBatchCompleted()
		{
			if (_currentConverter != null && _currentConverter.Completed)
			{
				_completedSongs.AddRange(
					_currentConverter.Songs.Select(
						x => new ConvertedSong(
							songInfo: x.SongInfo,
							tempPath: x.TempPath,
							outputPath: _currentConverter.GetDestPath(x)
						)
					)
				);
			}

			_currentConverter = new SongBatchConverter(
				songs: new List<RecordedSong>(_pendingSongs),
				outputFolder: SettingProvider.OutputFolder,
				songEncoder: SettingProvider.SongEncoder,
				logger: _logger
			);
		}
	}
}
