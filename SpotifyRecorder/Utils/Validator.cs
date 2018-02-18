using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Utils
{
	/// <summary>
	/// A function that takes some input, returns <see cref="InputValid"/> if it is valid,
	/// and returns an error message passed into <see cref="InputInvalid(string)"/> if it is invalid.
	/// </summary>
	public delegate string Validator<T>(T input);

	public static class Validator
	{
		/// <summary>
		/// Returned by <see cref="Validator{T}"/> to express a successful match. Equal to null.
		/// </summary>
		public const string Valid = null;

		/// <summary>
		/// Returned by <see cref="Predicate"/> to express a failed match, while providing
		/// an optional error message. Returns its input, or an empty string if the input is null.
		/// </summary>
		public static string Invalid(string errorMessage) => errorMessage ?? "";

		public static bool IsValid(string validatorResult) => validatorResult == null;

		public static Predicate<T> ToPredicate<T>(this Validator<T> validator)
		{
			if (validator == null) throw new ArgumentNullException(nameof(validator));

			return x => IsValid(validator(x));
		}

		public static Func<T, bool> ToPredicateFunc<T>(this Validator<T> validator)
		{
			if (validator == null) throw new ArgumentNullException(nameof(validator));

			return x => IsValid(validator(x));
		}

		public static Validator<T> FromPredicate<T>(Predicate<T> predicate, bool verboseError = true)
		{
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));

			if (verboseError) return x => predicate(x) ? null : MakeVerboseErrorMessage(x, predicate);
			else              return x => predicate(x) ? null : MakeShortErrorMessage(x);
		}

		public static Validator<T> FromPredicateFunc<T>(Func<T, bool> predicate, bool verboseError = true)
		{
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));

			if (verboseError) return x => predicate(x) ? null : MakeVerboseErrorMessage(x, predicate);
			else              return x => predicate(x) ? null : MakeShortErrorMessage(x);
		}

		private static string MakeShortErrorMessage<T>(T input)
		{
			return "Input '" + input + "' did not match predicate";
		}

		private static string MakeVerboseErrorMessage<T>(T input, Delegate predicate)
		{
			return (
				"Input '" + input + "' "
				+ "did not match predicate '" + predicate.Method.Name + "' "
				+ "from type '" + predicate.Method.DeclaringType.AssemblyQualifiedName + "' "
				+ "attached to object instance '" + predicate.Target + "'."
			);
		}
	}
}
