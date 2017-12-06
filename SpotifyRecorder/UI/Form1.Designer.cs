namespace SpotifyRec
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainTabs = new System.Windows.Forms.TabControl();
			this.RecorderTab = new System.Windows.Forms.TabPage();
			this.PlaylistSortTab = new System.Windows.Forms.TabPage();
			this.AdsTab = new System.Windows.Forms.TabPage();
			this.SettingsTab = new System.Windows.Forms.TabPage();
			this.AboutTab = new System.Windows.Forms.TabPage();
			this.LogTextBox = new System.Windows.Forms.RichTextBox();
			this.LogGroupBox = new System.Windows.Forms.GroupBox();
			this.LogPanel = new System.Windows.Forms.Panel();
			this.MainHSplitter = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AdNamesGroupBox = new System.Windows.Forms.GroupBox();
			this.AdNamesTextBox = new System.Windows.Forms.TextBox();
			this.AdsTabInfo = new System.Windows.Forms.Label();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.AdKeywordsTextBox = new System.Windows.Forms.TextBox();
			this.AdKeywordsGroupBox = new System.Windows.Forms.GroupBox();
			this.SongNamesTextBox = new System.Windows.Forms.TextBox();
			this.SongNamesGroupBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.panel4 = new System.Windows.Forms.Panel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.OutputFormatGroupBox = new System.Windows.Forms.GroupBox();
			this.OutputFormatBox = new System.Windows.Forms.ComboBox();
			this.MainTabs.SuspendLayout();
			this.AdsTab.SuspendLayout();
			this.SettingsTab.SuspendLayout();
			this.LogGroupBox.SuspendLayout();
			this.LogPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.AdNamesGroupBox.SuspendLayout();
			this.AdKeywordsGroupBox.SuspendLayout();
			this.SongNamesGroupBox.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.OutputFormatGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainTabs
			// 
			this.MainTabs.Controls.Add(this.RecorderTab);
			this.MainTabs.Controls.Add(this.PlaylistSortTab);
			this.MainTabs.Controls.Add(this.AdsTab);
			this.MainTabs.Controls.Add(this.SettingsTab);
			this.MainTabs.Controls.Add(this.AboutTab);
			this.MainTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this.MainTabs.Location = new System.Drawing.Point(0, 0);
			this.MainTabs.Name = "MainTabs";
			this.MainTabs.SelectedIndex = 0;
			this.MainTabs.Size = new System.Drawing.Size(392, 266);
			this.MainTabs.TabIndex = 0;
			// 
			// RecorderTab
			// 
			this.RecorderTab.Location = new System.Drawing.Point(4, 22);
			this.RecorderTab.Name = "RecorderTab";
			this.RecorderTab.Padding = new System.Windows.Forms.Padding(3);
			this.RecorderTab.Size = new System.Drawing.Size(384, 240);
			this.RecorderTab.TabIndex = 0;
			this.RecorderTab.Text = "Recording";
			this.RecorderTab.UseVisualStyleBackColor = true;
			// 
			// PlaylistSortTab
			// 
			this.PlaylistSortTab.Location = new System.Drawing.Point(4, 22);
			this.PlaylistSortTab.Name = "PlaylistSortTab";
			this.PlaylistSortTab.Padding = new System.Windows.Forms.Padding(3);
			this.PlaylistSortTab.Size = new System.Drawing.Size(384, 240);
			this.PlaylistSortTab.TabIndex = 1;
			this.PlaylistSortTab.Text = "Playlists";
			this.PlaylistSortTab.UseVisualStyleBackColor = true;
			// 
			// AdsTab
			// 
			this.AdsTab.Controls.Add(this.panel2);
			this.AdsTab.Controls.Add(this.splitter1);
			this.AdsTab.Controls.Add(this.panel1);
			this.AdsTab.Controls.Add(this.AdsTabInfo);
			this.AdsTab.Location = new System.Drawing.Point(4, 22);
			this.AdsTab.Name = "AdsTab";
			this.AdsTab.Padding = new System.Windows.Forms.Padding(3);
			this.AdsTab.Size = new System.Drawing.Size(384, 240);
			this.AdsTab.TabIndex = 2;
			this.AdsTab.Text = "Ads";
			this.AdsTab.UseVisualStyleBackColor = true;
			// 
			// SettingsTab
			// 
			this.SettingsTab.AutoScroll = true;
			this.SettingsTab.AutoScrollMinSize = new System.Drawing.Size(0, 500);
			this.SettingsTab.Controls.Add(this.OutputFormatGroupBox);
			this.SettingsTab.Controls.Add(this.groupBox1);
			this.SettingsTab.Location = new System.Drawing.Point(4, 22);
			this.SettingsTab.Name = "SettingsTab";
			this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
			this.SettingsTab.Size = new System.Drawing.Size(384, 240);
			this.SettingsTab.TabIndex = 3;
			this.SettingsTab.Text = "Settings";
			this.SettingsTab.UseVisualStyleBackColor = true;
			// 
			// AboutTab
			// 
			this.AboutTab.Location = new System.Drawing.Point(4, 22);
			this.AboutTab.Name = "AboutTab";
			this.AboutTab.Padding = new System.Windows.Forms.Padding(3);
			this.AboutTab.Size = new System.Drawing.Size(384, 240);
			this.AboutTab.TabIndex = 4;
			this.AboutTab.Text = "About";
			this.AboutTab.UseVisualStyleBackColor = true;
			// 
			// LogTextBox
			// 
			this.LogTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LogTextBox.Location = new System.Drawing.Point(3, 16);
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ReadOnly = true;
			this.LogTextBox.Size = new System.Drawing.Size(378, 130);
			this.LogTextBox.TabIndex = 2;
			this.LogTextBox.Text = "asdfasdf\nasd\n\nwuenrkawer\nuqeruoqnwe\n\nqweyxroqbw\n\nwqernoqynweuiry qwe rqw e rqcwer" +
    " owqe orxqiowerio qwceo rqiowe xro wqer oqw eoxjqwioejrioqwer oqwc eo wqer \n\n\naf" +
    "\na\nwe\nrcq\nwecr\nqwe\nr\nc\n\n\nqer\nwqecr\nwq\n";
			this.LogTextBox.WordWrap = false;
			// 
			// LogGroupBox
			// 
			this.LogGroupBox.Controls.Add(this.LogTextBox);
			this.LogGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogGroupBox.Location = new System.Drawing.Point(4, 4);
			this.LogGroupBox.Name = "LogGroupBox";
			this.LogGroupBox.Size = new System.Drawing.Size(384, 149);
			this.LogGroupBox.TabIndex = 3;
			this.LogGroupBox.TabStop = false;
			this.LogGroupBox.Text = "Log";
			// 
			// LogPanel
			// 
			this.LogPanel.Controls.Add(this.LogGroupBox);
			this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogPanel.Location = new System.Drawing.Point(0, 266);
			this.LogPanel.MinimumSize = new System.Drawing.Size(100, 50);
			this.LogPanel.Name = "LogPanel";
			this.LogPanel.Padding = new System.Windows.Forms.Padding(4);
			this.LogPanel.Size = new System.Drawing.Size(392, 157);
			this.LogPanel.TabIndex = 4;
			// 
			// MainHSplitter
			// 
			this.MainHSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.MainHSplitter.Location = new System.Drawing.Point(0, 266);
			this.MainHSplitter.Name = "MainHSplitter";
			this.MainHSplitter.Size = new System.Drawing.Size(392, 3);
			this.MainHSplitter.TabIndex = 5;
			this.MainHSplitter.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.AdKeywordsGroupBox);
			this.panel1.Controls.Add(this.splitter2);
			this.panel1.Controls.Add(this.AdNamesGroupBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 102);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(378, 59);
			this.panel1.TabIndex = 1;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Window;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(3, 161);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(378, 3);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.SongNamesGroupBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 164);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(378, 73);
			this.panel2.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.splitter4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(361, 304);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ad Classification";
			// 
			// AdNamesGroupBox
			// 
			this.AdNamesGroupBox.Controls.Add(this.AdNamesTextBox);
			this.AdNamesGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.AdNamesGroupBox.Location = new System.Drawing.Point(0, 0);
			this.AdNamesGroupBox.Name = "AdNamesGroupBox";
			this.AdNamesGroupBox.Size = new System.Drawing.Size(200, 59);
			this.AdNamesGroupBox.TabIndex = 0;
			this.AdNamesGroupBox.TabStop = false;
			this.AdNamesGroupBox.Text = "Ad Names";
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
			this.AdNamesTextBox.Size = new System.Drawing.Size(194, 40);
			this.AdNamesTextBox.TabIndex = 0;
			// 
			// AdsTabInfo
			// 
			this.AdsTabInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.AdsTabInfo.Location = new System.Drawing.Point(3, 3);
			this.AdsTabInfo.Name = "AdsTabInfo";
			this.AdsTabInfo.Padding = new System.Windows.Forms.Padding(3);
			this.AdsTabInfo.Size = new System.Drawing.Size(378, 99);
			this.AdsTabInfo.TabIndex = 0;
			this.AdsTabInfo.Text = resources.GetString("AdsTabInfo.Text");
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.SystemColors.Window;
			this.splitter2.Location = new System.Drawing.Point(200, 0);
			this.splitter2.MinimumSize = new System.Drawing.Size(5, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(5, 59);
			this.splitter2.TabIndex = 1;
			this.splitter2.TabStop = false;
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
			this.AdKeywordsTextBox.Size = new System.Drawing.Size(167, 40);
			this.AdKeywordsTextBox.TabIndex = 0;
			this.AdKeywordsTextBox.Text = "spotify\r\nlisten now\r\nclick here\r\nclick the banner\r\nget premium";
			// 
			// AdKeywordsGroupBox
			// 
			this.AdKeywordsGroupBox.Controls.Add(this.AdKeywordsTextBox);
			this.AdKeywordsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AdKeywordsGroupBox.Location = new System.Drawing.Point(205, 0);
			this.AdKeywordsGroupBox.Name = "AdKeywordsGroupBox";
			this.AdKeywordsGroupBox.Size = new System.Drawing.Size(173, 59);
			this.AdKeywordsGroupBox.TabIndex = 2;
			this.AdKeywordsGroupBox.TabStop = false;
			this.AdKeywordsGroupBox.Text = "Ad Keywords";
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
			this.SongNamesTextBox.Size = new System.Drawing.Size(372, 54);
			this.SongNamesTextBox.TabIndex = 0;
			// 
			// SongNamesGroupBox
			// 
			this.SongNamesGroupBox.Controls.Add(this.SongNamesTextBox);
			this.SongNamesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SongNamesGroupBox.Location = new System.Drawing.Point(0, 0);
			this.SongNamesGroupBox.Name = "SongNamesGroupBox";
			this.SongNamesGroupBox.Size = new System.Drawing.Size(378, 73);
			this.SongNamesGroupBox.TabIndex = 0;
			this.SongNamesGroupBox.TabStop = false;
			this.SongNamesGroupBox.Text = "Exempt Song Names";
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(3);
			this.label1.Size = new System.Drawing.Size(355, 99);
			this.label1.TabIndex = 1;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Controls.Add(this.splitter3);
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(3, 115);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(355, 59);
			this.panel3.TabIndex = 2;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(205, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(150, 59);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ad Keywords";
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AcceptsTab = true;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(3, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(144, 40);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "spotify\r\nlisten now\r\nclick here\r\nclick the banner\r\nget premium";
			// 
			// splitter3
			// 
			this.splitter3.BackColor = System.Drawing.SystemColors.Window;
			this.splitter3.Location = new System.Drawing.Point(200, 0);
			this.splitter3.MinimumSize = new System.Drawing.Size(5, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(5, 59);
			this.splitter3.TabIndex = 1;
			this.splitter3.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 59);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ad Names";
			// 
			// textBox2
			// 
			this.textBox2.AcceptsReturn = true;
			this.textBox2.AcceptsTab = true;
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.Location = new System.Drawing.Point(3, 16);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(194, 40);
			this.textBox2.TabIndex = 0;
			// 
			// splitter4
			// 
			this.splitter4.BackColor = System.Drawing.SystemColors.Window;
			this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new System.Drawing.Point(3, 174);
			this.splitter4.MinimumSize = new System.Drawing.Size(0, 5);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(355, 5);
			this.splitter4.TabIndex = 3;
			this.splitter4.TabStop = false;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.groupBox4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 179);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(355, 122);
			this.panel4.TabIndex = 4;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox3);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(355, 122);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Exempt Song Names";
			// 
			// textBox3
			// 
			this.textBox3.AcceptsReturn = true;
			this.textBox3.AcceptsTab = true;
			this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox3.Location = new System.Drawing.Point(3, 16);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(349, 103);
			this.textBox3.TabIndex = 0;
			// 
			// OutputFormatGroupBox
			// 
			this.OutputFormatGroupBox.AutoSize = true;
			this.OutputFormatGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.OutputFormatGroupBox.Controls.Add(this.OutputFormatBox);
			this.OutputFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputFormatGroupBox.Location = new System.Drawing.Point(3, 307);
			this.OutputFormatGroupBox.Name = "OutputFormatGroupBox";
			this.OutputFormatGroupBox.Size = new System.Drawing.Size(361, 40);
			this.OutputFormatGroupBox.TabIndex = 1;
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
			this.OutputFormatBox.Size = new System.Drawing.Size(355, 21);
			this.OutputFormatBox.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 423);
			this.Controls.Add(this.MainHSplitter);
			this.Controls.Add(this.LogPanel);
			this.Controls.Add(this.MainTabs);
			this.MinimumSize = new System.Drawing.Size(400, 450);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.MainTabs.ResumeLayout(false);
			this.AdsTab.ResumeLayout(false);
			this.SettingsTab.ResumeLayout(false);
			this.SettingsTab.PerformLayout();
			this.LogGroupBox.ResumeLayout(false);
			this.LogPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.AdNamesGroupBox.ResumeLayout(false);
			this.AdNamesGroupBox.PerformLayout();
			this.AdKeywordsGroupBox.ResumeLayout(false);
			this.AdKeywordsGroupBox.PerformLayout();
			this.SongNamesGroupBox.ResumeLayout(false);
			this.SongNamesGroupBox.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.OutputFormatGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl MainTabs;
		private System.Windows.Forms.TabPage RecorderTab;
		private System.Windows.Forms.TabPage PlaylistSortTab;
		private System.Windows.Forms.Panel LogPanel;
		private System.Windows.Forms.GroupBox LogGroupBox;
		private System.Windows.Forms.RichTextBox LogTextBox;
		private System.Windows.Forms.Splitter MainHSplitter;
		private System.Windows.Forms.TabPage AdsTab;
		private System.Windows.Forms.TabPage SettingsTab;
		private System.Windows.Forms.TabPage AboutTab;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox SongNamesGroupBox;
		private System.Windows.Forms.TextBox SongNamesTextBox;
		private System.Windows.Forms.GroupBox AdKeywordsGroupBox;
		private System.Windows.Forms.TextBox AdKeywordsTextBox;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.GroupBox AdNamesGroupBox;
		private System.Windows.Forms.TextBox AdNamesTextBox;
		private System.Windows.Forms.Label AdsTabInfo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Splitter splitter4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox OutputFormatGroupBox;
		private System.Windows.Forms.ComboBox OutputFormatBox;
	}
}

