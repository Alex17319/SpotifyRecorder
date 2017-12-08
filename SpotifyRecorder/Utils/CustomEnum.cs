using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.ObjectModel;

namespace SpotifyRec
{
	public abstract class CustomEnum
	{
		public static object CreateFrom(Type enumType, Type valueType, object value)
		{
			var customEnumType = GetCustomEnumType(enumType, valueType);
			return (
				customEnumType
				.GetMethod("CreateFrom", new Type[] { valueType })
				.Invoke(GetSeed(customEnumType), new object[] { value })
			);
		}
		public static TEnum CreateFrom<TEnum>(Type valueType, object value) where TEnum : CustomEnum
		{
			return (TEnum)CreateFrom(typeof(TEnum), valueType, value);
		}
		public static TEnum CreateFrom<TEnum, TValue>(TValue value) where TEnum : CustomEnum<TEnum, TValue>
		{
			return (TEnum)value;
		}

		private static Type GetCustomEnumType(Type enumType, Type valueType)
		{
			return typeof(CustomEnum<,>).MakeGenericType(enumType, valueType);
		}

		private static object GetSeed(Type customEnumType)
		{
			return (
				customEnumType
				.GetField("_seed", BindingFlags.NonPublic | BindingFlags.Static)
				.GetValue(obj: null)
			);
		}
	}

	public abstract class CustomEnum<TValue> : CustomEnum
	{
		private readonly TValue _value;
		public TValue Value => _value;

		protected CustomEnum(TValue value)
		{
			this._value = value;
		}
	}

	public abstract class CustomEnum<TEnum, TValue> : CustomEnum<TValue>
		where TEnum : CustomEnum<TEnum, TValue>
	{
		//[Obsolete("This contains an uninitialized object. Do not use outside CustomEnum.cs", error: false)]
		private static TEnum _seed = (
			(TEnum)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(TEnum))
		);

		private static ReadOnlyCollection<(string name, TEnum value)> _definedValues = null;

		protected CustomEnum(TValue value) : base(value) { }

		protected abstract TEnum CreateFrom(TValue value);

		public static ReadOnlyCollection<(string name, TEnum value)> GetValues()
		{
			if (_definedValues == null) {
				_definedValues = Array.AsReadOnly(Enumerable.ToArray(
					from field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
					where field.FieldType == typeof(TEnum)
					where field.IsInitOnly
					select (name: field.Name, value: (TEnum)field.GetValue(obj: null))
				));
			}

			return _definedValues;
		}

		public static bool IsDefined(TEnum value)
		{
			return GetValues().Any(x => object.Equals(x.value, value));
		}

		public static explicit operator CustomEnum<TEnum, TValue>(TValue x) => _seed.CreateFrom(x);
		public static implicit operator TEnum(CustomEnum<TEnum, TValue> x) => (TEnum)x;

		public static explicit operator TValue(CustomEnum<TEnum, TValue> x) => x.Value;
	}
}
