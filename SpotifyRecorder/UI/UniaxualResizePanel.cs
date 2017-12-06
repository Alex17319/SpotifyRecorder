using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.UI
{
	public partial class UniaxualResizePanel : UserControl
	{
		private const int ExpandBorderSize = 10;

		private Orientation _resizeDir;
		public Orientation ResizeDir {
			get => _resizeDir;
			set {

			}
		}

		private readonly Panel _outerPanel;
		private readonly Panel _innerPanel;

		public UniaxualResizePanel() : this(resizeDir: Orientation.Vertical) { }

		public UniaxualResizePanel(Orientation resizeDir, int resizerThickness)
		{
			InitializeComponent();

			_outerPanel = new System.Windows.Forms.Panel();
			_innerPanel = new System.Windows.Forms.Panel();

			SuspendLayout();
			_outerPanel.SuspendLayout();
			_innerPanel.SuspendLayout();

			_outerPanel.Name = "OuterPanel";
			_outerPanel.TabIndex = 0;
			_outerPanel.Location = new Point(0, 0);
			_outerPanel.Size = this.Size + new Size(ExpandBorderSize, ExpandBorderSize);

			_innerPanel.Name = "InnerPanel";
			_innerPanel.TabIndex = 0;
			_innerPanel.Location = new Point(0, 0);
			_innerPanel.Size = this.Size - new Size(
				resizeDir == Orientation.Horizontal ? resizerThickness : 0,
				resizeDir == Orientation.Vertical   ? resizerThickness : 0
			);

			_outerPanel.Controls.Add(this._innerPanel);
			Controls.Add(this._outerPanel);

			this._innerPanel.ResumeLayout(performLayout: false);
			this._outerPanel.ResumeLayout(performLayout: false);
			this.ResumeLayout(performLayout: false);

			this._outerPanel.Controls.Add(_innerPanel);
			//	// 
			//	// panel1
			//	// 
			//	this.panel1.Controls.Add(this.panel2);
			//	this.panel1.Location = new System.Drawing.Point(0, 0);
			//	this.panel1.Name = "panel1";
			//	this.panel1.Size = new System.Drawing.Size(100, 100);
			//	this.panel1.TabIndex = 0;
			//	// 
			//	// panel2
			//	// 
			//	this.panel2.Location = new System.Drawing.Point(0, 0);
			//	this.panel2.Name = "panel2";
			//	this.panel2.Size = new System.Drawing.Size(50, 50);
			//	this.panel2.TabIndex = 0;
			// 
			// UniaxualResizePanel
			// 
			this.Controls.Add(this.panel1);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);


		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);


		}
	}
}
