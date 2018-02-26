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
		private readonly List<(string, LogType)> _list;
		public ReadOnlyCollection<(string, LogType)> List { get; }

		public ListLogHandler(ILogProvider provider = null, IEnumerable<(string, LogType)> initialLogMessages = null)
			: base(provider, initialLogMessages)
		{
			this._list = new List<(string, LogType)>();
			this.List = this._list.AsReadOnly();
		}

		protected override void LogMessage(string message, LogType messageType)
		{
			_list.Add(
				(ConstructFullMessage(message, messageType), messageType)
			);
		}
	}
}
