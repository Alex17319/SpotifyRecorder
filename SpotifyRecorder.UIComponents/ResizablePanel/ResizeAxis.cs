using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.UI
{
	public struct ResizeAxis
	{
		/// <summary>North &lt;-&gt; south (vertical)</summary>
		public static readonly ResizeAxis NS = new ResizeAxis(1);
		/// <summary>West &lt;-&gt; east (horizontal)</summary>
		public static readonly ResizeAxis WE = new ResizeAxis(2);
		/// <summary>Northwest &lt;-&gt; southeast (diagonally down and right)</summary>
		public static readonly ResizeAxis NW_SE = new ResizeAxis(3);
		/// <summary>Northeast &lt;-&gt; southwest (diagonally down and left)</summary>
		public static readonly ResizeAxis NE_SW = new ResizeAxis(4);

		public int Value { get; }

		public bool InvolvesNS => this == NS || IsDiagonal;
		public bool InvolvesWE => this == WE || IsDiagonal;
		public bool IsDiagonal => this == NW_SE || this == NE_SW;

		private ResizeAxis(int value)
		{
			this.Value = value;
		}

		public override bool Equals(object obj) => obj is ResizeAxis axis && axis.Value == this.Value;
		public override int GetHashCode() => this.Value.GetHashCode();

		public static Cursor ToCursor(ResizeAxis axis)
		{
			if      (axis == NS   ) return Cursors.SizeNS;
			else if (axis == WE   ) return Cursors.SizeWE;
			else if (axis == NW_SE) return Cursors.SizeNWSE;
			else if (axis == NE_SW) return Cursors.SizeNESW;
			else throw new ArgumentException($"Invalid ResizeAxis (Value == {axis.Value}).", nameof(axis));
		}

		public static bool operator ==(ResizeAxis a, ResizeAxis b) => a.Value == b.Value;
		public static bool operator !=(ResizeAxis a, ResizeAxis b) => !(a == b);
	}
}
