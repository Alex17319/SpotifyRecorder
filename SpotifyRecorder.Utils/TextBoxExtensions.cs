using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec.Utils
{
	public static class TextBoxExtensions
	{
		public static void AppendFormattedText(this RichTextBox textBox, string text, Action<RichTextBox> formatter)
		{
			textBox.AppendText(text);
			FormatRange(
				textBox: textBox,
				start: textBox.TextLength - text.Length,
				length: text.Length,
				formatter: formatter
			);
		}

		public static void FormatRange(this RichTextBox textBox, int start, int length, Action<RichTextBox> formatter)
		{
			if (textBox == null) throw new ArgumentNullException(nameof(textBox));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));
			if (start >= textBox.TextLength) throw new ArgumentOutOfRangeException(nameof(start), "Must be less than textBox.TextLength '" + textBox.TextLength + "'.");
			if (length > textBox.TextLength - start) throw new ArgumentOutOfRangeException(nameof(length), "Must be less than textBox.TextLength '" + textBox.TextLength + "' - start '" + start + "'.");

			var oldSelectionStart = textBox.SelectionStart;
			var oldSelectionLength = textBox.SelectionLength;

			try
			{
				textBox.Select(start, length);

				formatter(textBox);
			}
			finally
			{
				textBox.SelectionStart = oldSelectionStart;
				textBox.SelectionLength = oldSelectionLength;
			}
		}
	}
}
