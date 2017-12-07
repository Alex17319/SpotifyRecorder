using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public class ValueChangeEventArgs<T> : EventArgs
	{
		public T OldValue { get; }
		public T NewValue { get; }

		public ValueChangeEventArgs(T oldValue, T newValue)
		{
			this.OldValue = oldValue;
			this.NewValue = newValue;
		}
	}
}
