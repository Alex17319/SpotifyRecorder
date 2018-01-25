using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
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

		public SongGroupSplitterHost(ISettingProvider settingProvider, Logger logger)
		{
			this.SettingProvider = settingProvider;
			this._logger = logger;

			this._currentSplitters = new List<SongGroupSplitter>();
			this._pendingGroups = new Queue<RecordedSongGroup>();
			this._completedGroups = new List<RecordedSongGroup>();
			this.CompletedGroups = this._completedGroups.AsReadOnly();
		}

		/// <summary>
		/// Checks on and creates new async tasks, moving song groups from 'pending' to 'current',
		/// and from 'current' to 'completed', as appropriate.
		/// </summary>
		public void Refresh()
		{
			for (int i = _currentSplitters.Count - 1; i >= 0; i--)
			{
				var x = _currentSplitters[i];
				if (x.Completed) {
					_completedGroups.Add(x.Group);
					
				}
			}
		}
	}
}
