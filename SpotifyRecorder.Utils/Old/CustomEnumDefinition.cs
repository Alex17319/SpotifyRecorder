using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

namespace SpotifyRec.Utils
{
	public abstract class CustomEnumDefinition
	{
		public Type EnumType { get; }
		public Type ValueType { get; }

		public CustomEnumDefinition(Type enumType, Type valueType)
		{
			this.EnumType = enumType;
			this.ValueType = valueType;
		}

		public abstract IEnumerable<(string name, CustomEnum enumObj, object value)> GetUntypedValues();
	}

	public abstract class CustomEnumDefinition<TValue> : CustomEnumDefinition
	{
		public CustomEnumDefinition(Type enumType)
			: base(enumType: enumType, valueType: typeof(TValue))
		{ }

		public abstract IEnumerable<(string name, CustomEnum<TValue> enumObj, TValue value)> GetValues();
	}

	public class CustomEnumDefinition<TEnum, TValue> : CustomEnumDefinition<TValue>
		where TEnum : CustomEnum<TEnum, TValue>
	{
		public CustomEnumDefinition(ReadOnlyCollection<(string name, TEnum value)> values)
			: base(enumType: typeof(TEnum))
		{
			this.Values = values;
		}

		public ReadOnlyCollection<(string name, TEnum value)> Values { get; }
		public override IEnumerable<(string name, CustomEnum<TValue> enumObj, TValue value)> GetValues() {
			return Values.Select(x => (name: x.name, enumObj: (CustomEnum<TValue>)x.value, value: x.value.Value));
		}
		public override IEnumerable<(string name, CustomEnum enumObj, object value)> GetUntypedValues() {
			return Values.Select(x => (name: x.name, enumObj: (CustomEnum)x.value, value: (object)x.value.Value));
		}

		public TEnum Parse(string str, Func<string, TValue> valueParser, bool ignoreCase = false)
		{
			if (str == null) throw new ArgumentNullException(nameof(str));
			if (valueParser == null) throw new ArgumentNullException(nameof(valueParser));

			var comparisonType = ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

			var match = Values.FirstOrDefault(x => string.Equals(x.name, str, comparisonType));
			if (match.name != null) { //If not default
				return match.value;
			}

			try {
				return (TEnum)valueParser(str);
			} catch (Exception e) {
				throw new ArgumentException(
					message: $"Could not parse string '{str}' as custom enum of type '{typeof(TEnum)}'.",
					innerException: e
				);
			}
		}

		public bool TryParse(string str, TryDelegate<string, TValue> valueParser, out TEnum result, bool ignoreCase = false)
		{
			if (str == null) throw new ArgumentNullException(nameof(str));
			if (valueParser == null) throw new ArgumentNullException(nameof(valueParser));

			var comparisonType = ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

			var match = Values.FirstOrDefault(x => string.Equals(x.name, str, comparisonType));
			if (match.name != null) { //If not default
				result = match.value;
				return true;
			}

			if (valueParser(str, out TValue innerResult)) {
				result = (TEnum)innerResult;
				return true;
			} else {
				result = default;
				return false;
			}
		}
	}
}

*/