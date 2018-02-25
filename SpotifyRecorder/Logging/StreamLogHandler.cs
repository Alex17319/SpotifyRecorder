using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public class StreamLogHandler : LogHandler
	{
		public StreamWriter StreamWriter { get; }

		public StreamLogHandler(StreamWriter streamWriter, ILogProvider provider = null) : base(provider)
		{
			this.StreamWriter = streamWriter ?? throw new ArgumentNullException(nameof(streamWriter));
		}

		protected override void LogFullMessage(string fullMessage, LogType messageType)
		{
			Console.WriteLine("Logging message \"" + fullMessage + "\" to disk");
			StreamWriter.WriteLine(fullMessage);

			//If we don't flush the internal buffer of the StreamWriter then it's possible that
			//nothing will be written to disk until it get's disposed (which flushes it automatically).
			//So people can view live updates to the log file, it needs to be flushed regularly.
			//We could use AutoFlush, but that sounds like it flushes after every character,
			//and as the StreamWriter is mutable, external code could set it to false.
			//Instead, just call Flush() after each write, which only flushes it after each line
			//instead of every character.
			StreamWriter.Flush();
		}

		public override void Dispose()
		{
			base.Dispose();

			this.StreamWriter.Dispose();
		}
	}
}
