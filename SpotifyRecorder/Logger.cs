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
}
