using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SpotifyRec.UI
{
	[Designer(typeof(UniaxualResizePanelDesigner))]
	public partial class UniaxualResizePanel : UserControl
	{
		private Orientation _resizeDir;
		[Category("UniaxualResizePanel")]
		[Description("The direction in which the panel can be resized")]
		public Orientation ResizeDir {
			get => _resizeDir;
			set {
				var oldValue = ResizeDir;
				if (value == oldValue) return;

				_resizeDir = value;
				UpdateLayout();

				ResizeDirChanged?.Invoke(this, new ValueChangeEventArgs<Orientation>(oldValue, value));
			}
		}
		public event EventHandler<ValueChangeEventArgs<Orientation>> ResizeDirChanged;

		private bool _liveResize = true;
		[Category("UniaxualResizePanel")]
		[Description("Whether to update the size while the resizer bar is being dragged, or wait until the user releases it")]
		public bool LiveResize {
			get => _liveResize;
			set {
				var oldValue = LiveResize;
				if (value == oldValue) return;

				_liveResize = value;

				if (oldValue) _splitter.SplitterMoving -= OnResizerMoved;
				else          _splitter.SplitterMoved  -= OnResizerMoved;
				if (value)    _splitter.SplitterMoving += OnResizerMoved;
				else          _splitter.SplitterMoved  += OnResizerMoved;

				LiveResizeChanged?.Invoke(this, new ValueChangeEventArgs<bool>(oldValue, value));
			}
		}
		public event EventHandler<ValueChangeEventArgs<bool>> LiveResizeChanged;

		private int _resizerThickness = 3;
		[Category("UniaxualResizePanel")]
		[Description("The thickness of the resizer bar")]
		public int ResizerThickness {
			get => _resizerThickness;
			set {
				var oldValue = ResizerThickness;
				if (value == oldValue) return;

				_resizerThickness = value;
				UpdateLayout();

				ResizerThicknessChanged?.Invoke(this, new ValueChangeEventArgs<int>(oldValue, value));
			}
		}
		public event EventHandler<ValueChangeEventArgs<int>> ResizerThicknessChanged;

		private int _maxExpandStep = 1000;
		[Category("UniaxualResizePanel")]
		[Description("The maximum amount by which the control can be expanded in a single drag (regardless of LiveResize)")]
		public int MaxExpandStep {
			get => _maxExpandStep;
			set {
				var oldValue = MaxExpandStep;
				if (value == oldValue) return;

				_maxExpandStep = value;
				UpdateLayout();

				MaxExpandStepChanged?.Invoke(this, new ValueChangeEventArgs<int>(oldValue, value));
			}
		}
		public event EventHandler<ValueChangeEventArgs<int>> MaxExpandStepChanged;

		[Category("UniaxualResizePanel")]
		[Description("The minimum size of the area inside the control")]
		public int MinSize {
			get => Disorient(this.MinimumSize).ResizeAxisSize - this.ResizerThickness;
			set {
				var oldValue = MinSize;
				if (value == oldValue) return;

				this.MinimumSize = Orient(
					resizeAxis: value + this.ResizerThickness,
					otherAxis: Disorient(this.MinimumSize).OtherAxisSize
				);

				MinSizeChanged?.Invoke(this, new ValueChangeEventArgs<int>(oldValue, value));
			}
		}
		public event EventHandler<ValueChangeEventArgs<int>> MinSizeChanged;

		[Category("UniaxualResizePanel")]
		[Description("The colour of the resizer bar")]
		public Color ResizerBackColor {
			get => _splitter.BackColor;
			set => _splitter.BackColor = value;
		}
		public event EventHandler ResizerBackColorChanged {
			add    => _splitter.BackColorChanged += value;
			remove => _splitter.BackColorChanged -= value;
		}

		public override Color BackColor {
			get => base.BackColor;
			set {
				if (value == BackColor) return;

				base.BackColor = value;
				_outerPanel.BackColor = value;
				_innerPanel.BackColor = value;
			}
		}

		private readonly Panel _outerPanel;
		private readonly Panel _innerPanel;
		private readonly Splitter _splitter;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Panel InnerPanel => _innerPanel;

		public UniaxualResizePanel()
		{
			InitializeComponent();

			_outerPanel = new Panel();
			_innerPanel = new Panel();
			_splitter = new Splitter();

			SuspendLayout();
			_outerPanel.SuspendLayout();
			_innerPanel.SuspendLayout();
			_splitter.SuspendLayout();

			_outerPanel.Name = "OuterPanel";
			_outerPanel.TabIndex = 0;
			_outerPanel.Location = new Point(0, 0);
			_outerPanel.Size = new Size(50, 50);
			//this.Size + new Size(ExpandBorderSize, ExpandBorderSize)

			_innerPanel.Name = "InnerPanel";
			_innerPanel.TabIndex = 0;
			_innerPanel.Dock = DockStyle.Top;
			_innerPanel.Location = new Point(0, 0);
			_innerPanel.Size = new Size(50, 50);
			//this.Size - new Size(
			//	resizeDir == Orientation.Horizontal ? resizerThickness : 0,
			//	resizeDir == Orientation.Vertical   ? resizerThickness : 0
			//);

			_splitter.Name = "Splitter";
			_splitter.TabIndex = 0;
			_splitter.Dock = DockStyle.Top;
			_splitter.Size = new Size(3, 3);

			_outerPanel.Controls.Add(_innerPanel);
			_outerPanel.Controls.Add(_splitter);
			this.Controls.Add(_outerPanel);

			_outerPanel.BringToFront();
			_innerPanel.BringToFront();
			_splitter.BringToFront();

			//Default to LiveResize = true. To make sure that the splitter moved/moving event is
			//subscribed to correctly, ensure that the value of LiveResize changes (otherwise the
			//subscription code is skipped) by first setting it to false.
			this.LiveResize = false;
			this.LiveResize = true;

			_innerPanel.BackColorChanged += delegate
			{
				//Change each object's colour individually to avoid changing the _innerPanel's back colour,
				//which would risk an infinite loop - i.e. change color -> event fires -> handle -> change color ...
				base.BackColor = _innerPanel.BackColor;
				_outerPanel.BackColor = _innerPanel.BackColor;
			};

			//	//Behave as expected when the inner panel is resized (mainly in the designer)
			//	_innerPanel.SizeChanged += delegate
			//	{
			//		OnResizerMoved(
			//			this,
			//			new SplitterEventArgs(
			//				x: _splitter.Left,
			//				y: _splitter.Top,
			//				splitX: _splitter.Location.X,
			//				splitY: _splitter.Location.Y
			//			)
			//		);
			//	};
			//This didn't work properly for some reason
			//Instead, just don't allow the inner panel to be resized
			//	_innerPanel.SizeChanged += delegate {
			//		UpdateLayout();
			//	};
			//I think this also had problems (probably due to recursion)
			//Instead, just ignore this issue for now (maybe create a separate class for the InnerPanel,
			//with properties hidden from the designer, at some point).

			_innerPanel.ResumeLayout(performLayout: false);
			_splitter.ResumeLayout(performLayout: false);
			_outerPanel.ResumeLayout(performLayout: false);
			this.ResumeLayout(performLayout: false);

			// --- Testing ---
			//	_outerPanel.BackColor = Color.Yellow;
			//	_innerPanel.BackColor = Color.Red;
			//	_splitter.BackColor = Color.Green;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			UpdateLayout();
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			UpdateLayout();
		}

		private void UpdateLayout()
		{
			//Console.WriteLine("Updating layout\r\n" + new StackTrace().ToString());

			SuspendLayout();
			_outerPanel.SuspendLayout();
			_innerPanel.SuspendLayout();
			_splitter.SuspendLayout();

			//this.Size = new Size(100, 100);

			UpdateOuterPanelSize();

			_innerPanel.Dock = ResizeDir == Orientation.Vertical ? DockStyle.Top : DockStyle.Left;
			_innerPanel.Size = this.Size - Orient(new DisorientedSize(ResizerThickness, 0));

			_splitter.Dock = _innerPanel.Dock;
			_splitter.Size = Orient(new DisorientedSize(ResizerThickness, 0)); //Other axis set by dock system
			_splitter.MinSize = this.MinSize;
			_splitter.MinExtra = 0;

			//this.Size = new Size(200, 200);

			_innerPanel.ResumeLayout();
			_splitter.ResumeLayout();
			_outerPanel.ResumeLayout();
			this.ResumeLayout();
		}

		private void UpdateOuterPanelSize()
		{
			_outerPanel.Size = this.Size + Orient(new DisorientedSize(MaxExpandStep, 0));
		}

		private void OnResizerMoved(object sender, SplitterEventArgs e)
		{
			//Console.WriteLine($"Resizer moved to ({e.SplitX}, {e.SplitY}), mouse = ({e.X}, {e.Y})");

			this.Size = Orient(
				resizeAxis: Disorient(e.SplitX, e.SplitY).ResizeAxisSize + Disorient(_splitter.Size).ResizeAxisSize,
				otherAxis: Disorient(_innerPanel.Size).OtherAxisSize
			);

			this._splitter.SplitPosition = Disorient(e.SplitX, e.SplitY).ResizeAxisSize;

			UpdateOuterPanelSize();
		}



		public Size Orient(DisorientedSize disorientedSize)
		{
			return disorientedSize.Orient(this.ResizeDir);
		}

		public Size Orient(int resizeAxis, int otherAxis)
		{
			return new DisorientedSize(resizeAxis, otherAxis).Orient(this.ResizeDir);
		}
		
		public DisorientedSize Disorient(Size size)
		{
			return DisorientedSize.Disorient(size, this.ResizeDir);
		}

		public DisorientedSize Disorient(int width, int height)
		{
			return DisorientedSize.Disorient(new Size(width, height), this.ResizeDir);
		}

		/// <summary>
		/// Utility class, used to easily calculate sizes depending on the <see cref="ResizeDir"/>.
		/// </summary>
		public struct DisorientedSize
		{
			public int ResizeAxisSize { get; }
			public int OtherAxisSize { get; }

			public DisorientedSize(int resizeAxisSize, int otherAxisSize)
			{
				this.ResizeAxisSize = resizeAxisSize;
				this.OtherAxisSize = otherAxisSize;
			}

			public Size Orient(Orientation resizeDir)
			{
				if (resizeDir == Orientation.Horizontal)
					return new Size(ResizeAxisSize, OtherAxisSize);
				else
					return new Size(OtherAxisSize, ResizeAxisSize);
			}

			public static DisorientedSize Disorient(Size size, Orientation resizeDir)
			{
				if (resizeDir == Orientation.Horizontal)
					return new DisorientedSize(size.Width, size.Height);
				else
					return new DisorientedSize(size.Height, size.Width);
			}
		}
	}
}
