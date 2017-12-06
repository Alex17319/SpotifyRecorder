using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyRec.SongEncoding;

namespace SpotifyRec
{
	public interface ISettingProvider
	{
		SongClassificationInfo SongClassificationInfo { get; }
		ISongEncoder SongEncoder { get; }
	}
}
