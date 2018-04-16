using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec
{
	public static class EnumerableExtensions
	{
		#region NullIfEmpty

		/// <summary>
		/// Takes a collection, and if it is null or empty, returns null. Otherwise, returns the collection.
		/// </summary>
		/// <remarks>
		/// Effectively the opposite of "(some expression) ?? <see cref="Enumerable.Empty{TResult}()"/>"
		/// (with support for the non-generic <see cref="IEnumerable"/> interface).
		/// <para/>
		/// Note: Apply this method before the null-coalescing operator ('??') to allow it to detect empty collections.
		/// </remarks>
		public static IEnumerable NullIfEmpty<T>(this IEnumerable source)
			=> NullIfEmpty<IEnumerable>(source);

		/// <summary>
		/// Takes a collection, and if it is null or empty, returns null.
		/// Otherwise, returns the collection, while preserving the original type.
		/// </summary>
		/// <remarks>
		/// Note: Apply this method before the null-coalescing operator ('??') to allow it to detect empty collections.
		/// </remarks>
		public static TCollection NullIfEmpty<TCollection>(this TCollection source)
			where TCollection : class, IEnumerable
			=> source == null || !source.Any() ? null : source;

		/// <summary>
		/// Takes a collection that is a struct, and if it is empty, returns null.
		/// Otherwise, returns the collection, while preserving the original type (but making it nullable).
		/// </summary>
		/// <remarks>
		/// Note: Apply this method before the null-coalescing operator ('??') to allow it to detect empty collections.
		/// </remarks>
		public static TCollection? NullIfStructEmpty<TCollection>(this TCollection source)
			where TCollection : struct, IEnumerable
			=> !source.Any() ? null : (TCollection?)source;

		/// <summary>
		/// Takes a collection that is a nullable struct, and if it is null or empty, returns null.
		/// Otherwise, returns the collection, while preserving the original type.
		/// </summary>
		/// <remarks>
		/// Note: Apply this method before the null-coalescing operator ('??') to allow it to detect empty collections.
		/// </remarks>
		public static TCollection? NullIfStructEmpty<TCollection>(this TCollection? source)
			where TCollection : struct, IEnumerable 
			=> source == null || !source.Any() ? null : source;

		#endregion


		#region Any

		/// <summary>
		/// The same as <see cref="Enumerable.Any{TSource}(IEnumerable{TSource})"/>, but
		/// also works for the non-generic <see cref="IEnumerable"/> interface.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool Any(this IEnumerable source)
		{
			IEnumerator e = source.GetEnumerator();
			try
			{
				if (e.MoveNext()) return true;
				else return false;
			}
			finally
			{
				if (e is IDisposable disposable) disposable.Dispose();
			}
		}

		#endregion

	}
}
