﻿namespace SpotifyRec
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
			this.PlaylistSortTab = new System.Windows.Forms.TabPage();
			this.AdsTab = new System.Windows.Forms.TabPage();
			this.SettingsTab = new System.Windows.Forms.TabPage();
			this.AboutTab = new System.Windows.Forms.TabPage();
			this.LogTextBox = new System.Windows.Forms.RichTextBox();
			this.LogGroupBox = new System.Windows.Forms.GroupBox();
			this.LogPanel = new System.Windows.Forms.Panel();
			this.MainHSplitter = new System.Windows.Forms.Splitter();
			this.MainTabs.SuspendLayout();
			this.LogGroupBox.SuspendLayout();
			this.LogPanel.SuspendLayout();
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
			this.MainTabs.Size = new System.Drawing.Size(355, 205);
			this.MainTabs.TabIndex = 0;
			// 
			// RecorderTab
			// 
			this.RecorderTab.Location = new System.Drawing.Point(4, 22);
			this.RecorderTab.Name = "RecorderTab";
			this.RecorderTab.Padding = new System.Windows.Forms.Padding(3);
			this.RecorderTab.Size = new System.Drawing.Size(347, 179);
			this.RecorderTab.TabIndex = 0;
			this.RecorderTab.Text = "Recording";
			this.RecorderTab.UseVisualStyleBackColor = true;
			// 
			// PlaylistSortTab
			// 
			this.PlaylistSortTab.Location = new System.Drawing.Point(4, 22);
			this.PlaylistSortTab.Name = "PlaylistSortTab";
			this.PlaylistSortTab.Padding = new System.Windows.Forms.Padding(3);
			this.PlaylistSortTab.Size = new System.Drawing.Size(347, 179);
			this.PlaylistSortTab.TabIndex = 1;
			this.PlaylistSortTab.Text = "Playlists";
			this.PlaylistSortTab.UseVisualStyleBackColor = true;
			// 
			// AdsTab
			// 
			this.AdsTab.Location = new System.Drawing.Point(4, 22);
			this.AdsTab.Name = "AdsTab";
			this.AdsTab.Padding = new System.Windows.Forms.Padding(3);
			this.AdsTab.Size = new System.Drawing.Size(347, 179);
			this.AdsTab.TabIndex = 2;
			this.AdsTab.Text = "Ads";
			this.AdsTab.UseVisualStyleBackColor = true;
			// 
			// SettingsTab
			// 
			this.SettingsTab.Location = new System.Drawing.Point(4, 22);
			this.SettingsTab.Name = "SettingsTab";
			this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
			this.SettingsTab.Size = new System.Drawing.Size(347, 179);
			this.SettingsTab.TabIndex = 3;
			this.SettingsTab.Text = "Settings";
			this.SettingsTab.UseVisualStyleBackColor = true;
			// 
			// AboutTab
			// 
			this.AboutTab.Location = new System.Drawing.Point(4, 22);
			this.AboutTab.Name = "AboutTab";
			this.AboutTab.Padding = new System.Windows.Forms.Padding(3);
			this.AboutTab.Size = new System.Drawing.Size(347, 179);
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
			this.LogTextBox.Size = new System.Drawing.Size(341, 136);
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
			this.LogGroupBox.Size = new System.Drawing.Size(347, 155);
			this.LogGroupBox.TabIndex = 3;
			this.LogGroupBox.TabStop = false;
			this.LogGroupBox.Text = "Log";
			// 
			// LogPanel
			// 
			this.LogPanel.Controls.Add(this.LogGroupBox);
			this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LogPanel.Location = new System.Drawing.Point(0, 205);
			this.LogPanel.MinimumSize = new System.Drawing.Size(100, 50);
			this.LogPanel.Name = "LogPanel";
			this.LogPanel.Padding = new System.Windows.Forms.Padding(4);
			this.LogPanel.Size = new System.Drawing.Size(355, 163);
			this.LogPanel.TabIndex = 4;
			// 
			// MainHSplitter
			// 
			this.MainHSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.MainHSplitter.Location = new System.Drawing.Point(0, 205);
			this.MainHSplitter.Name = "MainHSplitter";
			this.MainHSplitter.Size = new System.Drawing.Size(355, 3);
			this.MainHSplitter.TabIndex = 5;
			this.MainHSplitter.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 368);
			this.Controls.Add(this.MainHSplitter);
			this.Controls.Add(this.LogPanel);
			this.Controls.Add(this.MainTabs);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.MainTabs.ResumeLayout(false);
			this.LogGroupBox.ResumeLayout(false);
			this.LogPanel.ResumeLayout(false);
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
	}
}
