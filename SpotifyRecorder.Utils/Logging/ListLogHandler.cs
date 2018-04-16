using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public class ListLogHandler : LogHandler
	{
		private readonly List<(string fullMessage, LogType messageType)> _list;
		public ReadOnlyCollection<(string fullMessage, LogType messageType)> List { get; }

		public ListLogHandler()
		{
			this._list = new List<(string fullMessage, LogType messageType)>();
			this.List = this._list.AsReadOnly();
		}

		public override void LogMessage(string message, LogType messageType)
		{
			LogFullMessage(ConstructFullMessage(message, messageType), messageType);
		}

		public override void LogFullMessage(string fullMessage, LogType messageType)
		{
			_list.Add( (fullMessage, messageType) );
		}
	}
}
