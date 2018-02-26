using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public abstract class LogHandler : IDisposable
	{
		public ILogProvider Provider { get; private set; }

		/// <param name="provider">Can be null</param>
		/// <param name="initialLogMessages">Can be null</param>
		public LogHandler(ILogProvider provider, IEnumerable<(string, LogType)> initialLogMessages)
		{
			AttachTo(provider);

			if (initialLogMessages != null) {
				foreach (var message in initialLogMessages) {
					LogMessage(message.Item1, message.Item2);
				}
			}
		}

		protected abstract void LogMessage(string message, LogType messageType);

		public void AttachTo(ILogProvider provider)
		{
			if (this.Provider != null) throw new InvalidOperationException($"{nameof(this.Provider)} has already been set");

			if (provider == null) return;

			this.Provider = provider;
			this.Provider.LogMessageReceived += LogMessage;
		}


		public static string ConstructFullMessage(string message, LogType messageType)
		{
			switch (messageType)
			{
				case LogType.Message:      return FormatMessage(messagePrefix: ""                        );
				case LogType.MinorMessage: return FormatMessage(messagePrefix: "Minor Message: "         );
				case LogType.Warning:      return FormatMessage(messagePrefix: "Warning: "               );
				case LogType.Error:        return FormatMessage(messagePrefix: "ERROR: "                 );
				default:                   return FormatMessage(messagePrefix: "[UNKNOWN MESSAGE TYPE]: ");
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
