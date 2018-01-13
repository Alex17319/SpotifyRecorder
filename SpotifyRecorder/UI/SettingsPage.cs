using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Immutable;

namespace SpotifyRec.UI
{
	public partial class SettingsPage : UserControl
	{
		public SettingsPage()
		{
			InitializeComponent();

			var settingsHost = new SettingsHost(RawSettings.Default);

			//Use Leave no LostFocus as it works better
			//Source: https://social.msdn.microsoft.com/Forums/en-US/dd023378-d700-4c5f-a5b5-072fd4de7903/lostfocus-vs-leave-events?forum=Vsexpressvb
			this.AdNamesTextBox.Leave   += delegate { settingsHost.AdNames = this.AdNamesTextBox.Lines.ToImmutableList(); };
			settingsHost.AdNamesChanged += delegate { this.AdNamesTextBox.Text = string.Concat(settingsHost.AdNames); };

			this.AdKeywordsTextBox.Leave   += delegate { settingsHost.AdNames = this.AdKeywordsTextBox.Lines.ToImmutableList(); };
			settingsHost.AdKeywordsChanged += delegate { this.AdKeywordsTextBox.Text = string.Concat(settingsHost.AdKeywords); };

			this.SongNamesTextBox.Leave   += delegate { settingsHost.SongNames = this.SongNamesTextBox.Lines.ToImmutableList(); };
			settingsHost.SongNamesChanged += delegate { this.SongNamesTextBox.Text = string.Concat(settingsHost.SongNames); };

			this.OutputFormatBox.SelectedIndexChanged += delegate {
				settingsHost.OutputFormat = (OutputFormat)Enum.Parse(typeof(OutputFormat), this.OutputFormatBox.Text);
			};
			settingsHost.OutputFormatChanged += delegate {
				this.OutputFormatBox.SelectedIndex = this.OutputFormatBox.Items.IndexOf(settingsHost.OutputFormat.ToString());
			};
		}
	}
}
