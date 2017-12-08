using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.UI
{
	public partial class ResizablePanel : ContainerControl
	{
		public ResizedPanel InnerPanel { get; }

		public Padding ResizerSizes {
			get => this.Padding;
			set => this.Padding = value;
		}
		public Padding InnerPadding {
			get => InnerPanel.Padding;
			set => InnerPanel.Padding = value;
		}

		public ResizableSides ResizableSides => (
			  (ResizerSizes.Top    > 0 ? ResizableSides.Top    : 0)
			| (ResizerSizes.Right  > 0 ? ResizableSides.Right  : 0)
			| (ResizerSizes.Bottom > 0 ? ResizableSides.Bottom : 0)
			| (ResizerSizes.Left   > 0 ? ResizableSides.Left   : 0)
		);

		private CornerResizerSizes _extraCornerResizerSizes;
		public CornerResizerSizes ExtraCornerResizerSizes {
			get => _extraCornerResizerSizes;
			set => _extraCornerResizerSizes = value;
		}

		public CornerResizerSizes CornerResizerSizes {
			get => new CornerResizerSizes(
				topLeft:     new Size(ResizerSizes.Left , ResizerSizes.Top   ) + ExtraCornerResizerSizes.TopLeft,
				topRight:    new Size(ResizerSizes.Right, ResizerSizes.Top   ) + ExtraCornerResizerSizes.TopRight,
				bottomLeft:  new Size(ResizerSizes.Left , ResizerSizes.Bottom) + ExtraCornerResizerSizes.BottomLeft,
				bottomRight: new Size(ResizerSizes.Right, ResizerSizes.Bottom) + ExtraCornerResizerSizes.BottomRight
			);
		}

		public Rectangle InnerRect {
			get => new Rectangle(
				InnerPanel.Location, //TODO: Test that padding doesn't affect things
				InnerPanel.Size
			);
		}

		public ResizablePanel()
		{
			InitializeComponent();

			InnerPanel = new ResizedPanel();

			this.SuspendLayout();
			InnerPanel.SuspendLayout();

			InnerPanel.Dock = DockStyle.Fill;

			this.Controls.Add(InnerPanel);

			InnerPanel.ResumeLayout();
			this.ResumeLayout();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			var resizer = GetResizerAtPosition(e.Location);
			System.Windows.Forms.Cursor.Current = Cursors.
		}

		public Resizer GetResizerAtPosition(Point point)
		{
			var c = CornerResizerSizes;
			if (point.Y < c.TopLeft    .Height && point.X < c.TopLeft    .Width) return new Resizer(Side.Top   , Side.Left );
			if (point.Y < c.TopRight   .Height && point.X > c.TopRight   .Width) return new Resizer(Side.Top   , Side.Right);
			if (point.Y < c.BottomLeft .Height && point.X > c.BottomLeft .Width) return new Resizer(Side.Bottom, Side.Left );
			if (point.Y < c.BottomRight.Height && point.X > c.BottomRight.Width) return new Resizer(Side.Bottom, Side.Right);

			if (point.Y < ResizerSizes.Top   ) return new Resizer(Side.Top   , null);
			if (point.Y > ResizerSizes.Bottom) return new Resizer(Side.Bottom, null);
			if (point.X < ResizerSizes.Left  ) return new Resizer(Side.Left  , null);
			if (point.X < ResizerSizes.Right ) return new Resizer(Side.Right , null);

			return null;
		}

		public class Resizer
		{
			public Side Side1 { get; }
			public Side? Side2 { get; }

			public Cursor Cursor { get; }

			public Resizer(Side side1, Side? side2)
			{
				if (side2 == side1) {
					throw new InvalidOperationException("Instead of specifying the same side twice, specify null as the second side");
				}

				this.Side1 = side1;
				this.Side2 = side2;

				this.Cursor = GetAxis(side1, side2);

			}

			public static ResizeAxis GetAxis(Side side1, Side? side2)
			{
				switch (side1) {
					case Side.Top: switch (side2) {
							case Side.Top: throw InvalidSidesCombEx(side1, side2);
							case Side.Bottom:  throw InvalidSidesCombEx(side1, side2);
							case Side.Left: return ResizeAxis.NW_SE;
							case Side.Right: return ResizeAxis.NE_SW;
							case null: return ResizeAxis.NS;
							default: throw InvalidSideValsEx(side1, side2);
						}
					case Side.Bottom: switch (side2) {
							case Side.Top: throw InvalidSidesCombEx(side1, side2);
							case Side.Bottom: throw InvalidSidesCombEx(side1, side2);
							case Side.Left: return ResizeAxis.NE_SW;
							case Side.Right: return ResizeAxis.NW_SE;
							case null: return ResizeAxis.NS;
							default: throw InvalidSideValsEx(side1, side2);
						}
					case Side.Left: switch (side2) {
							case Side.Top: return ResizeAxis.NW_SE;
							case Side.Bottom: return ResizeAxis.NE_SW;
							case Side.Left: throw InvalidSidesCombEx(side1, side2);
							case Side.Right: throw InvalidSidesCombEx(side1, side2);
							case null: return ResizeAxis.EW;
							default: throw InvalidSideValsEx(side1, side2);
						}
					case Side.Right: switch (side2) {
							case Side.Top: return ResizeAxis.NE_SW;
							case Side.Bottom: return ResizeAxis.NW_SE;
							case Side.Left: throw InvalidSidesCombEx(side1, side2);
							case Side.Right: throw InvalidSidesCombEx(side1, side2);
							case null: return ResizeAxis.EW;
							default: throw InvalidSideValsEx(side1, side2);
						}
					default: throw InvalidSideValsEx(side1, side2);
				}
			}

			public static Exception InvalidSidesCombEx(Side side1, Side? side2) => new Exception(
				$"Invalid resizer side combination: side1 = {side1}, side2 = {side2}"
			);

			public static Exception InvalidSideValsEx(Side side1, Side? side2) => new Exception(
				$"Invalid resizer side value(s): side1 = {side1}, side2 = {side2}"
			);
		}

		private class ResizeOperation
		{
			public ArrowDirection Side1;
			public ArrowDirection? Side2;

			public ResizeOperation()
			{

			}
		}
	}
}
