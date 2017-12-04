using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public interface ISpotifySongInfo
	{
		string Artist { get; }
		string SongName { get; }
	}
}
