using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class SpotifyProcessManager
	{
		public Process CurrentSpotifyProcess {
			get {
				//If spotify wasn't found last time this was accessed, attempt to refresh.
				//Return null if it still can't be found
				if (_currentSpotifyProcess == null) SetSpotifyProcess(FindSpotifyProcess());
				return _currentSpotifyProcess;
			}
		}
		private Process _currentSpotifyProcess;

		private Logger _logger { get; }

		public SpotifyProcessManager(Logger logger)
		{
			this._logger = logger;

			//_currentSpotifyProcess = null;
			ForceManualRefresh();
		}

		public void ForceManualRefresh()
		{
			SetSpotifyProcess(FindSpotifyProcess());
		}

		private Process FindSpotifyProcess()
		{
			_logger.Log("Finding spotify process...");

			_logger.Log("Spotify processes: " +
				from process in Process.GetProcessesByName("Spotify")
				let name = process.ProcessName
				let id = process.Id
				let windowTitle = process.MainWindowTitle
				select $"{{name: {name}, id: {id}, windowTitle: {windowTitle}}}, "
			);
			var spotify = Process.GetProcessesByName("Spotify").FirstOrDefault(x => !string.IsNullOrEmpty(x.MainWindowTitle));
			if (spotify == null) _logger?.Log(
				"Could not find the Spotify process. Please ensure that Spotify is running.",
				LogType.Error
			);
			else _logger.Log("Found spotify process with process ID '" + spotify.Id + "'.");

			return spotify;
		}

		private void SetSpotifyProcess(Process newSpotifyProcess)
		{
			if (_currentSpotifyProcess != null)
			{
				_currentSpotifyProcess.Dispose();
				_currentSpotifyProcess.Exited -= OnProcessExit;
			}

			//Don't allow processes that have exited, as the exited event
			//will never fire so it will never automatically refresh again
			if (newSpotifyProcess?.HasExited == true) {
				newSpotifyProcess = null;
			}

			if (newSpotifyProcess != null)
			{
				newSpotifyProcess.Exited += OnProcessExit;
			}

			_currentSpotifyProcess = newSpotifyProcess;
		}

		private void OnProcessExit(object sender, EventArgs e)
		{
			SetSpotifyProcess(FindSpotifyProcess());
		}
	}
}
