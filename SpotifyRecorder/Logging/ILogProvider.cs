using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Logging
{
	public interface ILogProvider
	{
		event Logger LogMessageReceived;

		//	bool HasBuffer { get; }
		//	
		//	/// <summary>If <see cref="HasBuffer"/> is false, equal to <see cref="Enumerable.Empty{TResult}"/></summary>
		//	IEnumerable<(string, LogType)> Buffer { get; }
		//	
		//	/// <summary>Does nothing if <see cref="HasBuffer"/> is false.</summary>
		//	void ClearBuffer();
		//	
		//	/// <summary>
		//	/// False if <see cref="HasBuffer"/> is false. The default depends on the class.
		//	/// If true, new log messages will not trigger the <see cref="LogMessageReceived"/> event.
		//	/// </summary>
		//	bool RerouteMesagesToBuffer { get; set; }
	}
}
