namespace SpotifyRec.UI
{
	partial class RecordingPage
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
			this.StartStopButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.OuputFolderPanel = new FolioWebGen.WinForms.FolderBrowsePanel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartStopButton
			// 
			this.StartStopButton.AutoSize = true;
			this.StartStopButton.Location = new System.Drawing.Point(0, 0);
			this.StartStopButton.Name = "StartStopButton";
			this.StartStopButton.Size = new System.Drawing.Size(112, 23);
			this.StartStopButton.TabIndex = 0;
			this.StartStopButton.Text = "Start Recording";
			this.StartStopButton.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.StartStopButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(7, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(402, 26);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(7);
			this.panel2.Size = new System.Drawing.Size(416, 40);
			this.panel2.TabIndex = 4;
			// 
			// OuputFolderPanel
			// 
			this.OuputFolderPanel.BackColor = System.Drawing.SystemColors.Window;
			this.OuputFolderPanel.Caption = "Folder";
			this.OuputFolderPanel.DialogueTitle = "";
			this.OuputFolderPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.OuputFolderPanel.Location = new System.Drawing.Point(0, 40);
			this.OuputFolderPanel.Name = "OuputFolderPanel";
			this.OuputFolderPanel.Padding = new System.Windows.Forms.Padding(3);
			this.OuputFolderPanel.Path = "";
			this.OuputFolderPanel.ShowNewFolderButton = true;
			this.OuputFolderPanel.Size = new System.Drawing.Size(416, 82);
			this.OuputFolderPanel.TabIndex = 5;
			// 
			// RecordingPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.OuputFolderPanel);
			this.Controls.Add(this.panel2);
			this.Name = "RecordingPage";
			this.Size = new System.Drawing.Size(416, 282);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StartStopButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private FolioWebGen.WinForms.FolderBrowsePanel OuputFolderPanel;
	}
}
