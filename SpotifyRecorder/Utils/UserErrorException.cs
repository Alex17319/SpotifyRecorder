using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Utils
{

	[Serializable]
	public class UserErrorException : Exception
	{
		public UserErrorException() { }
		public UserErrorException(string message) : base(message) { }
		public UserErrorException(string message, Exception inner) : base(message, inner) { }
		protected UserErrorException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
