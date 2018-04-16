namespace FolioWebGen.WinForms
{
	partial class FolderBrowsePanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.GroupBox = new System.Windows.Forms.GroupBox();
			this.ExploreButton = new System.Windows.Forms.Button();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.PathTextBox = new FolioWebGen.WinForms.ValidatedTextBox();
			this.GroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox
			// 
			this.GroupBox.Controls.Add(this.PathTextBox);
			this.GroupBox.Controls.Add(this.ExploreButton);
			this.GroupBox.Controls.Add(this.BrowseButton);
			this.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GroupBox.Location = new System.Drawing.Point(3, 3);
			this.GroupBox.Name = "GroupBox";
			this.GroupBox.Padding = new System.Windows.Forms.Padding(7, 5, 7, 3);
			this.GroupBox.Size = new System.Drawing.Size(348, 76);
			this.GroupBox.TabIndex = 0;
			this.GroupBox.TabStop = false;
			this.GroupBox.Text = "Folder";
			// 
			// ExploreButton
			// 
			this.ExploreButton.Location = new System.Drawing.Point(87, 45);
			this.ExploreButton.Name = "ExploreButton";
			this.ExploreButton.Size = new System.Drawing.Size(112, 23);
			this.ExploreButton.TabIndex = 2;
			this.ExploreButton.Text = "View In Explorer";
			this.ExploreButton.UseVisualStyleBackColor = true;
			// 
			// BrowseButton
			// 
			this.BrowseButton.Location = new System.Drawing.Point(6, 45);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(75, 23);
			this.BrowseButton.TabIndex = 1;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			// 
			// PathTextBox
			// 
			this.PathTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.PathTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.PathTextBox.ShowErrorDialog = true;
			this.PathTextBox.Location = new System.Drawing.Point(7, 18);
			this.PathTextBox.Name = "PathTextBox";
			this.PathTextBox.Predicate = null;
			this.PathTextBox.Size = new System.Drawing.Size(334, 20);
			this.PathTextBox.TabIndex = 3;
			// 
			// FolderBrowsePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.GroupBox);
			this.Name = "FolderBrowsePanel";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(354, 82);
			this.GroupBox.ResumeLayout(false);
			this.GroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		private System.Windows.Forms.GroupBox GroupBox;
		private System.Windows.Forms.Button ExploreButton;
		private System.Windows.Forms.Button BrowseButton;
		private ValidatedTextBox PathTextBox;
	}
}
