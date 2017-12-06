using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class RecordingSession : IDisposable
	{
		private readonly List<SongGroupRecording> _groupRecordings;
		public ReadOnlyCollection<SongGroupRecording> GroupRecordings { get; }

		public bool AllGroupsDoneSplitting {
			get => GroupRecordings.All(x => x.SplittingCompleted);
		}

		public string TempFolder { get; }
		public SpotifyProcessManager SpotifyProcessManager { get; }
		public SongClassificationInfo SongClassificationInfo { get; }
		public int SongRefreshInterval { get; }
		private readonly Logger _logger;

		private int _nextGroupNumber;

		public RecordingSession(string tempFolder, SpotifyProcessManager spotifyProcessManager, SongClassificationInfo songClassificationInfo, int songRefreshInterval, Logger logger)
		{
			this._groupRecordings = new List<SongGroupRecording>();
			this.GroupRecordings = this._groupRecordings.AsReadOnly();

			this.TempFolder = tempFolder;
			this.SpotifyProcessManager = spotifyProcessManager;
			this.SongClassificationInfo = songClassificationInfo;
			this.SongRefreshInterval = songRefreshInterval;
			this._logger = logger;

			this._nextGroupNumber = 1;

			StartNewGroupRecording();
		}

		private void StartNewGroupRecording()
		{
			var newGroup = new SongGroupRecording(
				this.TempFolder,
				_nextGroupNumber,
				this.SpotifyProcessManager,
				this.SongClassificationInfo,
				this.SongRefreshInterval,
				this._logger
			);

			_nextGroupNumber++;

			_groupRecordings.Add(
				newGroup
			);

			newGroup.GroupFinished += OnGroupFinished;
		}

		private void OnGroupFinished(object sender, EventArgs e)
		{
			((SongGroupRecording)sender).GroupFinished -= OnGroupFinished;

			ClearFinishedGroupRecordings();

			StartNewGroupRecording();
		}

		public void ClearFinishedGroupRecordings()
		{
			for (int i = _groupRecordings.Count - 1; i >= 0; i--)
			{
				if (_groupRecordings[i].SplittingCompleted)
				{
					_groupRecordings[i].Dispose();
					_groupRecordings.RemoveAt(i);
				}
			}
		}

		public void CloseSession()
		{
			var last = _groupRecordings.LastOrDefault();
			if (last != null) {
				last.GroupFinished -= OnGroupFinished;
				last.GroupFinished += delegate { ClearFinishedGroupRecordings(); };
				last.StopRecordingEarly();
			};
		}

		public void Dispose()
		{
			CloseSession();
		}
	}
}
