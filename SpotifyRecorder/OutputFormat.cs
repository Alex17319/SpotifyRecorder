using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public enum OutputFormat
	{
		MP3,
		WAV,
		WMA,
		AAC,
		AIFF,
		/// <summary>
		/// Not implemented - see <see cref="SpotifyRec.SongEncoding.FlacSongEncoder"/>
		/// </summary>
		FLAC,
	}
}
