using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public abstract class LogHandler : IDisposable
	{
		//This class is highly mutable, as there needed to be a function to log an
		//initial set of messages (which were taken from a ListLogHandler), and passing
		//that into the constructor wouldn't work as that would involve calling an
		//abstract method from a base constructor, which is dangerous (and in this
		//case did cause errors). Instead, these messages are logged by external
		//code by calling public functions, which can obviously only be called by
		//that external code after all constructors have run.
		//Similarly, subscribing to the provider's LogMessageRecieved event in a
		//base constructor wouldn't work, as if a derived consrtuctor threw an error,
		//then the event would stay subscribed to, and so LogMessage would be called
		//*even though* the LogHandler wasn't sucessfully constructed.
		//Note: This can't be fixed by simply doing this stuff in the derived
		//constructors, as those classes shouldn't really be sealed, and so could
		//have further derived constructors. I tried using a Setup() method
		//and different constructors to be used publicly and by derived classes,
		//but that was messy and ugly.

		private ILogProvider _provider;
		public ILogProvider Provider {
			get => _provider;
			set {
				if (this._provider != null) this._provider.LogMessageReceived -= LogMessage;
				this._provider = value;
				if (this._provider != null) this._provider.LogMessageReceived += LogMessage;
			}
		}

		/// <summary>Calls LogMessages(). Provided for ease of use with a more functional style when constructing LogHandlers.</summary>
		public IEnumerable<(string message, LogType messageType)> MessagesToLog {
			set => LogMessages(value);
		}
		/// <summary>Calls LogMessages(). Provided for ease of use with a more functional style when constructing LogHandlers.</summary>
		public IEnumerable<(string fullMessage, LogType messageType)> FullMessagesToLog {
			set => LogFullMessages(value);
		}

		protected LogHandler() { }

		public abstract void LogMessage(string message, LogType messageType);
		public abstract void LogFullMessage(string fullMessage, LogType messageType);

		public void LogMessages(IEnumerable<(string message, LogType messageType)> messages) {
			foreach (var m in messages) LogMessage(m.message, m.messageType);
		}
		public void LogFullMessages(IEnumerable<(string fullMessage, LogType messageType)> fullMessages) {
			foreach (var m in fullMessages) LogFullMessage(m.fullMessage, m.messageType);
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
