using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec
{
	public class SongTracker : IDisposable
	{
		public int MaxSongs { get; }
		public ReadOnlyCollection<SongInfo> Songs { get; }
		private readonly List<SongInfo> _songs;

		public event EventHandler<SongChangeEventArgs> SongChanged;

		public SongInfo? LastSong => _songs.Count == 0 ? (SongInfo?)null : _songs[_songs.Count - 1];
		public SongInfo? CurrentSong => LastSong?.HasStopped == false ? LastSong : null;

		public SpotifyProcessManager SpotifyProcessManager { get; }
		public SongClassificationInfo SongClassificationInfo { get; }

		public int RefreshInterval { get; }

		private readonly Logger _logger;

		private string _oldWindowTitle;

		private Timer refreshTimer;

		public TrackState State { get; private set; }

		public enum TrackState
		{
			Unused,
			Tracking,
			Finished,
		}

		public SongTracker(SpotifyProcessManager spotifyProcessManager, SongClassificationInfo songClassificationInfo, int refreshInterval, Logger logger, int maxSongs = -1)
		{
			if (maxSongs >= 0 && maxSongs <= 10) {
				throw new ArgumentOutOfRangeException(
					nameof(maxSongs),
					maxSongs,
					"To guarantee correctness of current and any future internal functionality, "
					+ nameof(maxSongs) + " cannot be between 0 and 10 inclusive"
				);
			}

			this.MaxSongs = maxSongs;

			this._songs = new List<SongInfo>();
			this.Songs = _songs.AsReadOnly();

			this.SpotifyProcessManager = spotifyProcessManager;
			this.SongClassificationInfo = songClassificationInfo;

			this.RefreshInterval = refreshInterval;

			this._logger = logger;

			this.State = TrackState.Unused;
		}

		public void StartTracking()
		{
			switch (this.State)
			{
				case TrackState.Unused:
					this._oldWindowTitle = SpotifyProcessManager.CurrentSpotifyProcess?.MainWindowTitle;
					this.refreshTimer = new Timer { Interval = this.RefreshInterval };
					this.refreshTimer.Tick += this.RefreshTimer_Tick;
					this.refreshTimer.Start();

					this.State = TrackState.Tracking;
					break;

				case TrackState.Tracking:
					break;

				case TrackState.Finished:
					throw new InvalidOperationException("Cannot start tracking again once stopped");
			}
		}

		private void RefreshTimer_Tick(object sender, EventArgs e)
		{
			CheckIfSongChanged();
		}

		private void CheckIfSongChanged()
		{
			Process spotify = SpotifyProcessManager.CurrentSpotifyProcess;
			string newWindowTitle = spotify?.MainWindowTitle;

			if (_oldWindowTitle != newWindowTitle)
			{
				_logger.Log($"Song changed: _oldWindowTitle = '{_oldWindowTitle}', newWindowTitle = '{newWindowTitle}'.");
				var oldSong = LastSong;
				UpdateListWithNewSong(newWindowTitle: newWindowTitle);
				var newSong = LastSong;

				_oldWindowTitle = newWindowTitle;

				SongChanged?.Invoke(this, new SongChangeEventArgs(oldSong, newSong));
			}
		}

		private void UpdateListWithNewSong(string newWindowTitle)
		{
			//Set finish time in last song
			if (CurrentSong != null) //If there is a last song and it doesn't have a finish time
			{
				SongInfo curSong = CurrentSong.GetValueOrDefault();

				_songs[_songs.Count - 1] = new SongInfo(
					artist: curSong.Artist,
					songName: curSong.SongName,
					startTime: curSong.StartTime,
					endTime: DateTime.Now,
					isSong: curSong.IsSong
				);
			}

			//Add the new song
			if (!string.IsNullOrEmpty(newWindowTitle)) //Don't add a song when Spotify isn't running (or similar situations)
			{
				_songs.Add(
					new SongInfo(
						spotifySongInfo: new SpotifySongInfo(newWindowTitle, this.SongClassificationInfo),
						timeStarted: DateTime.Now,
						timeStopped: null
					)
				);
			};

			//Remove the first song if MaxSongs has been reached
			if (_songs.Count > MaxSongs) {
				_songs.RemoveAt(0); //Inefficient but I can't think of a more efficient EASY way to do this
			}
		}

		public void FinishTracking()
		{
			if (this.State == TrackState.Finished) return;

			this.refreshTimer.Stop();
			this.refreshTimer.Dispose();
			this.refreshTimer.Tick -= RefreshTimer_Tick;

			this.State = TrackState.Finished;
		}

		public void Dispose()
		{
			FinishTracking();
		}
	}
}
