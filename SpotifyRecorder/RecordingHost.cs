using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class RecordingHost
	{
		public SettingsHost SettingsHost { get; }

		public bool IsRecording => _currentSession != null;
		private RecordingSession _currentSession;

		public RecordingHost(SettingsHost settingsHost)
		{
			this.SettingsHost = settingsHost;


		}

		public void StartStopRecording()
		{
			if (IsRecording)
			{
				_currentSession.Dispose();
			}
			else
			{

			}
		}
	}
}
