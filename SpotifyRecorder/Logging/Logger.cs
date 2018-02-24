using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public enum LogType
	{
		Message,
		MinorMessage,
		Error,
		Warning,
	}

	/// <summary>
	/// Note: A logger may be called from different threads, so must be thread safe and keep messages in the correct order
	/// (or record messages from each thread in separate logs).
	/// </summary>
	public delegate void Logger(string message, LogType messageType);

	public static class LoggerExtensions
	{
		/// <summary>
		/// Logs a message of the specified type (defaults to <see cref="LogType.Message"/>),
		/// or does nothing if <paramref name="logger"/> is null
		/// </summary>
		public static void Log(this Logger logger, string message, LogType messageType = LogType.Message)
		{
			logger?.Invoke(message, messageType);
		}
	}
}
