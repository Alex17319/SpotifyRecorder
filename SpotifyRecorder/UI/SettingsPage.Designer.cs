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
			this.panel1 = new System.Windows.Forms.Panel();
			this.uniaxualResizePanel1 = new SpotifyRec.UI.UniaxualResizePanel();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.OutputFormatGroupBox = new System.Windows.Forms.GroupBox();
			this.OutputFormatBox = new System.Windows.Forms.ComboBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.InnerPanel = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.uniaxualResizePanel1.InnerPanel.SuspendLayout();
			this.OutputFormatGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.uniaxualResizePanel1);
			this.panel1.Controls.Add(this.OutputFormatGroupBox);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(347, 692);
			this.panel1.TabIndex = 10;
			// 
			// uniaxualResizePanel1
			// 
			this.uniaxualResizePanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			// 
			// uniaxualResizePanel1.InnerPanel
			// 
			this.uniaxualResizePanel1.InnerPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.uniaxualResizePanel1.InnerPanel.Controls.Add(this.textBox4);
			this.uniaxualResizePanel1.InnerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.uniaxualResizePanel1.InnerPanel.Location = new System.Drawing.Point(0, 0);
			this.uniaxualResizePanel1.InnerPanel.Name = "InnerPanel";
			this.uniaxualResizePanel1.InnerPanel.Size = new System.Drawing.Size(178, 107);
			this.uniaxualResizePanel1.InnerPanel.TabIndex = 0;
			this.uniaxualResizePanel1.LiveResize = true;
			this.uniaxualResizePanel1.Location = new System.Drawing.Point(30, 391);
			this.uniaxualResizePanel1.MaxExpandStep = 1000;
			this.uniaxualResizePanel1.MinSize = -3;
			this.uniaxualResizePanel1.Name = "uniaxualResizePanel1";
			this.uniaxualResizePanel1.ResizeDir = System.Windows.Forms.Orientation.Vertical;
			this.uniaxualResizePanel1.ResizerBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.uniaxualResizePanel1.ResizerThickness = 3;
			this.uniaxualResizePanel1.Size = new System.Drawing.Size(178, 110);
			this.uniaxualResizePanel1.TabIndex = 12;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(25, 26);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(177, 20);
			this.textBox4.TabIndex = 0;
			// 
			// OutputFormatGroupBox
			// 
			this.OutputFormatGroupBox.AutoSize = true;
			this.OutputFormatGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.OutputFormatGroupBox.Controls.Add(this.OutputFormatBox);
			this.OutputFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.OutputFormatGroupBox.Location = new System.Drawing.Point(0, 336);
			this.OutputFormatGroupBox.Name = "OutputFormatGroupBox";
			this.OutputFormatGroupBox.Size = new System.Drawing.Size(347, 40);
			this.OutputFormatGroupBox.TabIndex = 11;
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
			this.OutputFormatBox.Size = new System.Drawing.Size(341, 21);
			this.OutputFormatBox.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 331);
			this.splitter1.MinExtra = 0;
			this.splitter1.MinimumSize = new System.Drawing.Size(0, 5);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(347, 5);
			this.splitter1.TabIndex = 10;
			this.splitter1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.splitter4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(347, 331);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ad Classification";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.groupBox4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 240);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(341, 88);
			this.panel4.TabIndex = 6;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.textBox3);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(341, 88);
			this.groupBox4.TabIndex = 1;
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
			this.textBox3.Size = new System.Drawing.Size(335, 69);
			this.textBox3.TabIndex = 1;
			// 
			// splitter4
			// 
			this.splitter4.BackColor = System.Drawing.SystemColors.Window;
			this.splitter4.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new System.Drawing.Point(3, 235);
			this.splitter4.MinExtra = 0;
			this.splitter4.MinimumSize = new System.Drawing.Size(0, 5);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(341, 5);
			this.splitter4.TabIndex = 3;
			this.splitter4.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Controls.Add(this.splitter3);
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(3, 128);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(341, 107);
			this.panel3.TabIndex = 2;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(205, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 107);
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
			this.textBox1.Size = new System.Drawing.Size(130, 88);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "spotify\r\nlisten now\r\nclick here\r\nclick the banner\r\nget premium";
			// 
			// splitter3
			// 
			this.splitter3.BackColor = System.Drawing.SystemColors.Window;
			this.splitter3.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.splitter3.Location = new System.Drawing.Point(200, 0);
			this.splitter3.MinimumSize = new System.Drawing.Size(5, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(5, 107);
			this.splitter3.TabIndex = 1;
			this.splitter3.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 107);
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
			this.textBox2.Size = new System.Drawing.Size(194, 88);
			this.textBox2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(3);
			this.label1.Size = new System.Drawing.Size(341, 112);
			this.label1.TabIndex = 1;
			this.label1.Text = resources.GetString("label1.Text");
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
			// SettingsPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(370, 100);
			this.Name = "SettingsPage";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(353, 448);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.uniaxualResizePanel1.InnerPanel.ResumeLayout(false);
			this.uniaxualResizePanel1.InnerPanel.PerformLayout();
			this.OutputFormatGroupBox.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox OutputFormatGroupBox;
		private System.Windows.Forms.ComboBox OutputFormatBox;
		private System.Windows.Forms.Splitter splitter1;
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
		private UniaxualResizePanel uniaxualResizePanel1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Panel InnerPanel;
	}
}
