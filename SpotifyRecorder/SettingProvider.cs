/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyRec.SongEncoding;

namespace SpotifyRec
{
	public class SettingProvider : ISettingProvider
	{
		private readonly object _lock = new object();

		private SongClassificationInfo _songClassificationInfo;
		public SongClassificationInfo SongClassificationInfo { get { lock (_lock) return _songClassificationInfo; } }

		private ISongEncoder _songEncoder;
		public ISongEncoder SongEncoder { get { lock (_lock) return _songEncoder; } }

		public SettingProvider()
		{

		}
	}
}

//*/