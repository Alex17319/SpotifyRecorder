using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public abstract class LogHandler : IDisposable
	{
		bool _doneSetup;
		public ILogProvider Provider { get; private set; }
		private IEnumerable<(string, LogType)> _initialLogMessages;

		/// <param name="provider">Can be null</param>
		protected LogHandler(ILogProvider provider, IEnumerable<(string, LogType)> initialLogMessages, bool autoSetup)
		{
			this.Provider = provider;
			this._initialLogMessages = initialLogMessages;

			if (autoSetup) Setup();
		}

		protected abstract void LogMessage(string message, LogType messageType);

		/// <summary>
		/// Attaching to the provider, and logging the initial messages,
		/// both cannot be done until all derived constuctors have run:
		/// <para/>
		/// Attaching to the provider in the base constructor would mean
		/// that exceptions thrown in derived constructors would leave
		/// the event subscribed, which could later call LogMessage despite
		/// the derived constructor having failed to run.
		/// <para/>
		/// Logging the initial messages from the base constructor would
		/// call LogMessage before the derived constructor has had a chance
		/// to check for invalid arguments and set up variables.
		/// <para/>
		/// Because of this, this methods must be called at the end
		/// of the most derived constructor. To acheieve this when making
		/// derived classes, make a public constructor that calls this
		/// automatically (except if the derived class is abstract, then
		/// that'd be useless), and a protected constructor that
		/// only calls this if an 'autoSetup' argument is true.
		/// </summary>
		protected void Setup()
		{
			if (_doneSetup) return;
			_doneSetup = true;

			AttachTo(this.Provider);

			if (_initialLogMessages != null) {
				foreach (var message in _initialLogMessages) {
					LogMessage(message.Item1, message.Item2);
				}
			}
		}

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
