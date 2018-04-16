using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignerSerVisAttribute = System.ComponentModel.DesignerSerializationVisibilityAttribute;
using DesignerSerVis = System.ComponentModel.DesignerSerializationVisibility;

namespace SpotifyRec.UI
{
	[Designer(typeof(ResizedPanelDesigner))]
	[ToolboxItem(false)]
	public class ResizedPanel : Panel
	{
		public ResizablePanel Owner { get; }

		public ResizedPanel(ResizablePanel owner)
		{
			this.Owner = owner;
		}

		/*
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerVis(DesignerSerVis.Hidden)]
		public override Size MaximumSize {
			get => Owner.MaximumSize - new Size(
				width: Owner.ResizerSizes.Horizontal,
				height: Owner.ResizerSizes.Vertical
			);
			set => Owner.MaximumSize = value + new Size(
				width: Owner.ResizerSizes.Horizontal,
				height: Owner.ResizerSizes.Vertical
			);
		}
		*/
	}
}
