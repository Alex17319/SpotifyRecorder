namespace SpotifyRec.UI
{
	partial class SettingsPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
			this.InnerPanel = new System.Windows.Forms.Panel();
			this.resizablePanel1 = new SpotifyRec.UI.ResizablePanel();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.SongNamesTextBox = new System.Windows.Forms.TextBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel5 = new System.Windows.Forms.Panel();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.AdKeywordsTextBox = new System.Windows.Forms.TextBox();
			this.splitter5 = new System.Windows.Forms.Splitter();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.AdNamesTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputFormatGroupBox = new System.Windows.Forms.GroupBox();
			this.OutputFormatBox = new System.Windows.Forms.ComboBox();
			this.resizablePanel1.InnerPanel.SuspendLayout();
			this.resizablePanel1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.OutputFormatGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// InnerPanel
			// 
			this.InnerPanel.BackColor = System.Drawing.Color.Red;
			this.InnerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.InnerPanel.Location = new System.Drawing.Point(0, 0);
			this.InnerPanel.Name = "InnerPanel";
			this.InnerPanel.Size = new System.Drawing.Size(200, 195);
			this.InnerPanel.TabIndex = 0;
			// 
			// resizablePanel1
			// 
			this.resizablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.resizablePanel1.InnerPadding = new System.Windows.Forms.Padding(0);
			// 
			// resizablePanel1.InnerPanel
			// 
			this.resizablePanel1.InnerPanel.BackColor = System.Drawing.SystemColors.Info;
			this.resizablePanel1.InnerPanel.Controls.Add(this.groupBox5);
			this.resizablePanel1.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resizablePanel1.InnerPanel.Location = new System.Drawing.Point(0, 0);
			this.resizablePanel1.InnerPanel.MinimumSize = new System.Drawing.Size(0, 290);
			this.resizablePanel1.InnerPanel.Name = "InnerPanel";
			this.resizablePanel1.InnerPanel.Size = new System.Drawing.Size(364, 355);
			this.resizablePanel1.InnerPanel.TabIndex = 0;
			this.resizablePanel1.Location = new System.Drawing.Point(3, 3);
			this.resizablePanel1.MinimumSize = new System.Drawing.Size(0, 295);
			this.resizablePanel1.Name = "resizablePanel1";
			this.resizablePanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.resizablePanel1.ResizerSizes = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.resizablePanel1.Size = new System.Drawing.Size(364, 360);
			this.resizablePanel1.TabIndex = 15;
			// 
			// groupBox5
			// 
			this.groupBox5.BackColor = System.Drawing.SystemColors.Window;
			this.groupBox5.Controls.Add(this.panel2);
			this.groupBox5.Controls.Add(this.splitter2);
			this.groupBox5.Controls.Add(this.panel5);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Location = new System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(364, 355);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Ad Classification";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox6);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 237);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(358, 115);
			this.panel2.TabIndex = 6;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.SongNamesTextBox);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox6.Location = new System.Drawing.Point(0, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(358, 115);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Exempt Song Names";
			// 
			// SongNamesTextBox
			// 
			this.SongNamesTextBox.AcceptsReturn = true;
			this.SongNamesTextBox.AcceptsTab = true;
			this.SongNamesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SongNamesTextBox.Location = new System.Drawing.Point(3, 16);
			this.SongNamesTextBox.Multiline = true;
			this.SongNamesTextBox.Name = "SongNamesTextBox";
			this.SongNamesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.SongNamesTextBox.Size = new System.Drawing.Size(352, 96);
			this.SongNamesTextBox.TabIndex = 1;
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.SystemColors.Control;
			this.splitter2.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(3, 232);
			this.splitter2.MinExtra = 60;
			this.splitter2.MinimumSize = new System.Drawing.Size(0, 5);
			this.splitter2.MinSize = 40;
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(358, 5);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.groupBox7);
			this.panel5.Controls.Add(this.splitter5);
			this.panel5.Controls.Add(this.groupBox8);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(3, 128);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(358, 104);
			this.panel5.TabIndex = 2;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.AdKeywordsTextBox);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox7.Location = new System.Drawing.Point(105, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(253, 104);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Ad Keywords";
			// 
			// AdKeywordsTextBox
			// 
			this.AdKeywordsTextBox.AcceptsReturn = true;
			this.AdKeywordsTextBox.AcceptsTab = true;
			this.AdKeywordsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdKeywordsTextBox.Location = new System.Drawing.Point(3, 16);
			this.AdKeywordsTextBox.Multiline = true;
			this.AdKeywordsTextBox.Name = "AdKeywordsTextBox";
			this.AdKeywordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.AdKeywordsTextBox.Size = new System.Drawing.Size(247, 85);
			this.AdKeywordsTextBox.TabIndex = 0;
			this.AdKeywordsTextBox.Text = "spotify\r\nlisten now\r\nclick here\r\nclick the banner\r\nget premium";
			// 
			// splitter5
			// 
			this.splitter5.BackColor = System.Drawing.SystemColors.Control;
			this.splitter5.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.splitter5.Location = new System.Drawing.Point(100, 0);
			this.splitter5.MinExtra = 130;
			this.splitter5.MinimumSize = new System.Drawing.Size(5, 0);
			this.splitter5.MinSize = 100;
			this.splitter5.Name = "splitter5";
			this.splitter5.Size = new System.Drawing.Size(5, 104);
			this.splitter5.TabIndex = 1;
			this.splitter5.TabStop = false;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.AdNamesTextBox);
			this.groupBox8.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox8.Location = new System.Drawing.Point(0, 0);
			this.groupBox8.MinimumSize = new System.Drawing.Size(100, 0);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(100, 104);
			this.groupBox8.TabIndex = 0;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Ad Names";
			// 
			// AdNamesTextBox
			// 
			this.AdNamesTextBox.AcceptsReturn = true;
			this.AdNamesTextBox.AcceptsTab = true;
			this.AdNamesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdNamesTextBox.Location = new System.Drawing.Point(3, 16);
			this.AdNamesTextBox.Multiline = true;
			this.AdNamesTextBox.Name = "AdNamesTextBox";
			this.AdNamesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.AdNamesTextBox.Size = new System.Drawing.Size(94, 85);
			this.AdNamesTextBox.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(3, 16);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(3);
			this.label2.Size = new System.Drawing.Size(358, 112);
			this.label2.TabIndex = 1;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// OutputFormatGroupBox
			// 
			this.OutputFormatGroupBox.AutoSize = true;
			this.OutputFormatGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.OutputFormatGroupBox.Controls.Add(this.OutputFormatBox);
			this.OutputFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputFormatGroupBox.Location = new System.Drawing.Point(3, 363);
			this.OutputFormatGroupBox.Name = "OutputFormatGroupBox";
			this.OutputFormatGroupBox.Size = new System.Drawing.Size(364, 40);
			this.OutputFormatGroupBox.TabIndex = 16;
			this.OutputFormatGroupBox.TabStop = false;
			this.OutputFormatGroupBox.Text = "Output Format";
			// 
			// OutputFormatBox
			// 
			this.OutputFormatBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputFormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OutputFormatBox.FormattingEnabled = true;
			this.OutputFormatBox.Items.AddRange(new object[] {
            "MP3",
            "WAV",
            "WMA",
            "AAC",
            "AIFF"});
			this.OutputFormatBox.Location = new System.Drawing.Point(3, 16);
			this.OutputFormatBox.Name = "OutputFormatBox";
			this.OutputFormatBox.Size = new System.Drawing.Size(358, 21);
			this.OutputFormatBox.TabIndex = 0;
			// 
			// SettingsPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.OutputFormatGroupBox);
			this.Controls.Add(this.resizablePanel1);
			this.MinimumSize = new System.Drawing.Size(370, 100);
			this.Name = "SettingsPage";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(370, 438);
			this.resizablePanel1.InnerPanel.ResumeLayout(false);
			this.resizablePanel1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.OutputFormatGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel InnerPanel;
		private ResizablePanel resizablePanel1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox SongNamesTextBox;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox AdKeywordsTextBox;
		private System.Windows.Forms.Splitter splitter5;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox AdNamesTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox OutputFormatGroupBox;
		private System.Windows.Forms.ComboBox OutputFormatBox;
	}
}
