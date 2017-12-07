using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SpotifyRec.UI
{
	internal class UniaxualResizePanelDesigner : ParentControlDesigner
	{
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			if (this.Control is UniaxualResizePanel uniaxualResizePanel)
			{
				this.EnableDesignMode(uniaxualResizePanel.InnerPanel, "InnerPanel");
			}
		}
	}
}