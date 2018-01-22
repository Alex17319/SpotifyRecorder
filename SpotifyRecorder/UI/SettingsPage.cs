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
		private SettingsHost _settingsHost;

		public SettingsPage(SettingsHost settingsHost)
		{
			InitializeComponent();

			this._settingsHost = settingsHost;

			//Use Leave not LostFocus as it apparently works more sensibly
			//Source: https://social.msdn.microsoft.com/Forums/en-US/dd023378-d700-4c5f-a5b5-072fd4de7903/lostfocus-vs-leave-events?forum=Vsexpressvb
			AdNamesTextBox.Leave         += delegate { _settingsHost.AdNames = AdNamesTextBox.Lines.ToImmutableList(); };
			_settingsHost.AdNamesChanged += delegate { AdNamesTextBox.Text   = string.Concat(_settingsHost.AdNames);   };

			AdKeywordsTextBox.Leave         += delegate { _settingsHost.AdNames  = AdKeywordsTextBox.Lines.ToImmutableList(); };
			_settingsHost.AdKeywordsChanged += delegate { AdKeywordsTextBox.Text = string.Concat(_settingsHost.AdKeywords);   };

			SongNamesTextBox.Leave         += delegate { _settingsHost.SongNames = SongNamesTextBox.Lines.ToImmutableList(); };
			_settingsHost.SongNamesChanged += delegate { SongNamesTextBox.Text   = string.Concat(_settingsHost.SongNames);   };

			OutputFormatBox.SelectedIndexChanged += delegate {
				_settingsHost.OutputFormat = (OutputFormat)Enum.Parse(typeof(OutputFormat), OutputFormatBox.Text);
			};
			_settingsHost.OutputFormatChanged += delegate {
				OutputFormatBox.SelectedIndex = OutputFormatBox.Items.IndexOf(_settingsHost.OutputFormat.ToString());
			};
		}
	}
}
