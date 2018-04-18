namespace SpotifyRec.Player
{
	partial class PlayerPage
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.centeredPanel1 = new SpotifyRec.UIComponents.CenteredPanel();
			this.VolUpButton = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.VolDownButton = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.MuteButton = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.SkipManyButton = new System.Windows.Forms.Button();
			this.ReshuffleButton = new System.Windows.Forms.Button();
			this.centeredPanel2 = new SpotifyRec.UIComponents.CenteredPanel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.NextButton = new System.Windows.Forms.Button();
			this.panel10 = new System.Windows.Forms.Panel();
			this.PlayPauseButton = new System.Windows.Forms.Button();
			this.PrevButton = new System.Windows.Forms.Button();
			this.SongFilteringResizablePanel = new SpotifyRec.UI.ResizablePanel();
			this.FilteringGroupBox = new System.Windows.Forms.GroupBox();
			this.FiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.FiltersTextBox = new System.Windows.Forms.TextBox();
			this.FilterCheckBox = new System.Windows.Forms.CheckBox();
			this.DuplicateSkippingResizablePanel = new SpotifyRec.UI.ResizablePanel();
			this.DuplicateSkippingGroupBox = new System.Windows.Forms.GroupBox();
			this.HistoryGroupBox = new System.Windows.Forms.GroupBox();
			this.HistoryTextBox = new System.Windows.Forms.TextBox();
			this.RecordHistoryCheckBox = new System.Windows.Forms.CheckBox();
			this.SkipDuplicatesCheckBox = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.centeredPanel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.centeredPanel2.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.SongFilteringResizablePanel.InnerPanel.SuspendLayout();
			this.SongFilteringResizablePanel.SuspendLayout();
			this.FilteringGroupBox.SuspendLayout();
			this.FiltersGroupBox.SuspendLayout();
			this.DuplicateSkippingResizablePanel.InnerPanel.SuspendLayout();
			this.DuplicateSkippingResizablePanel.SuspendLayout();
			this.DuplicateSkippingGroupBox.SuspendLayout();
			this.HistoryGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 30);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(347, 50);
			this.panel1.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(337, 40);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Volume";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.centeredPanel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 16);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(331, 21);
			this.panel2.TabIndex = 13;
			// 
			// centeredPanel1
			// 
			this.centeredPanel1.AutoSize = true;
			this.centeredPanel1.Controls.Add(this.VolUpButton);
			this.centeredPanel1.Controls.Add(this.panel3);
			this.centeredPanel1.Controls.Add(this.panel4);
			this.centeredPanel1.FractionalSize = new System.Drawing.SizeF(0F, 1F);
			this.centeredPanel1.HorizontalAlignment = 0.5F;
			this.centeredPanel1.Location = new System.Drawing.Point(60, 0);
			this.centeredPanel1.Name = "centeredPanel1";
			this.centeredPanel1.Size = new System.Drawing.Size(212, 21);
			this.centeredPanel1.TabIndex = 12;
			this.centeredPanel1.VerticalAlignment = 0F;
			// 
			// VolUpButton
			// 
			this.VolUpButton.AutoSize = true;
			this.VolUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.VolUpButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.VolUpButton.Location = new System.Drawing.Point(8, 0);
			this.VolUpButton.Margin = new System.Windows.Forms.Padding(0);
			this.VolUpButton.Name = "VolUpButton";
			this.VolUpButton.Size = new System.Drawing.Size(46, 21);
			this.VolUpButton.TabIndex = 14;
			this.VolUpButton.Text = "Up 🔈+";
			this.VolUpButton.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.AutoSize = true;
			this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel3.Controls.Add(this.VolDownButton);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(54, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(57, 21);
			this.panel3.TabIndex = 12;
			// 
			// VolDownButton
			// 
			this.VolDownButton.AutoSize = true;
			this.VolDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.VolDownButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.VolDownButton.Location = new System.Drawing.Point(0, 0);
			this.VolDownButton.Margin = new System.Windows.Forms.Padding(0);
			this.VolDownButton.Name = "VolDownButton";
			this.VolDownButton.Size = new System.Drawing.Size(57, 21);
			this.VolDownButton.TabIndex = 2;
			this.VolDownButton.Text = "Down 🔈-";
			this.VolDownButton.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.AutoSize = true;
			this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel4.Controls.Add(this.MuteButton);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new System.Drawing.Point(111, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(101, 21);
			this.panel4.TabIndex = 10;
			// 
			// MuteButton
			// 
			this.MuteButton.AutoSize = true;
			this.MuteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.MuteButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MuteButton.Location = new System.Drawing.Point(0, 0);
			this.MuteButton.Margin = new System.Windows.Forms.Padding(0);
			this.MuteButton.Name = "MuteButton";
			this.MuteButton.Size = new System.Drawing.Size(101, 21);
			this.MuteButton.TabIndex = 2;
			this.MuteButton.Text = "Mute/Unmute 🔇 ";
			this.MuteButton.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.SkipManyButton);
			this.panel6.Controls.Add(this.ReshuffleButton);
			this.panel6.Controls.Add(this.centeredPanel2);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 3);
			this.panel6.MaximumSize = new System.Drawing.Size(0, 27);
			this.panel6.MinimumSize = new System.Drawing.Size(0, 27);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(3);
			this.panel6.Size = new System.Drawing.Size(347, 27);
			this.panel6.TabIndex = 6;
			// 
			// SkipManyButton
			// 
			this.SkipManyButton.AutoSize = true;
			this.SkipManyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.SkipManyButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.SkipManyButton.Location = new System.Drawing.Point(291, 3);
			this.SkipManyButton.Margin = new System.Windows.Forms.Padding(0);
			this.SkipManyButton.Name = "SkipManyButton";
			this.SkipManyButton.Size = new System.Drawing.Size(53, 21);
			this.SkipManyButton.TabIndex = 13;
			this.SkipManyButton.Text = "Skip 10";
			this.SkipManyButton.UseVisualStyleBackColor = true;
			// 
			// ReshuffleButton
			// 
			this.ReshuffleButton.AutoSize = true;
			this.ReshuffleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ReshuffleButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.ReshuffleButton.Location = new System.Drawing.Point(3, 3);
			this.ReshuffleButton.Margin = new System.Windows.Forms.Padding(0);
			this.ReshuffleButton.Name = "ReshuffleButton";
			this.ReshuffleButton.Size = new System.Drawing.Size(62, 21);
			this.ReshuffleButton.TabIndex = 12;
			this.ReshuffleButton.Text = "Reshuffle";
			this.ReshuffleButton.UseVisualStyleBackColor = true;
			// 
			// centeredPanel2
			// 
			this.centeredPanel2.AutoSize = true;
			this.centeredPanel2.Controls.Add(this.panel9);
			this.centeredPanel2.Controls.Add(this.panel10);
			this.centeredPanel2.Controls.Add(this.PrevButton);
			this.centeredPanel2.FractionalSize = new System.Drawing.SizeF(0F, 1F);
			this.centeredPanel2.HorizontalAlignment = 0.5F;
			this.centeredPanel2.Location = new System.Drawing.Point(80, 0);
			this.centeredPanel2.Name = "centeredPanel2";
			this.centeredPanel2.Padding = new System.Windows.Forms.Padding(3);
			this.centeredPanel2.Size = new System.Drawing.Size(186, 27);
			this.centeredPanel2.TabIndex = 11;
			this.centeredPanel2.VerticalAlignment = 0F;
			// 
			// panel9
			// 
			this.panel9.AutoSize = true;
			this.panel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel9.Controls.Add(this.NextButton);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel9.Location = new System.Drawing.Point(125, 3);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(50, 21);
			this.panel9.TabIndex = 7;
			// 
			// NextButton
			// 
			this.NextButton.AutoSize = true;
			this.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NextButton.Location = new System.Drawing.Point(0, 0);
			this.NextButton.Margin = new System.Windows.Forms.Padding(0);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(50, 21);
			this.NextButton.TabIndex = 2;
			this.NextButton.Text = "Next ⏩";
			this.NextButton.UseVisualStyleBackColor = true;
			// 
			// panel10
			// 
			this.panel10.AutoSize = true;
			this.panel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel10.Controls.Add(this.PlayPauseButton);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel10.Location = new System.Drawing.Point(53, 3);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(72, 21);
			this.panel10.TabIndex = 6;
			// 
			// PlayPauseButton
			// 
			this.PlayPauseButton.AutoSize = true;
			this.PlayPauseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.PlayPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlayPauseButton.Location = new System.Drawing.Point(0, 0);
			this.PlayPauseButton.Margin = new System.Windows.Forms.Padding(0);
			this.PlayPauseButton.Name = "PlayPauseButton";
			this.PlayPauseButton.Size = new System.Drawing.Size(72, 21);
			this.PlayPauseButton.TabIndex = 2;
			this.PlayPauseButton.Text = "Play/Pause";
			this.PlayPauseButton.UseVisualStyleBackColor = true;
			// 
			// PrevButton
			// 
			this.PrevButton.AutoSize = true;
			this.PrevButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.PrevButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.PrevButton.Location = new System.Drawing.Point(3, 3);
			this.PrevButton.Name = "PrevButton";
			this.PrevButton.Size = new System.Drawing.Size(50, 21);
			this.PrevButton.TabIndex = 5;
			this.PrevButton.Text = "⏪ Prev";
			this.PrevButton.UseVisualStyleBackColor = true;
			// 
			// SongFilteringResizablePanel
			// 
			this.SongFilteringResizablePanel.BackColor = System.Drawing.SystemColors.Control;
			this.SongFilteringResizablePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.SongFilteringResizablePanel.InnerPadding = new System.Windows.Forms.Padding(0);
			// 
			// SongFilteringResizablePanel.InnerPanel
			// 
			this.SongFilteringResizablePanel.InnerPanel.BackColor = System.Drawing.SystemColors.Window;
			this.SongFilteringResizablePanel.InnerPanel.Controls.Add(this.FilteringGroupBox);
			this.SongFilteringResizablePanel.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SongFilteringResizablePanel.InnerPanel.Location = new System.Drawing.Point(0, 0);
			this.SongFilteringResizablePanel.InnerPanel.MinimumSize = new System.Drawing.Size(0, 155);
			this.SongFilteringResizablePanel.InnerPanel.Name = "InnerPanel";
			this.SongFilteringResizablePanel.InnerPanel.Size = new System.Drawing.Size(347, 155);
			this.SongFilteringResizablePanel.InnerPanel.TabIndex = 0;
			this.SongFilteringResizablePanel.Location = new System.Drawing.Point(3, 275);
			this.SongFilteringResizablePanel.MinimumSize = new System.Drawing.Size(0, 160);
			this.SongFilteringResizablePanel.Name = "SongFilteringResizablePanel";
			this.SongFilteringResizablePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.SongFilteringResizablePanel.ResizerSizes = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.SongFilteringResizablePanel.Size = new System.Drawing.Size(347, 160);
			this.SongFilteringResizablePanel.TabIndex = 5;
			this.SongFilteringResizablePanel.Text = "resizablePanel2";
			// 
			// FilteringGroupBox
			// 
			this.FilteringGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.FilteringGroupBox.Controls.Add(this.FiltersGroupBox);
			this.FilteringGroupBox.Controls.Add(this.FilterCheckBox);
			this.FilteringGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FilteringGroupBox.Location = new System.Drawing.Point(0, 0);
			this.FilteringGroupBox.Name = "FilteringGroupBox";
			this.FilteringGroupBox.Size = new System.Drawing.Size(347, 155);
			this.FilteringGroupBox.TabIndex = 0;
			this.FilteringGroupBox.TabStop = false;
			this.FilteringGroupBox.Text = "Song Filtering";
			// 
			// FiltersGroupBox
			// 
			this.FiltersGroupBox.Controls.Add(this.FiltersTextBox);
			this.FiltersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FiltersGroupBox.Location = new System.Drawing.Point(3, 33);
			this.FiltersGroupBox.Name = "FiltersGroupBox";
			this.FiltersGroupBox.Size = new System.Drawing.Size(341, 119);
			this.FiltersGroupBox.TabIndex = 3;
			this.FiltersGroupBox.TabStop = false;
			this.FiltersGroupBox.Text = "Filters (using Microsoft\'s version of Regex)";
			// 
			// FiltersTextBox
			// 
			this.FiltersTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FiltersTextBox.Location = new System.Drawing.Point(3, 16);
			this.FiltersTextBox.Multiline = true;
			this.FiltersTextBox.Name = "FiltersTextBox";
			this.FiltersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.FiltersTextBox.Size = new System.Drawing.Size(335, 100);
			this.FiltersTextBox.TabIndex = 0;
			// 
			// FilterCheckBox
			// 
			this.FilterCheckBox.AutoSize = true;
			this.FilterCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.FilterCheckBox.Location = new System.Drawing.Point(3, 16);
			this.FilterCheckBox.Name = "FilterCheckBox";
			this.FilterCheckBox.Size = new System.Drawing.Size(341, 17);
			this.FilterCheckBox.TabIndex = 0;
			this.FilterCheckBox.Text = "Filter Songs";
			this.FilterCheckBox.UseVisualStyleBackColor = true;
			// 
			// DuplicateSkippingResizablePanel
			// 
			this.DuplicateSkippingResizablePanel.BackColor = System.Drawing.SystemColors.Control;
			this.DuplicateSkippingResizablePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.DuplicateSkippingResizablePanel.InnerPadding = new System.Windows.Forms.Padding(0);
			// 
			// DuplicateSkippingResizablePanel.InnerPanel
			// 
			this.DuplicateSkippingResizablePanel.InnerPanel.BackColor = System.Drawing.SystemColors.Window;
			this.DuplicateSkippingResizablePanel.InnerPanel.Controls.Add(this.DuplicateSkippingGroupBox);
			this.DuplicateSkippingResizablePanel.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DuplicateSkippingResizablePanel.InnerPanel.Location = new System.Drawing.Point(0, 0);
			this.DuplicateSkippingResizablePanel.InnerPanel.MinimumSize = new System.Drawing.Size(0, 190);
			this.DuplicateSkippingResizablePanel.InnerPanel.Name = "InnerPanel";
			this.DuplicateSkippingResizablePanel.InnerPanel.Size = new System.Drawing.Size(347, 190);
			this.DuplicateSkippingResizablePanel.InnerPanel.TabIndex = 0;
			this.DuplicateSkippingResizablePanel.Location = new System.Drawing.Point(3, 80);
			this.DuplicateSkippingResizablePanel.MinimumSize = new System.Drawing.Size(0, 195);
			this.DuplicateSkippingResizablePanel.Name = "DuplicateSkippingResizablePanel";
			this.DuplicateSkippingResizablePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.DuplicateSkippingResizablePanel.ResizerSizes = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.DuplicateSkippingResizablePanel.Size = new System.Drawing.Size(347, 195);
			this.DuplicateSkippingResizablePanel.TabIndex = 4;
			this.DuplicateSkippingResizablePanel.Text = "resizablePanel1";
			// 
			// DuplicateSkippingGroupBox
			// 
			this.DuplicateSkippingGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.DuplicateSkippingGroupBox.Controls.Add(this.HistoryGroupBox);
			this.DuplicateSkippingGroupBox.Controls.Add(this.RecordHistoryCheckBox);
			this.DuplicateSkippingGroupBox.Controls.Add(this.SkipDuplicatesCheckBox);
			this.DuplicateSkippingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DuplicateSkippingGroupBox.Location = new System.Drawing.Point(0, 0);
			this.DuplicateSkippingGroupBox.Name = "DuplicateSkippingGroupBox";
			this.DuplicateSkippingGroupBox.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
			this.DuplicateSkippingGroupBox.Size = new System.Drawing.Size(347, 190);
			this.DuplicateSkippingGroupBox.TabIndex = 2;
			this.DuplicateSkippingGroupBox.TabStop = false;
			this.DuplicateSkippingGroupBox.Text = "Duplicate Skipping";
			// 
			// HistoryGroupBox
			// 
			this.HistoryGroupBox.Controls.Add(this.HistoryTextBox);
			this.HistoryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HistoryGroupBox.Location = new System.Drawing.Point(7, 60);
			this.HistoryGroupBox.Name = "HistoryGroupBox";
			this.HistoryGroupBox.Size = new System.Drawing.Size(333, 125);
			this.HistoryGroupBox.TabIndex = 2;
			this.HistoryGroupBox.TabStop = false;
			this.HistoryGroupBox.Text = "History (Duplicates to Skip)";
			// 
			// HistoryTextBox
			// 
			this.HistoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HistoryTextBox.Location = new System.Drawing.Point(3, 16);
			this.HistoryTextBox.Multiline = true;
			this.HistoryTextBox.Name = "HistoryTextBox";
			this.HistoryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.HistoryTextBox.Size = new System.Drawing.Size(327, 106);
			this.HistoryTextBox.TabIndex = 0;
			// 
			// RecordHistoryCheckBox
			// 
			this.RecordHistoryCheckBox.AutoSize = true;
			this.RecordHistoryCheckBox.Checked = true;
			this.RecordHistoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.RecordHistoryCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.RecordHistoryCheckBox.Location = new System.Drawing.Point(7, 39);
			this.RecordHistoryCheckBox.Name = "RecordHistoryCheckBox";
			this.RecordHistoryCheckBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.RecordHistoryCheckBox.Size = new System.Drawing.Size(333, 21);
			this.RecordHistoryCheckBox.TabIndex = 1;
			this.RecordHistoryCheckBox.Text = "Record History to Detect Duplicates";
			this.RecordHistoryCheckBox.UseVisualStyleBackColor = true;
			// 
			// SkipDuplicatesCheckBox
			// 
			this.SkipDuplicatesCheckBox.AutoSize = true;
			this.SkipDuplicatesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.SkipDuplicatesCheckBox.Location = new System.Drawing.Point(7, 18);
			this.SkipDuplicatesCheckBox.Name = "SkipDuplicatesCheckBox";
			this.SkipDuplicatesCheckBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.SkipDuplicatesCheckBox.Size = new System.Drawing.Size(333, 21);
			this.SkipDuplicatesCheckBox.TabIndex = 0;
			this.SkipDuplicatesCheckBox.Text = "Skip Duplicates";
			this.SkipDuplicatesCheckBox.UseVisualStyleBackColor = true;
			// 
			// PlayerPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.SongFilteringResizablePanel);
			this.Controls.Add(this.DuplicateSkippingResizablePanel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel6);
			this.MinimumSize = new System.Drawing.Size(370, 100);
			this.Name = "PlayerPage";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(353, 381);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.centeredPanel1.ResumeLayout(false);
			this.centeredPanel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.centeredPanel2.ResumeLayout(false);
			this.centeredPanel2.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.SongFilteringResizablePanel.InnerPanel.ResumeLayout(false);
			this.SongFilteringResizablePanel.ResumeLayout(false);
			this.FilteringGroupBox.ResumeLayout(false);
			this.FilteringGroupBox.PerformLayout();
			this.FiltersGroupBox.ResumeLayout(false);
			this.FiltersGroupBox.PerformLayout();
			this.DuplicateSkippingResizablePanel.InnerPanel.ResumeLayout(false);
			this.DuplicateSkippingResizablePanel.ResumeLayout(false);
			this.DuplicateSkippingGroupBox.ResumeLayout(false);
			this.DuplicateSkippingGroupBox.PerformLayout();
			this.HistoryGroupBox.ResumeLayout(false);
			this.HistoryGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox DuplicateSkippingGroupBox;
		private System.Windows.Forms.GroupBox HistoryGroupBox;
		private System.Windows.Forms.CheckBox RecordHistoryCheckBox;
		private System.Windows.Forms.CheckBox SkipDuplicatesCheckBox;
		private System.Windows.Forms.Panel panel1;
		private UI.ResizablePanel DuplicateSkippingResizablePanel;
		private System.Windows.Forms.TextBox HistoryTextBox;
		private UI.ResizablePanel SongFilteringResizablePanel;
		private System.Windows.Forms.GroupBox FilteringGroupBox;
		private System.Windows.Forms.GroupBox FiltersGroupBox;
		private System.Windows.Forms.TextBox FiltersTextBox;
		private System.Windows.Forms.CheckBox FilterCheckBox;
		private System.Windows.Forms.Panel panel6;
		private UIComponents.CenteredPanel centeredPanel2;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Button PlayPauseButton;
		private System.Windows.Forms.Button PrevButton;
		private System.Windows.Forms.Button SkipManyButton;
		private System.Windows.Forms.Button ReshuffleButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private UIComponents.CenteredPanel centeredPanel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button VolDownButton;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button MuteButton;
		private System.Windows.Forms.Button VolUpButton;
	}
}
