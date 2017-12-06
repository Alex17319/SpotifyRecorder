using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Takes a collection, and if it is null or empty, returns null. Otherwise, returns the collection.
		/// </summary>
		/// <remarks>
		/// Effectively the opposite of "(some expression) ?? <see cref="Enumerable.Empty{TResult}()"/>".
		/// </remarks>
		public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> source)
		{
			if (source == null || !source.Any()) return null;
			else return source;
		}
	}
}
