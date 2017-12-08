using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.UI
{
	[Flags]
	public enum ResizableSides
	{
		None = 0,
		Top = 1<<0,
		Right = 1<<1,
		Bottom = 1<<2,
		Left = 1<<3,
	}
}
