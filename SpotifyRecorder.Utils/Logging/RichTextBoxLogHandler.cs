using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyRec.Utils;
using System.Drawing;
using System.Threading;

namespace SpotifyRec.Logging
{
	public class RichTextBoxLogHandler : LogHandler
	{
		public RichTextBox TextBox { get; }

		public RichTextBoxLogHandler(RichTextBox textBox)
		{
			this.TextBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
		}

		public override void LogMessage(string message, LogType messageType)
		{
			LogFullMessage(ConstructFullMessage(message, messageType), messageType);
		}

		public override void LogFullMessage(string fullMessage, LogType messageType)
		{
			if (TextBox.InvokeRequired) TextBox.Invoke(new MethodInvoker(LogFullMessageInternal));
			else LogFullMessageInternal();

			void LogFullMessageInternal()
			{
				if (TextBox.IsDisposed) return;

				//Add a newline before the logged message, unless the textbox is empty
				//This avoids having an extra leading or trailing empty line
				if (TextBox.TextLength > 0) {
					fullMessage = Environment.NewLine + fullMessage;
				}

				switch (messageType)
				{
					case LogType.Message:      TextBox.AppendText(fullMessage); break;
					case LogType.MinorMessage: TextBox.AppendFormattedText(fullMessage, GetColourFormatter(Color.Gray  )); break;
					case LogType.Warning:      TextBox.AppendFormattedText(fullMessage, GetColourFormatter(Color.Orange)); break;
					case LogType.Error:        TextBox.AppendFormattedText(fullMessage, GetColourFormatter(Color.Red   )); break;
				}
			}
		}

		private Func<RichTextBox, Action> GetColourFormatter(Color color)
		{
			return tb => {
				var prevColor = tb.SelectionColor;
				tb.SelectionColor = color;
				return new Action(() => tb.SelectionColor = prevColor);
			};
		}
	}
}
