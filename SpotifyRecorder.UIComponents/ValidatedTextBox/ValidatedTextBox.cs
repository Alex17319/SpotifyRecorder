using SpotifyRec.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolioWebGen.WinForms
{
	public partial class ValidatedTextBox : TextBox
	{
		public Validator<string> Predicate { get; set; }

		public bool ShowErrorDialog { get; set; }

		private string _text;
		// ^ Can't just use base.Text as that makes it hard to control the order of event - the text needs
		// to be set before any events can be fired, but the 'change-attempted' event should fire before
		// the 'changed' event (which updating base.Text triggers)
		public override string Text {
			get => _text;
			set {
				TrySetText(value);
			}
		}
		public bool TrySetText(string newValue)
		{
			string errorMsg;
			if (Predicate != null && (errorMsg = Predicate(newValue)) != null)
			{
				if (ShowErrorDialog)
				{
					MessageBox.Show(
						text: errorMsg,
						caption: "Invalid Input",
						buttons: MessageBoxButtons.OK,
						icon: MessageBoxIcon.Exclamation
					);
				}

				TextChangeAttempted?.Invoke(this, new AttemptEventArgs(success: false));

				return false;
			}
			else
			{
				this._text = newValue;
				base.Text = newValue;
				// ^ Fires the base TextChanged event,
				TextChangeAttempted?.Invoke(this, new AttemptEventArgs(success: true));

				return true;
			}
		}

		public event EventHandler<AttemptEventArgs> TextChangeAttempted;
		

		public ValidatedTextBox()
		{
			InitializeComponent();
		}
	}
}
