using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolioWebGen.WinForms
{
	public class AttemptEventArgs
	{
		public bool Success { get; }

		public AttemptEventArgs(bool success)
		{
			this.Success = success;
		}
	}
}
