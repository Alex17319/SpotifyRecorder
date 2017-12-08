using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.UI
{
	public struct ResizeAxis
	{
		/// <summary>North &lt;-&gt; south (vertical)</summary>
		public static readonly ResizeAxis NS = new ResizeAxis(1);
		/// <summary>East &lt;-&gt; west (horizontal)</summary>
		public static readonly ResizeAxis EW = new ResizeAxis(2);
		/// <summary>Northwest &lt;-&gt; southeast (diagonally down and right)</summary>
		public static readonly ResizeAxis NW_SE = new ResizeAxis(3);
		/// <summary>Northeast &lt;-&gt; southwest (diagonally down and left)</summary>
		public static readonly ResizeAxis NE_SW = new ResizeAxis(4);

		private int _value;

		private ResizeAxis(int value)
		{
			this._value = value;
		}
	}
}
