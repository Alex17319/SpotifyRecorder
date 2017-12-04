using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpotifyRec
{
	public class SongConverter
	{
		public string OutputFolder { get; }
		public string TempFolder { get; }

		private Logger _logger;

		private Task _conversionTask;
		private object _lock = new object();

		public SongConverter(string outputFolder, string tempFolder, Logger logger)
		{
			this.OutputFolder = outputFolder;
			this.TempFolder = tempFolder;
			this._logger = logger;
		}

		public void ConvertIfDoneAsync()
		{
			lock (_lock)
			{
				if (TaskIsInProgress(_conversionTask)) return;
				_conversionTask = Task.Run((Action)ConvertSongs).ContinueWith(
					task => {
						if (task.Exception != null) {
							_logger?.Invoke(
								"An error occurred while converting songs in a separate thread:\r\n" + task.Exception,
								LogType.Error
							);
						}
					}
				);
			}
		}

		private void ConvertSongs()
		{
			
		}

		private IEnumerable<string> GetSongs()
		{
			
		}

		private static bool TaskIsInProgress(Task task)
		{
			return task != null && !task.IsCanceled && !task.IsCompleted && !task.IsFaulted;
		}
	}
}
