using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.UI
{
	public struct CornerResizerSizes
	{
		public Size TopLeft     { get; }
		public Size TopRight    { get; }
		public Size BottomLeft  { get; }
		public Size BottomRight { get; }

		public int MaxTop    => Math.Max(TopLeft   .Height, TopRight   .Height);
		public int MaxBottom => Math.Max(BottomLeft.Height, BottomRight.Height);
		public int MaxRight  => Math.Max(TopRight  .Width , BottomRight.Width );
		public int MaxLeft   => Math.Max(TopLeft   .Width , BottomLeft .Width );

		public CornerResizerSizes(Size topLeft, Size topRight, Size bottomLeft, Size bottomRight)
		{
			this.TopLeft     = topLeft;
			this.TopRight    = topRight;
			this.BottomLeft  = bottomLeft;
			this.BottomRight = bottomRight;
		}
	}
}
