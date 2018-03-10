using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class SongGroupSplitEventArgs : EventArgs
	{
		public SongGroupSplitter Splitter { get; }

		public SongGroupSplitEventArgs(SongGroupSplitter splitter)
		{
			this.Splitter = splitter;
		}
	}
}
