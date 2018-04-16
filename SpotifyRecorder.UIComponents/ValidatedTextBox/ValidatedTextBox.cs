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
			get => base.Text;
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
				base.Text = newValue;
				// ^ Fires the base TextChanged event, which is weird that it gets fired before the
				// change-attempted event, but we have to do this first otherwise listeners for the
				// event below (including the code that syncs this with the settings) won't see the
				// new value.
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
