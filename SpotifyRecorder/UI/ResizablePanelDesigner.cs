using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms.Layout;

namespace SpotifyRec.UI
{
	public class ResizablePanelDesigner : ParentControlDesigner
	{
		private const string innerPanelName = "InnerPanel";

		private IDesignerHost designerHost;

		private ResizablePanel resizablePanel;
		private ResizedPanel innerPanel;
		private ResizedPanelDesigner InnerPanelDesigner {
			get => (ResizedPanelDesigner)this.designerHost.GetDesigner(this.innerPanel);
		}

		private bool disableDrawGrid;
		private bool disabledGlyphs;
		private bool wholeResizablePanelSelected;

		//	private int initialSplitterDist;
		//	private bool splitterDistanceException;


		protected override bool AllowControlLasso => false;

		protected override bool DrawGrid => this.disableDrawGrid ? false : base.DrawGrid;

		internal bool InnerPanelSelected {
			get => this.InnerPanelDesigner.Selected;
			set => this.InnerPanelDesigner.Selected = value;
		}
		
		//No idea what this is for but it might be needed for serialization etc.
		public override ICollection AssociatedComponents {
			get {
				ArrayList arrayList = new ArrayList();
				foreach (Control control1 in (ArrangedElementCollection)this.resizablePanel.Controls) {
					foreach (Control control2 in (ArrangedElementCollection)control1.Controls)
						arrayList.Add(control2);
				}
				return arrayList;
			}
		}

		//Not sure what this does but probably important for handling nested controls
		protected override Control GetParentForComponent(IComponent component) {
			return this.innerPanel;
		}

		//Note: In SplitContainer this is returns the number of splitter panels.
		public override int NumberOfInternalControlDesigners() => 1;

		//Note: In SplitContainer this returns the designer for panel 1 or 2 depending on whether the
		//index is 0 or 1, and returns null otherwise.
		public override ControlDesigner InternalControlDesigner(int internalControlIndex) {
			if (internalControlIndex == 0) return InnerPanelDesigner;
			else return null;
		}

		protected override void OnDragEnter(DragEventArgs de)
		{
			de.Effect = DragDropEffects.None;
		}

		//Idk why this is needed, but probably good to include it
		protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
		{
			//I don't think this is needed
			//	if (!this.InnerPanelSelected)
			//		this.InnerPanelSelected = true;

			InvokeCreateTool((ParentControlDesigner)this.designerHost.GetDesigner(this.innerPanel), tool);

			return null;
		}

		protected override void Dispose(bool disposing)
		{
			ISelectionService service = (ISelectionService)this.GetService(typeof (ISelectionService));
			if (service != null) service.SelectionChanged -= this.OnSelectionChanged;

			this.resizablePanel.MouseDown -= this.OnSplitContainer;
			this.resizablePanel.ResizeFinished -= this.OnResizeFinished;
			this.resizablePanel.ResizeProgressed -= this.OnResizeProgressed;
			this.resizablePanel.DoubleClick -= this.OnSplitContainerDoubleClick;

			base.Dispose(disposing);
		}

		protected override bool GetHitTest(Point point)
		{
			if (this.InheritanceAttribute != InheritanceAttribute.InheritedReadOnly)
				return this.wholeResizablePanelSelected;
			return false;
		}

		//I don't really know what Glyphs are, and SelectionManager is internal to the .NET libraries
		//	protected override ControlBodyGlyph GetControlGlyph(GlyphSelectionType selectionType)
		//	{
		//		SelectionManager service = (SelectionManager) this.GetService(typeof (SelectionManager));
		//		if (service != null)
		//		{
		//			Rectangle bounds1 = this.BehaviorService.ControlRectInAdornerWindow((Control) this.innerPanel);
		//			ResizablePanelDesigner designer1 = this.designerHost.GetDesigner((IComponent) this.innerPanel) as SplitterPanelDesigner;
		//			this.OnSetCursor();
		//			if (designer1 != null)
		//			{
		//				ControlBodyGlyph controlBodyGlyph = new ControlBodyGlyph(bounds1, Cursor.Current, (IComponent) this.innerPanel, (ControlDesigner) designer1);
		//				service.BodyGlyphAdorner.Glyphs.Add((Glyph) controlBodyGlyph);
		//			}
		//			Rectangle bounds2 = this.BehaviorService.ControlRectInAdornerWindow((Control) this.innerPanel);
		//			ResizablePanelDesigner designer2 = this.designerHost.GetDesigner((IComponent) this.innerPanel) as SplitterPanelDesigner;
		//			if (designer2 != null)
		//			{
		//				ControlBodyGlyph controlBodyGlyph = new ControlBodyGlyph(bounds2, Cursor.Current, (IComponent) this.innerPanel, (ControlDesigner) designer2);
		//				service.BodyGlyphAdorner.Glyphs.Add((Glyph) controlBodyGlyph);
		//			}
		//		}
		//		return base.GetControlGlyph(selectionType);
		//	}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			this.AutoResizeHandles = true;

			this.resizablePanel = component as ResizablePanel;
			this.innerPanel = this.resizablePanel.InnerPanel;

			this.EnableDesignMode(this.resizablePanel.InnerPanel, innerPanelName);

			this.designerHost = (IDesignerHost)component.Site.GetService(typeof(IDesignerHost));

