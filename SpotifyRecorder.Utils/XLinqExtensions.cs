using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyRec
{
	public static class XLinqExtensions
	{
		public static XElement El(this XContainer xContainer, XName name)
		{
			return xContainer.Element(name);
		}

		public static IEnumerable<XElement> Els(this XContainer xContainer)
		{
			return xContainer.Elements();
		}

		public static IEnumerable<XElement> Els(this XContainer xContainer, XName name)
		{
			return xContainer.Elements(name);
		}

		public static XAttribute Attr(this XElement el, XName name)
		{
			return el.Attribute(name);
		}

		public static IEnumerable<XAttribute> Attrs(this XElement el)
		{
			return el.Attributes();
		}

		public static IEnumerable<XAttribute> Attrs(this XElement el, XName name)
		{
			return el.Attributes(name);
		}

		public static T? ValueAsEnum<T>(this XElement el)
			where T : struct
		{
			return Enum.TryParse(el.Value, out T result) ? result : (T?)null;
		}

		public static T? ValueAsEnum<T>(this XAttribute attr)
			where T : struct
		{
			return Enum.TryParse(attr.Value, out T result) ? result : (T?)null;
		}

		public static byte   ? ValueAsByte   (this XElement el) => byte   .TryParse(el.Value, out byte    result) ? result : (byte   ?)null;
		public static sbyte  ? ValueAsSByte  (this XElement el) => sbyte  .TryParse(el.Value, out sbyte   result) ? result : (sbyte  ?)null;
		public static short  ? ValueAsShort  (this XElement el) => short  .TryParse(el.Value, out short   result) ? result : (short  ?)null;
		public static ushort ? ValueAsUShort (this XElement el) => ushort .TryParse(el.Value, out ushort  result) ? result : (ushort ?)null;
		public static int    ? ValueAsInt    (this XElement el) => int    .TryParse(el.Value, out int     result) ? result : (int    ?)null;
		public static uint   ? ValueAsUInt   (this XElement el) => uint   .TryParse(el.Value, out uint    result) ? result : (uint   ?)null;
		public static long   ? ValueAsLong   (this XElement el) => long   .TryParse(el.Value, out long    result) ? result : (long   ?)null;
		public static ulong  ? ValueAsULong  (this XElement el) => ulong  .TryParse(el.Value, out ulong   result) ? result : (ulong  ?)null;
		public static float  ? ValueAsFloat  (this XElement el) => float  .TryParse(el.Value, out float   result) ? result : (float  ?)null;
		public static double ? ValueAsDouble (this XElement el) => double .TryParse(el.Value, out double  result) ? result : (double ?)null;
		public static decimal? ValueAsDecimal(this XElement el) => decimal.TryParse(el.Value, out decimal result) ? result : (decimal?)null;
		public static bool   ? ValueAsBool   (this XElement el) => bool   .TryParse(el.Value, out bool    result) ? result : (bool   ?)null;
		public static char   ? ValueAsChar   (this XElement el) => char   .TryParse(el.Value, out char    result) ? result : (char   ?)null;

		public static byte   ? ValueAsByte   (this XAttribute attr) => byte   .TryParse(attr.Value, out byte    result) ? result : (byte   ?)null;
		public static sbyte  ? ValueAsSByte  (this XAttribute attr) => sbyte  .TryParse(attr.Value, out sbyte   result) ? result : (sbyte  ?)null;
		public static short  ? ValueAsShort  (this XAttribute attr) => short  .TryParse(attr.Value, out short   result) ? result : (short  ?)null;
		public static ushort ? ValueAsUShort (this XAttribute attr) => ushort .TryParse(attr.Value, out ushort  result) ? result : (ushort ?)null;
		public static int    ? ValueAsInt    (this XAttribute attr) => int    .TryParse(attr.Value, out int     result) ? result : (int    ?)null;
		public static uint   ? ValueAsUInt   (this XAttribute attr) => uint   .TryParse(attr.Value, out uint    result) ? result : (uint   ?)null;
		public static long   ? ValueAsLong   (this XAttribute attr) => long   .TryParse(attr.Value, out long    result) ? result : (long   ?)null;
		public static ulong  ? ValueAsULong  (this XAttribute attr) => ulong  .TryParse(attr.Value, out ulong   result) ? result : (ulong  ?)null;
		public static float  ? ValueAsFloat  (this XAttribute attr) => float  .TryParse(attr.Value, out float   result) ? result : (float  ?)null;
		public static double ? ValueAsDouble (this XAttribute attr) => double .TryParse(attr.Value, out double  result) ? result : (double ?)null;
		public static decimal? ValueAsDecimal(this XAttribute attr) => decimal.TryParse(attr.Value, out decimal result) ? result : (decimal?)null;
		public static bool   ? ValueAsBool   (this XAttribute attr) => bool   .TryParse(attr.Value, out bool    result) ? result : (bool   ?)null;
		public static char   ? ValueAsChar   (this XAttribute attr) => char   .TryParse(attr.Value, out char    result) ? result : (char   ?)null;
	}
}
