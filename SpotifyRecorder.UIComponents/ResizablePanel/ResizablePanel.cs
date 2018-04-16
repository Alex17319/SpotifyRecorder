using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignerSerVisAttribute = System.ComponentModel.DesignerSerializationVisibilityAttribute;
using DesignerSerVis = System.ComponentModel.DesignerSerializationVisibility;

namespace SpotifyRec.UI
{
	[Designer(typeof(ResizablePanelDesigner))]
	public partial class ResizablePanel : ContainerControl
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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


		public override Size MinimumSize {
			get => InnerPanel.MinimumSize + new Size(
				this.ResizerSizes.Horizontal,
				this.ResizerSizes.Vertical
			);
			set => InnerPanel.MinimumSize = value - new Size(
				this.ResizerSizes.Horizontal,
				this.ResizerSizes.Vertical
			);
		}

		/*
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override Color BackColor { get => Color.Empty; set { } }

		public Color ResizerColor {
			get => base.BackColor;
			set => base.BackColor = value;
		}


		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override bool AllowDrop { get => false; set { } }

		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override bool AutoScroll { get => false; set { } }
		
		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override Point AutoScrollOffset { get => Point.Empty; set { } }
		
		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override Image BackgroundImage { get => null; set { } }

		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override ImageLayout BackgroundImageLayout { get => default; set { } }
		/#*
		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override Font Font { get => default; set { } }
		*#/
		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override Color ForeColor { get => Color.Empty; set { } }

		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override RightToLeft RightToLeft { get => RightToLeft.Inherit; set { } }

		/// <summary>This property is not relevant to this control</summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerVis(DesignerSerVis.Hidden)]
		public override string Text { get => base.Text; set => base.Text = value; }
		*/

		private ResizeOperation _currentResizeOperation;
		public event EventHandler<PanelResizeEventArgs> ResizeStarted;
		public event EventHandler<PanelResizeEventArgs> ResizeProgressed;
		public event EventHandler<PanelResizeEventArgs> ResizeFinished;

