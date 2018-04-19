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
		/// <summary>
		/// NOTE: Formatter must return an action that is used to reset the formatting to whatever
		/// it was before formatter was called. In some cases this may not be possible,
		/// so either don't use that formatting, store a set default, or else the
		/// new formatting may carry over into subsequent appends/inserts.
		/// </summary>
		public static void AppendFormattedText(this RichTextBox textBox, string text, Func<RichTextBox, Action> formatter)
		{
			//The methods of formatting text in a RichTextBox affect both the currently selected text,
			//and any text typed after the current cursor position. In some cases this latter point only
			//applies if there is no selection, in other cases it always applies. Whichever method is
			//used, the formatting needs to be reset afterwards to avoid subsequent being formatted,
			//however there appears to be no good way to do so. Instead, a delegate to reset the
			//formatting needs to be passed in.

			var oldLength = textBox.TextLength;
			//DO NOT try to calculate this by subtracting the length of the text
			//It is unreliable (eg. off by one), I suspect because of newline characters
			//being replaced with a different type of newline character.
			//Similarly, DO NOT use text.Length for the length parameter, for the same reason

			textBox.AppendText(text);
			FormatRange(
				textBox: textBox,
				start: oldLength,
				length: textBox.TextLength - oldLength,
				formatter: formatter
			);
		}

		/// <summary>
		/// NOTE: Formatter must return an action that is used to reset the formatting to whatever
		/// it was before formatter was called. In some cases this may not be possible,
		/// so either don't use that formatting, store a set default, or else the
		/// new formatting may carry over into subsequent appends/inserts.
		/// </summary>
		public static void FormatRange(this RichTextBox textBox, int start, int length, Func<RichTextBox, Action> formatter)
		{
			if (textBox == null) throw new ArgumentNullException(nameof(textBox));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));
			if (start >= textBox.TextLength) throw new ArgumentOutOfRangeException(nameof(start), "Must be less than textBox.TextLength '" + textBox.TextLength + "'.");
			if (length > textBox.TextLength - start) throw new ArgumentOutOfRangeException(nameof(length), "Must be less than textBox.TextLength '" + textBox.TextLength + "' - start '" + start + "'.");

			var oldSelectionStart = textBox.SelectionStart;
			var oldSelectionLength = textBox.SelectionLength;
			Action formatResetter = null;

			try
			{
				textBox.Select(start, length);

				formatResetter = formatter(textBox);
			}
			finally
			{
				textBox.SelectionStart = oldSelectionStart;
				textBox.SelectionLength = oldSelectionLength;

				formatResetter?.Invoke();
			}
		}
	}
}
