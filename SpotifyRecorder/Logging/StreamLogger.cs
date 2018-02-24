using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public class StreamLogger : LoggerBase
	{
		public StreamWriter StreamWriter { get; }

		public StreamLogger(ILogProvider provider, StreamWriter streamWriter) : base(provider)
		{
			this.StreamWriter = streamWriter ?? throw new ArgumentNullException(nameof(streamWriter));
		}

		protected override void LogFullMessage(string fullMessage, LogType messageType)
		{
			Console.WriteLine("Logging message \"" + fullMessage + "\" to disk");
			StreamWriter.Write(fullMessage + Environment.NewLine);
		}

	}
}