			this.resizablePanel.MouseDown += this.OnSplitContainer;
			this.resizablePanel.ResizeFinished += this.OnResizeFinished;
			this.resizablePanel.ResizeProgressed += this.OnResizeProgressed;
			this.resizablePanel.DoubleClick += this.OnSplitContainerDoubleClick;

			ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
			if (service != null) service.SelectionChanged += this.OnSelectionChanged;
		}

		protected override void OnPaintAdornments(PaintEventArgs pe)
		{
			try
			{
				this.disableDrawGrid = true;
				base.OnPaintAdornments(pe);
			}
			finally
			{
				this.disableDrawGrid = false;
			}
		}

		public override bool CanParent(Control control)
		{
			return false;
		}

		private void OnSplitContainer(object sender, MouseEventArgs e)
		{
			((ISelectionService) this.GetService(typeof (ISelectionService))).SetSelectedComponents((ICollection) new object[1]
			{
				(object) this.Control
			});
		}

		private void OnSplitContainerDoubleClick(object sender, EventArgs e)
		{
			if (!this.wholeResizablePanelSelected)
				return;
			try
			{
				this.DoDefaultAction();
			}
			catch (Exception ex)
			{
				if (WinFormsInternal_IsCriticalException(ex)) throw;
				else this.DisplayError(ex);
			}
		}

		private void OnResizeFinished(object sender, PanelResizeEventArgs e)
		{
			if (this.InheritanceAttribute == InheritanceAttribute.InheritedReadOnly)
				return;
			//	if (this.splitterDistanceException)
			//		return;
			try
			{
				this.RaiseComponentChanging(TypeDescriptor.GetProperties(this.resizablePanel)["SplitterDistance"]);
				this.RaiseComponentChanged(TypeDescriptor.GetProperties(this.resizablePanel)["SplitterDistance"], null, null);
				if (!this.disabledGlyphs) return;
				
				//None of these lines compile and idk how to fix that
				//	this.BehaviorService.EnableAllAdorners(true);
				//	SelectionManager service = (SelectionManager) this.GetService(typeof (SelectionManager));
				//	if (service != null)
				//		service.Refresh();

				this.disabledGlyphs = false;
			}
			catch (InvalidOperationException ex)
			{
				((IUIService)this.Component.Site.GetService(typeof(IUIService))).ShowError(ex.Message);
			}
			//I don't think this applies here
			//	catch (CheckoutException ex)
			//	{
			//		if (ex == CheckoutException.Canceled)
			//		{
			//			try
			//			{
			//				this.splitterDistanceException = true;
			//				this.resizablePanel.SplitterDistance = this.initialSplitterDist;
			//			}
			//			finally
			//			{
			//				this.splitterDistanceException = false;
			//			}
			//		}
			//		else
			//			throw;
			//	}
		}

		private void OnResizeProgressed(object sender, PanelResizeEventArgs e)
		{
			//this.initialSplitterDist = this.resizablePanel.SplitterDistance;
			if (this.InheritanceAttribute == InheritanceAttribute.InheritedReadOnly)
				return;
			this.disabledGlyphs = true;
			
			//None of the lines here that do anything important compile
			//Mostly because SelectionManager is internal to the .NET libraries, but some other
			//parts are also problematic
			//Anyway idk that this is needed and idk how to fix it
			//	Adorner adorner1 = (Adorner) null;
			//	SelectionManager service = (SelectionManager) this.GetService(typeof (SelectionManager));
			//	if (service != null)
			//		adorner1 = service.BodyGlyphAdorner;
			//	foreach (Adorner adorner2 in this.BehaviorService.Adorners)
			//	{
			//		if (adorner1 == null || !adorner2.Equals((object) adorner1))
			//			adorner2.EnabledInternal = false;
			//	}
			//	this.BehaviorService.Invalidate();
			//	ArrayList arrayList = new ArrayList();
			//	foreach (ControlBodyGlyph glyph in (CollectionBase) adorner1.Glyphs)
			//	{
			//		if (!(glyph.RelatedComponent is SplitterPanel))
			//			arrayList.Add((object) glyph);
			//	}
			//	foreach (Glyph glyph in arrayList)
			//		adorner1.Glyphs.Remove(glyph);
		}

		private void OnSelectionChanged(object sender, EventArgs e)
		{
			ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
			this.wholeResizablePanelSelected = false;
			if (service == null)
				return;
			foreach (object selectedComponent in service.GetSelectedComponents())
			{
				if (selectedComponent is ResizedPanel innerPanel && innerPanel.Parent == this.resizablePanel)
				{
					this.wholeResizablePanelSelected = false;
					this.InnerPanelSelected = true;
					break;
				}
				else
				{
					this.InnerPanelSelected = false;
				}

				if (selectedComponent == this.resizablePanel)
				{
					this.wholeResizablePanelSelected = true;
					break;
				}
			}
		}

		internal void SplitterPanelHover()
		{
			this.OnMouseHover();
		}


		public static bool WinFormsInternal_IsCriticalException(Exception ex)
		{
			//This method sounds extremely valuable for handling exceptions in designers
			//Unfortunately, it's internal to the System.Windows.Forms assembly
			//This method works around that

			return (bool)(
				Assembly.GetAssembly(typeof(Form))
				.GetType("System.Windows.Forms.ClientUtils")
				.GetMethod("IsCriticalException", new Type[] { typeof(Exception) })
				.Invoke(obj: null, parameters: new object[] { ex })
			);
		}
	}
}
