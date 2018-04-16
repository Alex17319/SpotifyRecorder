namespace SpotifyRec.Full
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
			this.MainTabs = new System.Windows.Forms.TabControl();
			this.RecorderTab = new System.Windows.Forms.TabPage();
			this.RecordingPage = new SpotifyRec.UI.RecordingPage();
			this.PlaylistsTab = new System.Windows.Forms.TabPage();
			this.PlayerTab = new System.Windows.Forms.TabPage();
			this.AdsTab = new System.Windows.Forms.TabPage();
			this.SettingsTab = new System.Windows.Forms.TabPage();
			this.SettingsPage = new SpotifyRec.UI.SettingsPage();
			this.AboutTab = new System.Windows.Forms.TabPage();
			this.LogTextBox = new System.Windows.Forms.RichTextBox();
			this.LogGroupBox = new System.Windows.Forms.GroupBox();
			this.LogPanel = new System.Windows.Forms.Panel();
			this.MainHSplitter = new System.Windows.Forms.Splitter();
			this.MainTabs.SuspendLayout();
			this.RecorderTab.SuspendLayout();
			this.SettingsTab.SuspendLayout();
			this.LogGroupBox.SuspendLayout();
			this.LogPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainTabs
			// 
			this.MainTabs.Controls.Add(this.RecorderTab);
			this.MainTabs.Controls.Add(this.PlaylistsTab);
			this.MainTabs.Controls.Add(this.PlayerTab);
			this.MainTabs.Controls.Add(this.AdsTab);
			this.MainTabs.Controls.Add(this.SettingsTab);
			this.MainTabs.Controls.Add(this.AboutTab);
			this.MainTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this.MainTabs.Location = new System.Drawing.Point(0, 0);
			this.MainTabs.Name = "MainTabs";
			this.MainTabs.SelectedIndex = 0;
			this.MainTabs.Size = new System.Drawing.Size(392, 300);
			this.MainTabs.TabIndex = 0;
			// 
			// RecorderTab
			// 
			this.RecorderTab.Controls.Add(this.RecordingPage);
			this.RecorderTab.Location = new System.Drawing.Point(4, 22);
			this.RecorderTab.Name = "RecorderTab";
			this.RecorderTab.Padding = new System.Windows.Forms.Padding(3);
			this.RecorderTab.Size = new System.Drawing.Size(384, 274);
			this.RecorderTab.TabIndex = 0;
			this.RecorderTab.Text = "Recording";
			this.RecorderTab.UseVisualStyleBackColor = true;
			// 
			// RecordingPage
			// 
			this.RecordingPage.BackColor = System.Drawing.SystemColors.Window;
			this.RecordingPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RecordingPage.Location = new System.Drawing.Point(3, 3);
			this.RecordingPage.MainController = null;
			this.RecordingPage.Name = "RecordingPage";
			this.RecordingPage.Size = new System.Drawing.Size(378, 268);
			this.RecordingPage.TabIndex = 0;
			// 
			// PlaylistsTab
			// 
			this.PlaylistsTab.Location = new System.Drawing.Point(4, 22);
			this.PlaylistsTab.Name = "PlaylistsTab";
			this.PlaylistsTab.Padding = new System.Windows.Forms.Padding(3);
			this.PlaylistsTab.Size = new System.Drawing.Size(384, 569);
			this.PlaylistsTab.TabIndex = 1;
			this.PlaylistsTab.Text = "Playlists";
			this.PlaylistsTab.UseVisualStyleBackColor = true;
			// 
			// PlayerTab
			// 
			this.PlayerTab.Location = new System.Drawing.Point(4, 22);
			this.PlayerTab.Name = "PlayerTab";
			this.PlayerTab.Padding = new System.Windows.Forms.Padding(3);
			this.PlayerTab.Size = new System.Drawing.Size(384, 569);
			this.PlayerTab.TabIndex = 5;
			this.PlayerTab.Text = "Advanced Player";
			this.PlayerTab.UseVisualStyleBackColor = true;
			// 
			// AdsTab
			// 
			this.AdsTab.Location = new System.Drawing.Point(4, 22);
			this.AdsTab.Name = "AdsTab";
			this.AdsTab.Padding = new System.Windows.Forms.Padding(3);
			this.AdsTab.Size = new System.Drawing.Size(384, 569);
			this.AdsTab.TabIndex = 2;
			this.AdsTab.Text = "Ads";
			this.AdsTab.UseVisualStyleBackColor = true;
			// 
			// SettingsTab
			// 
			this.SettingsTab.AutoScroll = true;
			this.SettingsTab.Controls.Add(this.SettingsPage);
			this.SettingsTab.Location = new System.Drawing.Point(4, 22);
			this.SettingsTab.Name = "SettingsTab";
			this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
			this.SettingsTab.Size = new System.Drawing.Size(384, 569);
			this.SettingsTab.TabIndex = 3;
			this.SettingsTab.Text = "Settings";
			this.SettingsTab.UseVisualStyleBackColor = true;
			// 
			// SettingsPage
			// 
			this.SettingsPage.AutoScroll = true;
			this.SettingsPage.BackColor = System.Drawing.SystemColors.Window;
			this.SettingsPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SettingsPage.Location = new System.Drawing.Point(3, 3);
			this.SettingsPage.MainController = null;
			this.SettingsPage.MinimumSize = new System.Drawing.Size(370, 100);
			this.SettingsPage.Name = "SettingsPage";
			this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
			this.SettingsPage.Size = new System.Drawing.Size(378, 563);
			this.SettingsPage.TabIndex = 0;
			// 
			// AboutTab
			// 
			this.AboutTab.Location = new System.Drawing.Point(4, 22);
			this.AboutTab.Name = "AboutTab";
			this.AboutTab.Padding = new System.Windows.Forms.Padding(3);
			this.AboutTab.Size = new System.Drawing.Size(384, 569);
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
			this.LogTextBox.Size = new System.Drawing.Size(378, 96);
			this.LogTextBox.TabIndex = 2;
			this.LogTextBox.Text = "";
			this.LogTextBox.WordWrap = false;
			// 
			// LogGroupBox
			// 
			this.LogGroupBox.Controls.Add(this.LogTextBox);
			this.LogGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogGroupBox.Location = new System.Drawing.Point(4, 4);
			this.LogGroupBox.Name = "LogGroupBox";
			this.LogGroupBox.Size = new System.Drawing.Size(384, 115);
			this.LogGroupBox.TabIndex = 3;
			this.LogGroupBox.TabStop = false;
			this.LogGroupBox.Text = "Log";
			// 
			// LogPanel
			// 
			this.LogPanel.Controls.Add(this.LogGroupBox);
			this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogPanel.Location = new System.Drawing.Point(0, 300);
			this.LogPanel.MinimumSize = new System.Drawing.Size(100, 50);
			this.LogPanel.Name = "LogPanel";
			this.LogPanel.Padding = new System.Windows.Forms.Padding(4);
			this.LogPanel.Size = new System.Drawing.Size(392, 123);
			this.LogPanel.TabIndex = 4;
			// 
			// MainHSplitter
			// 
			this.MainHSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.MainHSplitter.Location = new System.Drawing.Point(0, 300);
			this.MainHSplitter.Name = "MainHSplitter";
			this.MainHSplitter.Size = new System.Drawing.Size(392, 3);
			this.MainHSplitter.TabIndex = 5;
			this.MainHSplitter.TabStop = false;
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
			this.Text = "Spotify Recorder";
			this.MainTabs.ResumeLayout(false);
			this.RecorderTab.ResumeLayout(false);
			this.SettingsTab.ResumeLayout(false);
			this.LogGroupBox.ResumeLayout(false);
			this.LogPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl MainTabs;
		private System.Windows.Forms.TabPage RecorderTab;
		private System.Windows.Forms.TabPage PlaylistsTab;
		private System.Windows.Forms.Panel LogPanel;
		private System.Windows.Forms.GroupBox LogGroupBox;
		private System.Windows.Forms.RichTextBox LogTextBox;
		private System.Windows.Forms.Splitter MainHSplitter;
		private System.Windows.Forms.TabPage AdsTab;
		private System.Windows.Forms.TabPage SettingsTab;
		private System.Windows.Forms.TabPage AboutTab;
		private UI.SettingsPage SettingsPage;
		private UI.RecordingPage RecordingPage;
		private System.Windows.Forms.TabPage PlayerTab;
	}
}

