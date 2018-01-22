using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FolioWebGen.WinForms
{
	public partial class FolderBrowsePanel : UserControl
	{
		public string Caption {
			get => GroupBox.Text;
			set => GroupBox.Text = value;
		}
		public event EventHandler CaptionChanged {
			add => GroupBox.TextChanged += value;
			remove => GroupBox.TextChanged -= value;
		}

		public string DialogueTitle {
			get => FolderBrowserDialog.Description;
			set => FolderBrowserDialog.Description = value;
		}

		/// <summary>
		/// Gets or sets the current path.
		/// When setting, validates that the path points to a folder or is null/empty.
		/// If not, the old path is kept (and reapplied to all relevant child controls).
		/// </summary>
		public string Path {
			get => PathTextBox.Text;
			set {
				if (PathTextBox.TrySetText(value))
				{
					PathChanged?.Invoke(this, EventArgs.Empty);
				}
				//Apply the new or old path to other child controls - which ensures that all paths
				//(some of which are set by the user, and are validated in response to events)
				//are valid and indentical
				FolderBrowserDialog.SelectedPath = PathTextBox.Text;

				//	if (!TrySetPath(value))
				//	{
				//		//Apply old path to child controls
				//		PathTextBox.Text = _path;
				//		FolderBrowserDialog.SelectedPath = _path;
				//	
				//		MessageBox.Show(
				//			text: "The specified path \"" + value + "\" does not point to a folder.",
				//			caption: "Invalid path",
				//			buttons: MessageBoxButtons.OK,
				//			icon: MessageBoxIcon.Exclamation
				//		);
				//	}
			}
		}
		//	//TODO: Create ValidatedTextBox class and put this logic there
		//	public bool TrySetPath(string newPath)
		//	{
		//		if (string.IsNullOrEmpty(newPath) || Directory.Exists(newPath))
		//		{
		//			_path = newPath;
		//			PathTextBox.Text = newPath;
		//			FolderBrowserDialog.SelectedPath = newPath;
		//	
		//			PathChanged?.Invoke(this, EventArgs.Empty);
		//	
		//			return true;
		//		}
		//		else return false;
		//	}
		public event EventHandler PathChanged;

		[DefaultValue("Color [Control]")]
		// ^ Without this, the serializer thinks the default is 'Window' (white/transparent, idk),
		// so it doesn't save that. However the default actually seems to be 'Control' - which
		// should be fine if it doesn't get saved (as it's the default).
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		// ^ Make sure it gets serialized (AFAIK this is the default anyway)
		public override Color BackColor {
			get => GroupBox.BackColor;
			set {
				GroupBox.BackColor = value;
				PathTextBox.BackColor = value;
			}
		}

		//Button colouring doesn't work as I'd expect
		//	public Color ButtonBackColor {
		//		get => BrowseButton.BackColor;
		//		set {
		//			BrowseButton.BackColor = value;
		//			ExploreButton.BackColor = value;
		//		}
		//	}

		public bool ShowNewFolderButton {
			get => FolderBrowserDialog.ShowNewFolderButton;
			set => FolderBrowserDialog.ShowNewFolderButton = value;
		}


		public event EventHandler BrowseStarting;
		public event EventHandler BrowseCompleted;
		public event EventHandler ViewedInExplorer;

		public FolderBrowsePanel()
		{
			InitializeComponent();

			PathTextBox.Predicate = p =>
			{
				if (string.IsNullOrEmpty(p) || Directory.Exists(p)) return ValidatedTextBox.InputValid;
				else return ValidatedTextBox.InputInvalid("The specified path \"" + p + "\" does not point to a folder.");
			};

			BrowseButton.Click += delegate { ShowBrowseDialog(); };

			PathTextBox.TextChangeAttempted += (s, e) => {
				if (e.Success) PathChanged?.Invoke(this, EventArgs.Empty);
			};

			ExploreButton.Click += delegate { ViewInExplorer(); };
		}

		public void ShowBrowseDialog()
		{
			BrowseStarting?.Invoke(this, EventArgs.Empty);

			DialogResult res = FolderBrowserDialog.ShowDialog();
			if (res == DialogResult.OK)
			{
				Path = FolderBrowserDialog.SelectedPath;
			}

			BrowseCompleted?.Invoke(this, EventArgs.Empty);
		}

		public void ViewInExplorer()
		{
			if (string.IsNullOrEmpty(Path))
			{
				MessageBox.Show(
					text: "No path has been specified.",
					caption: "Cannot Open in Explorer",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Exclamation
				);
			}
			else if (Directory.Exists(Path)) //Check that the path still points to a folder
			{
				Process.Start(
					//Start Explorer, passing in the path as the first argument
					//Ensure that there is a directory separator character at the end, to
					//guarantee that explorer interprets it as a folder not a file (in case
					//someone makes explorer hang then replaces the folder or something)
					new ProcessStartInfo(
						fileName: "explorer.exe",
						arguments: Path.TrimEnd(System.IO.Path.DirectorySeparatorChar)
						+ System.IO.Path.DirectorySeparatorChar
					) {
						ErrorDialog = true //Show error if failed to start process
					}
				);

				ViewedInExplorer?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				MessageBox.Show(
					text: "The specified path \"" + Path + "\" does not point to a folder. "
					+ "Maybe the folder it pointed to has been deleted or replaced with a file?",
					caption: "Cannot Open in Explorer",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Error
				);
			}
		}
	}
}
