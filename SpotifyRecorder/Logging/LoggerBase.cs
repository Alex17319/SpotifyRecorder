using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public abstract class LoggerBase : IDisposable
	{
		public ILogProvider Provider { get; }

		public LoggerBase(ILogProvider provider)
		{
			this.Provider = provider ?? throw new ArgumentNullException(nameof(provider));

			this.Provider.LogMessageReceived += LogMessage;
		}

		protected abstract void LogFullMessage(string fullMessage, LogType messageType);

		private void LogMessage(string message, LogType messageType)
		{
			switch (messageType)
			{
				case LogType.Message:      LogFullMessage(FormatMessage(""                        ), messageType); break;
				case LogType.MinorMessage: LogFullMessage(FormatMessage("Minor Message: "         ), messageType); break;
				case LogType.Warning:      LogFullMessage(FormatMessage("Warning: "               ), messageType); break;
				case LogType.Error:        LogFullMessage(FormatMessage("ERROR: "                 ), messageType); break;
				default:                   LogFullMessage(FormatMessage("[UNKNOWN MESSAGE TYPE]: "), messageType); break;
			}

			string FormatMessage(string messagePrefix)
			{
				return "@" + DateTime.Now.ToString("HH:mm:ss.fff") + ": " + messagePrefix + message;
			}
		}

		public virtual void Dispose()
		{
			this.Provider.LogMessageReceived -= LogMessage;
		}
	}
}
