using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace SpotifyRec.UI
{
	internal class PanelDesigner : ScrollableControlDesigner
	{
		protected Pen BorderPen {
			get => new Pen(
				this.Control.BackColor.GetBrightness() < 0.5 ?
				ControlPaint.Light(this.Control.BackColor) : ControlPaint.Dark(this.Control.BackColor)
			) {
				DashStyle = DashStyle.Dash
			};
		}

		public PanelDesigner()
		{
			this.AutoResizeHandles = true;
		}

		protected virtual void DrawBorder(Graphics graphics)
		{
			Panel component = (Panel)this.Component;
			if (component == null || !component.Visible) return;

			using (Pen borderPen = this.BorderPen)
			{
				//Idk why you'd dispose of a property that might be used later, but that's what's in the .NET source

				Rectangle drawnClientRectangle = Rectangle.Inflate(this.Control.ClientRectangle, -1, -1);
				graphics.DrawRectangle(borderPen, drawnClientRectangle);
			}
		}

		protected override void OnPaintAdornments(PaintEventArgs pe)
		{
			if (((Panel)this.Component).BorderStyle == BorderStyle.None) this.DrawBorder(pe.Graphics);

			base.OnPaintAdornments(pe);
		}
	}
}