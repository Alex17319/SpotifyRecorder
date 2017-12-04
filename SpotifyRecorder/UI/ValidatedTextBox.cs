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
		/// <summary>
		/// A clearer way of expressing a match in a function used as <see cref="Predicate"/>. Equal to null.
		/// </summary>
		public const string InputValid = null;
		/// <summary>
		/// A clearer way of expressing a failed match in a function used as <see cref="Predicate"/>. Returns its input.
		/// </summary>
		public static string InputInvalid(string errorMessage) => errorMessage;

		/// <summary>
		/// A function that takes a string, returns null (i.e. <see cref="InputValid"/>) if it is valid,
		/// and returns an error message (or empty string) (i.e. <see cref="InputInvalid(string)"/>) if it is invalid.
		/// </summary>
		public Func<string, string> Predicate { get; set; }

		public bool ShowErrorDialog { get; set; }

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
