using SpotifyRec.Utils;
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
		private readonly List<SongGroupRecorder> _groupRecordings;
		public ReadOnlyCollection<SongGroupRecorder> GroupRecordings { get; }

		public string TempFolder { get; }
		public SpotifyProcessManager SpotifyProcessManager { get; }
		public SongClassificationInfo SongClassificationInfo { get; }
		public int SongRefreshInterval { get; }
		private readonly Logger _logger;

		public bool SessionClosed { get; private set; }

		public event EventHandler<SongGroupRecorder, EventArgs> GroupFinished;

		public RecordingSession(string tempFolder, SpotifyProcessManager spotifyProcessManager, SongClassificationInfo songClassificationInfo, int songRefreshInterval, Logger logger)
		{
			this._groupRecordings = new List<SongGroupRecorder>();
			this.GroupRecordings = this._groupRecordings.AsReadOnly();

			this.TempFolder = tempFolder;
			this.SpotifyProcessManager = spotifyProcessManager;
			this.SongClassificationInfo = songClassificationInfo;
			this.SongRefreshInterval = songRefreshInterval;
			this._logger = logger;

			StartNewGroupRecording();
		}

		private void StartNewGroupRecording()
		{
			var newGroup = new SongGroupRecorder(
				this.TempFolder,
				this.SpotifyProcessManager,
				this.SongClassificationInfo,
				this.SongRefreshInterval,
				this._logger
			);

			_groupRecordings.Add(
				newGroup
			);

			newGroup.GroupFinished += OnGroupFinished;
		}

		private void OnGroupFinished(SongGroupRecorder sender, EventArgs e)
		{
			sender.GroupFinished -= OnGroupFinished;

			this.GroupFinished.Fire(sender, e);

			StartNewGroupRecording();
		}

		//Why remove them? It's not really helpful
		//	public void ClearFinishedGroupRecordings()
		//	{
		//		for (int i = _groupRecordings.Count - 1; i >= 0; i--)
		//		{
		//			if (_groupRecordings[i].SplittingCompleted)
		//			{
		//				_groupRecordings[i].Dispose();
		//				_groupRecordings.RemoveAt(i);
		//			}
		//		}
		//	}

		public void CloseSession()
		{
			if (SessionClosed) return;

			var last = _groupRecordings.LastOrDefault();
			if (last != null) {
				last.GroupFinished -= OnGroupFinished;
				last.GroupFinished += (sender, e) => {
					this.GroupFinished.Fire(sender, e);
				};
				last.StopRecordingEarly();
			};

			SessionClosed = true;
		}

		public void Dispose()
		{
			CloseSession();
		}
	}
}
