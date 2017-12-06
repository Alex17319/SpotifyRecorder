using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyRec
{
	public struct RawSettings
	{
		public IEnumerable<string> AdNames { get; }
		public IEnumerable<string> AdKeywords { get; }
		public IEnumerable<string> SongNames { get; }
		public OutputFormat OutputFormat { get; }

		public RawSettings(
			IEnumerable<string> adNames,
			IEnumerable<string> adKeywords,
			IEnumerable<string> songNames,
			OutputFormat outputFormat
		) {
			this.AdNames = adNames;
			this.AdKeywords = adKeywords;
			this.SongNames = songNames;
			this.OutputFormat = outputFormat;
		}



		public static RawSettings Default { get; } = new RawSettings(
			adNames: Array.AsReadOnly(new string[] { }),
			adKeywords: Array.AsReadOnly(new string[] {
				"spotify",
				"listen now",
				"click here",
				"click the banner",
				"get premium"
			}),
			songNames: Array.AsReadOnly(new string[] { }),
			outputFormat: OutputFormat.MP3
		);

		//A namespace isn't needed, and just complicates things
		//	public static XNamespace SettingsNamespace { get; } = "http://www.alex-17319/spotify-recorder/settings";



		public static RawSettings FromXml(XElement e)
		{
			if (e.Name != "settings") return Default;

			return new RawSettings(
				adNames:    e.El("adNames"   )?.Els("name"   ).Select(x => x.Value).NullIfEmpty() ?? Default.AdNames   ,
				adKeywords: e.El("adKeywords")?.Els("keyword").Select(x => x.Value).NullIfEmpty() ?? Default.AdKeywords,
				songNames:  e.El("songNames" )?.Els("name"   ).Select(x => x.Value).NullIfEmpty() ?? Default.SongNames ,
				outputFormat: e.El("outputFormat")?.ValueAsEnum<OutputFormat>() ?? Default.OutputFormat
			);
		}

		public static XElement ToXml(RawSettings s)
		{
			return new XElement(
				"settings",
				new XElement("adNames"   , s.AdNames.Select(x => new XElement("name"   , x))),
				new XElement("adKeywords", s.AdNames.Select(x => new XElement("keyword", x))),
				new XElement("songNames" , s.AdNames.Select(x => new XElement("name"   , x))),
				new XElement("outputFormat", s.OutputFormat.ToString())
			);
		}
	}
}
