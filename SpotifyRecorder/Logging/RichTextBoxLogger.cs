using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyRec.Utils;
using System.Drawing;

namespace SpotifyRec.Logging
{
	public class RichTextBoxLogger : LoggerBase
	{
		public RichTextBox TextBox { get; }

		public RichTextBoxLogger(ILogProvider provider, RichTextBox textBox) : base(provider)
		{
			this.TextBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
		}

		protected override void LogFullMessage(string fullMessage, LogType messageType)
		{
			//Add a newline before the logged message, unless the textbox is empty
			//This avoids having an extra leading or trailing empty line
			if (TextBox.TextLength > 0) {
				fullMessage = Environment.NewLine + fullMessage;
			}

			switch (messageType)
			{
				case LogType.Message:      TextBox.AppendText(fullMessage); break;
				case LogType.MinorMessage: TextBox.AppendFormattedText(fullMessage, tb => tb.SelectionColor = Color.Gray  ); break;
				case LogType.Warning:      TextBox.AppendFormattedText(fullMessage, tb => tb.SelectionColor = Color.Orange); break;
				case LogType.Error:        TextBox.AppendFormattedText(fullMessage, tb => tb.SelectionColor = Color.Red   ); break;
			}
		}
	}
}
