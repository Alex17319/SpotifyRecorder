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

	public delegate void Logger(string message, LogType messageType);
}
