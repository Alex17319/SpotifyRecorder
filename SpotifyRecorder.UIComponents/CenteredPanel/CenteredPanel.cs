using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.UIComponents
{
	public partial class CenteredPanel : Panel
	{
		private float _horizontalAlignment;
		public float HorizontalAlignment {
			get => _horizontalAlignment;
			set { _horizontalAlignment = value; ApplyAlignment(); }
		}
		private float _verticalAlignment;
		public float VerticalAlignment {
			get => _verticalAlignment;
			set { _verticalAlignment = value; ApplyAlignment(); }
		}

		private SizeF _fractionalSize;
		public SizeF FractionalSize {
			get => _fractionalSize;
			set { _fractionalSize = value; ApplyAlignment(); }
		}

		public CenteredPanel()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}

		private Control _oldParent; //The ParentChanged event doesn't provide the old value, so we have to use this instead
		protected override void OnParentChanged(EventArgs e)
		{
			//Idk if the parent field has already changed value by this point, but I'm guessing it has

			base.OnParentChanged(e);

			if (this._oldParent != null) {
				this.Parent.ClientSizeChanged -= OnParentClientSizeChanged;
			}
			if (this.Parent != null) {
				this.Parent.ClientSizeChanged += OnParentClientSizeChanged;
			}
			this._oldParent = this.Parent;

			ApplyAlignment();
		}

		private void OnParentClientSizeChanged(object sender, EventArgs e)
		{
			ApplyAlignment();
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			//ApplyAlignment();

			base.OnValidating(e);
		}

		private void ApplyAlignment()
		{
			if (this.Parent == null) return; //Occurs I think during initial deserialization, and maybe also in design time

			if (_fractionalSize.Width  > 0.001) this.Width  = (int)Math.Round(this.Parent.ClientSize.Width  * _fractionalSize.Width );
			if (_fractionalSize.Height > 0.001) this.Height = (int)Math.Round(this.Parent.ClientSize.Height * _fractionalSize.Height);

			this.Left = (int)Math.Round((this.Parent.ClientSize.Width  - this.Width ) * _horizontalAlignment);
			this.Top  = (int)Math.Round((this.Parent.ClientSize.Height - this.Height) * _verticalAlignment  );
		}
	}
}
