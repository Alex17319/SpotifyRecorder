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
	class ResizedPanelDesigner : PanelDesigner
	{
		private IDesignerHost designerHost;
		private ResizablePanelDesigner resizablePanelDesigner;
		private ResizedPanel resizedPanel;
		private bool selected;

		protected override InheritanceAttribute InheritanceAttribute {
			get {
				if (this.resizedPanel != null && this.resizedPanel.Parent != null)
					return (InheritanceAttribute) TypeDescriptor.GetAttributes(this.resizedPanel.Parent)[typeof(InheritanceAttribute)];
				return base.InheritanceAttribute;
			}
		}

		internal bool Selected {
			get => this.selected;
			set {
				this.selected = value;
				if (this.selected)
					this.DrawSelectedBorder();
				else
					this.EraseBorder();
			}
		}

		public override IList SnapLines {
			get {
				ArrayList snapLines = null;
				this.AddPaddingSnapLines(ref snapLines);
				return snapLines;
			}
		}

		public override SelectionRules SelectionRules {
			get => this.Control.Parent is ResizablePanel ? SelectionRules.Locked : SelectionRules.None;
		}

		public override bool CanBeParentedTo(IDesigner parentDesigner) => parentDesigner is ResizablePanelDesigner;

		protected override void OnDragEnter(DragEventArgs de)
		{
			if (this.InheritanceAttribute == InheritanceAttribute.InheritedReadOnly)
				de.Effect = DragDropEffects.None;
			else
				base.OnDragEnter(de);
		}

		protected override void OnDragOver(DragEventArgs de)
		{
			if (this.InheritanceAttribute == InheritanceAttribute.InheritedReadOnly)
				de.Effect = DragDropEffects.None;
			else
				base.OnDragOver(de);
		}

		protected override void OnDragLeave(EventArgs e)
		{
			if (this.InheritanceAttribute == InheritanceAttribute.InheritedReadOnly)
				return;
			base.OnDragLeave(e);
		}

		protected override void OnDragDrop(DragEventArgs de)
		{
			if (this.InheritanceAttribute == InheritanceAttribute.InheritedReadOnly)
				de.Effect = DragDropEffects.None;
			else
				base.OnDragDrop(de);
		}

		protected override void OnMouseHover()
		{
			if (this.resizablePanelDesigner != null)
				this.resizablePanelDesigner.SplitterPanelHover();
		}

		protected override void Dispose(bool disposing)
		{
			IComponentChangeService service = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			if (service != null)
				service.ComponentChanged -= new ComponentChangedEventHandler(this.OnComponentChanged);

			base.Dispose(disposing);
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			this.resizedPanel = (ResizedPanel)component;
			this.designerHost = (IDesignerHost)component.Site.GetService(typeof (IDesignerHost));
			this.resizablePanelDesigner = (ResizablePanelDesigner)this.designerHost.GetDesigner((IComponent)this.resizedPanel.Parent);

			IComponentChangeService service = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			if (service != null)
				service.ComponentChanged += new ComponentChangedEventHandler(this.OnComponentChanged);

			PropertyDescriptor property = TypeDescriptor.GetProperties(component)["Locked"];
			if (property != null && this.resizedPanel.Parent is ResizablePanel) {
				property.SetValue(component, true);
			}
		}

		private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
			if (this.resizedPanel.Parent == null) return;

			if (this.resizedPanel.Controls.Count == 0)
			{
				Graphics graphics = this.resizedPanel.CreateGraphics();
				this.DrawWaterMark(graphics);
				graphics.Dispose();
			}
			else
			{
				this.resizedPanel.Invalidate();
			}
		}

		internal void DrawSelectedBorder()
		{
			Control control = this.Control;
			Rectangle clientRectangle = control.ClientRectangle;
			using (Graphics graphics = control.CreateGraphics())
			{
				var penColor = control.BackColor.GetBrightness() >= 0.5 ?
					ControlPaint.Dark(control.BackColor) : ControlPaint.Light(control.BackColor);

				using (Pen pen = new Pen(penColor))
				{
					pen.DashStyle = DashStyle.Dash;
					clientRectangle.Inflate(-4, -4);
					graphics.DrawRectangle(pen, clientRectangle);
				}
			}
		}

		internal void EraseBorder()
		{
			Control control = this.Control;
			Rectangle clientBorderRectangle = Rectangle.Inflate(control.ClientRectangle, -4, -4);

			using (Graphics graphics = control.CreateGraphics())
			using (Pen pen = new Pen(control.BackColor) { DashStyle = DashStyle.Dash })
			{
				graphics.DrawRectangle(pen, clientBorderRectangle);
			}

			control.Invalidate();
		}

		//Draws filler text when the control is empty (AFAIK)
		internal void DrawWaterMark(Graphics g)
		{
			Control control = this.Control;
			Rectangle clientRectangle = control.ClientRectangle;
			string name = control.Name;

			using (Font font = new Font("Arial", 8f))
			{
				int x = clientRectangle.Width / 2 - (int) g.MeasureString(name, font).Width / 2;
				int y = clientRectangle.Height / 2;

				Color foreColor = Color.Black;
				if (this.GetService(typeof(IUIService)) is IUIService service)
					if (service.Styles[(object)"SmartTagText"] is Color tempForeColor)
						foreColor = tempForeColor;

				TextRenderer.DrawText((IDeviceContext) g, name, font, new Point(x, y), foreColor, TextFormatFlags.Default);
			}
		}

		protected override void OnPaintAdornments(PaintEventArgs pe)
		{
			base.OnPaintAdornments(pe);

			if (this.resizedPanel.BorderStyle == BorderStyle.None) this.DrawBorder(pe.Graphics);
			if (this.Selected                                    ) this.DrawSelectedBorder();
			if (this.resizedPanel.Controls.Count == 0            ) this.DrawWaterMark(pe.Graphics);
		}

		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			properties.Remove((object) "Modifiers");
			properties.Remove((object) "Locked");
			properties.Remove((object) "GenerateMember");

			foreach (DictionaryEntry property in properties)
			{
				PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor) property.Value;
				if (oldPropertyDescriptor.Name.Equals("Name") && oldPropertyDescriptor.DesignTimeOnly)
				{
					properties[property.Key] = TypeDescriptor.CreateProperty(
						oldPropertyDescriptor.ComponentType,
						oldPropertyDescriptor,
						new Attribute[2] {
							BrowsableAttribute.No,
							DesignerSerializationVisibilityAttribute.Hidden
						}
					);
					break;
				}
			}
		}
	}
}
