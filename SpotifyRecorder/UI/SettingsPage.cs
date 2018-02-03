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
		}


		public SettingsHost SettingsHost => MainController.SettingsHost;

		private MainController _mainController;
		public MainController MainController {
			get => _mainController;
			set {
				if (_mainController != null)
				{
					//Note: Use Leave not LostFocus as it apparently works more sensibly
					//Source: https://social.msdn.microsoft.com/Forums/en-US/dd023378-d700-4c5f-a5b5-072fd4de7903/lostfocus-vs-leave-events?forum=Vsexpressvb

					AdNamesTextBox.Leave        -= OnAdNamesUIChanged;
					SettingsHost.AdNamesChanged -= OnAdNamesSettingChanged;

					AdKeywordsTextBox.Leave        -= OnAdKeywordsUIChanged;
					SettingsHost.AdKeywordsChanged -= ONAdKeywordsSettingChanged;

					SongNamesTextBox.Leave        -= OnSongNamesUIChanged;
					SettingsHost.SongNamesChanged -= OnSongNamesSettingChanged;

					OutputFormatBox.SelectedIndexChanged -= OnOutputFormatUIChanged;
					SettingsHost.OutputFormatChanged     -= OnOutputFormatSettingChanged;
				}

				_mainController = value;

				if (_mainController != null)
				{
					AdNamesTextBox.Leave        += OnAdNamesUIChanged;
					SettingsHost.AdNamesChanged += OnAdNamesSettingChanged;

					AdKeywordsTextBox.Leave        += OnAdKeywordsUIChanged;
					SettingsHost.AdKeywordsChanged += ONAdKeywordsSettingChanged;

					SongNamesTextBox.Leave        += OnSongNamesUIChanged;
					SettingsHost.SongNamesChanged += OnSongNamesSettingChanged;

					OutputFormatBox.SelectedIndexChanged += OnOutputFormatUIChanged;
					SettingsHost.OutputFormatChanged     += OnOutputFormatSettingChanged;
				}

				void OnAdNamesUIChanged     (object sender, EventArgs e) => SettingsHost.AdNames = AdNamesTextBox.Lines.ToImmutableList();
				void OnAdNamesSettingChanged(object sender, EventArgs e) => AdNamesTextBox.Text  = string.Concat(SettingsHost.AdNames);

				void OnAdKeywordsUIChanged     (object sender, EventArgs e) => SettingsHost.AdNames   = AdKeywordsTextBox.Lines.ToImmutableList();
				void ONAdKeywordsSettingChanged(object sender, EventArgs e) => AdKeywordsTextBox.Text = string.Concat(SettingsHost.AdKeywords);

				void OnSongNamesUIChanged     (object sender, EventArgs e) => SettingsHost.SongNames = SongNamesTextBox.Lines.ToImmutableList();
				void OnSongNamesSettingChanged(object sender, EventArgs e) => SongNamesTextBox.Text  = string.Concat(SettingsHost.SongNames);

				void OnOutputFormatUIChanged     (object sender, EventArgs e) => SettingsHost.OutputFormat     = (OutputFormat)Enum.Parse(typeof(OutputFormat), OutputFormatBox.Text);
				void OnOutputFormatSettingChanged(object sender, EventArgs e) => OutputFormatBox.SelectedIndex = OutputFormatBox.Items.IndexOf(SettingsHost.OutputFormat.ToString());
			}
		}
	}
}
