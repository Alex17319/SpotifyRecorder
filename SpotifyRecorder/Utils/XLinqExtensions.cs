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

		public static T ValueAsEnum<T>(this XElement el)
		{
			return (T)Enum.Parse(typeof(T), el.Value);
		}

		public static T ValueAsEnum<T>(this XAttribute attr)
		{
			return (T)Enum.Parse(typeof(T), attr.Value);
		}
	}
}
