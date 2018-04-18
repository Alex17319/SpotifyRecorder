using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Recording
{
	public class SongGroupSplitterHost
	{
		public ISettingProvider SettingProvider { get; }

		private readonly Logger _logger;

		private readonly List<SongGroupSplitter> _currentSplitters;

		public IReadOnlyCollection<RecordedSongGroup> PendingGroups => _pendingGroups;
		private readonly Queue<RecordedSongGroup> _pendingGroups;

		public ReadOnlyCollection<RecordedSongGroup> CompletedGroups { get; }
		private readonly List<RecordedSongGroup> _completedGroups;

		public ReadOnlyCollection<RecordedSong> CompletedSongs { get; }
		private readonly List<RecordedSong> _completedSongs;

		public event EventHandler<SongGroupSplitEventArgs> SongGroupSplit;

		public SongGroupSplitterHost(ISettingProvider settingProvider, Logger logger)
		{
			this.SettingProvider = settingProvider;
			this._logger = logger;

			this._currentSplitters = new List<SongGroupSplitter>();
			this._pendingGroups = new Queue<RecordedSongGroup>();
			this._completedGroups = new List<RecordedSongGroup>();
			this.CompletedGroups = this._completedGroups.AsReadOnly();
			this._completedSongs = new List<RecordedSong>();
			this.CompletedSongs = this._completedSongs.AsReadOnly();
		}

		/// <summary>
		/// Checks on and creates new async tasks, moving song groups from 'pending' to 'current',
		/// and from 'current' to 'completed', as appropriate.
		/// </summary>
		public void RefreshOngoingProcesses()
		{
			for (int i = _currentSplitters.Count - 1; i >= 0; i--)
			{
				var x = _currentSplitters[i];

				if (x.Completed)
				{
					_completedGroups.Add(x.Group);
					_completedSongs.AddRange(x.CompletedSongs);
					_currentSplitters.RemoveAt(i);

					_logger.Log($"Found and moved successfully split song group '{x.Group.GroupID}', notifying other objects");

					SongGroupSplit?.Invoke(this, new SongGroupSplitEventArgs(x));
				}

				if (x.Failed) {
					//An error has already been logged by AsyncProcessHelper so just discard the splitter
					_currentSplitters.RemoveAt(i);
				}
			}

			_currentSplitters.AddRange(
				_pendingGroups.Select(g => new SongGroupSplitter(g, this._logger, autostart: true))
			);

			_pendingGroups.Clear();
		}

		public void Enqueue(RecordedSongGroup group)
		{
			_logger.Log($"Enqueued song group '{group.GroupID}' for splitting.");

			_pendingGroups.Enqueue(group);
		}
	}
}
