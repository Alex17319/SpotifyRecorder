using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec
{
	public partial class MainForm : Form
	{
		public RawSettings Settings { get; }

		public event EventHandler AdNamesChanged;
		public event EventHandler AdKeywordsChanged;
		public event EventHandler SongNamesChanged;
		public event EventHandler OutputFormatChanged;

		public MainForm()
		{
			InitializeComponent();

			//	this.AdNamesTextBox.LostFocus += delegate {
			//		if (!Enumerable.SequenceEqual(Settings.AdNames, AdNamesTextBox.Lines)) {
			//			AdNamesChanged?.Invoke(this, EventArgs.Empty);
			//		}
			//	};
			//	
			//	this.AdKeywordsTextBox.LostFocus += delegate {
			//		if (!Enumerable.SequenceEqual(Settings.AdKeywords, AdKeywordsTextBox.Lines)) {
			//			AdKeywordsChanged?.Invoke(this, EventArgs.Empty);
			//		}
			//	};
			//	
			//	this.SongNamesTextBox.LostFocus += delegate {
			//		if (!Enumerable.SequenceEqual(Settings.SongNames, SongNamesTextBox.Lines)) {
			//			SongNamesChanged?.Invoke(this, EventArgs.Empty);
			//		}
			//	};

		}
	}
}