		public ResizablePanel()
		{
			InitializeComponent();

			InnerPanel = new ResizedPanel(owner: this);

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
			var resizer = GetResizerAtPosition(e.Location);
			if (resizer != null) {
				_currentResizeOperation = new ResizeOperation(
					resizer: resizer,
					initialMousePos: e.Location,
					initialSize: this.Size,
					initialLocation: this.Location
				);
			}

			base.OnMouseDown(e);

			if (resizer != null) {
				this.ResizeStarted?.Invoke(this, new PanelResizeEventArgs(this.ClientRectangle, e.Location));
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			Console.WriteLine(e.Location);

			if (_currentResizeOperation == null)
			{
				var resizer = GetResizerAtPosition(e.Location);
				Console.WriteLine(resizer?.Side1 + ", " + resizer?.Side2);
				if (resizer != null) {
					Cursor.Current = resizer.Cursor;
				}
			}
			else
			{
				//Note: To add or subtract Points, you have to first cast one to a Size
				//Also Points are mutable structs

				Point mouseDelta = e.Location - (Size)_currentResizeOperation.InitialMousePos;
				//Set the size, depending on which sides are being resized. The top and left
				//sides need to have the reverse effect of the bottom and right sides.
				//Values below the minimum should just get treated as the minimum.
				if (_currentResizeOperation.Resizer.InvolvesSide(Side.Bottom)) this.Height = _currentResizeOperation.InitialSize.Height + mouseDelta.Y;
				if (_currentResizeOperation.Resizer.InvolvesSide(Side.Right )) this.Width  = _currentResizeOperation.InitialSize.Width  + mouseDelta.X;
				if (_currentResizeOperation.Resizer.InvolvesSide(Side.Top   )) this.Height = _currentResizeOperation.InitialSize.Height - mouseDelta.Y;
				if (_currentResizeOperation.Resizer.InvolvesSide(Side.Left  )) this.Width  = _currentResizeOperation.InitialSize.Width  - mouseDelta.X;

				Console.WriteLine(
					"this.Top: " + this.Top
					+ ", _currentResizeOperation.InitialLocation.Y: " + _currentResizeOperation.InitialLocation.Y
					+ ", mouseDelta: " + mouseDelta
				);

				//Set the location, depending on whether the top and/or left sides are being resized.
				//If the location can't be set (eg. because of docking), this should just get ignored.
				if (_currentResizeOperation.Resizer.InvolvesSide(Side.Top)) {
					var oldTop = this.Top;
					this.Top = _currentResizeOperation.InitialLocation.Y + mouseDelta.Y;
					//The position from where the InitialMousePos was calculated has moved, so to take that
					//into account we get ResizeOperation to update the InitialMousePos appropriately
					_currentResizeOperation.UpdateMouseCoordSystem(originDeltaX: 0, originDeltaY: this.Top - oldTop);
				}
				if (_currentResizeOperation.Resizer.InvolvesSide(Side.Left)) {
					var oldLeft = this.Left;
					this.Left = _currentResizeOperation.InitialLocation.X + mouseDelta.X;
					_currentResizeOperation.UpdateMouseCoordSystem(originDeltaX: this.Left - oldLeft, originDeltaY: 0);
				}
			}

			base.OnMouseMove(e);

			this.ResizeProgressed?.Invoke(this, new PanelResizeEventArgs(this.ClientRectangle, e.Location));
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			_currentResizeOperation = null;

			base.OnMouseUp(e);

			this.ResizeFinished?.Invoke(this, new PanelResizeEventArgs(this.ClientRectangle, e.Location));
		}

		public Resizer GetResizerAtPosition(Point point)
		{
			var c = CornerResizerSizes;
			if (point.Y <               c.TopLeft    .Height && point.X <              c.TopLeft    .Width) return new Resizer(Side.Top   , Side.Left );
			if (point.Y <               c.TopRight   .Height && point.X > this.Width - c.TopRight   .Width) return new Resizer(Side.Top   , Side.Right);
			if (point.Y > this.Height - c.BottomLeft .Height && point.X <              c.BottomLeft .Width) return new Resizer(Side.Bottom, Side.Left );
			if (point.Y > this.Height - c.BottomRight.Height && point.X > this.Width - c.BottomRight.Width) return new Resizer(Side.Bottom, Side.Right);

			if (point.Y <               ResizerSizes.Top   ) return new Resizer(Side.Top   , null);
			if (point.Y > this.Height - ResizerSizes.Bottom) return new Resizer(Side.Bottom, null);
			if (point.X <               ResizerSizes.Left  ) return new Resizer(Side.Left  , null);
			if (point.X > this.Width  - ResizerSizes.Right ) return new Resizer(Side.Right , null);

			return null;
		}

		public class Resizer
		{
			public Side Side1 { get; }
			public Side? Side2 { get; }

			public ResizeAxis Axis { get; }
			public Cursor Cursor { get; }

			public Resizer(Side side1, Side? side2)
			{
				if (side2 == side1) throw new InvalidOperationException(
					"The same side was specifide twice. Instead, null should be specified as the second side."
				);

				this.Side1 = side1;
				this.Side2 = side2;

				this.Axis = GetAxis(side1, side2);
				this.Cursor = ResizeAxis.ToCursor(Axis);
			}

			public bool InvolvesSide(Side side) => Side1 == side || Side2 == side;

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
							case null: return ResizeAxis.WE;
							default: throw InvalidSideValsEx(side1, side2);
						}
					case Side.Right: switch (side2) {
							case Side.Top: return ResizeAxis.NE_SW;
							case Side.Bottom: return ResizeAxis.NW_SE;
							case Side.Left: throw InvalidSidesCombEx(side1, side2);
							case Side.Right: throw InvalidSidesCombEx(side1, side2);
							case null: return ResizeAxis.WE;
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
			public Resizer Resizer { get; }
			public Point InitialMousePos { get; private set; }
			public Size InitialSize { get; }
			public Point InitialLocation { get; }

			public ResizeOperation(Resizer resizer, Point initialMousePos, Size initialSize, Point initialLocation)
			{
				this.Resizer = resizer;
				this.InitialMousePos = initialMousePos;
				this.InitialSize = initialSize;
				this.InitialLocation = initialLocation;
			}

			public void UpdateMouseCoordSystem(int originDeltaX, int originDeltaY)
			{
				this.InitialMousePos = new Point(
					x: this.InitialMousePos.X - originDeltaX,
					y: this.InitialMousePos.Y - originDeltaY
				);
			}
		}
	}
}
