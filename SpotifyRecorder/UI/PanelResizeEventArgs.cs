using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.UI
{
	public class PanelResizeEventArgs
	{
		public Rectangle Rect { get; }
		public Point MousePos { get; }

		public PanelResizeEventArgs(Rectangle rect, Point mousePos)
		{
			this.Rect = rect;
			this.MousePos = mousePos;
		}
	}
}
