using SpotifyRec.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyRec
{
	public struct RawSettings
	{
		public ImmutableList<string> AdNames { get; }
		public ImmutableList<string> AdKeywords { get; }
		public ImmutableList<string> SongNames { get; }
		public OutputFormat OutputFormat { get; }
		public string OutputFolder { get; }
		public string TempFolder { get; }
		public int SongRefreshInterval { get; }

		public RawSettings(
			ImmutableList<string> adNames,
			ImmutableList<string> adKeywords,
			ImmutableList<string> songNames,
			OutputFormat outputFormat,
			string outputFolder,
			string tempFolder,
			int songRefreshInterval
		) {
			this.AdNames = adNames;
			this.AdKeywords = adKeywords;
			this.SongNames = songNames;
			this.OutputFormat = outputFormat;
			this.OutputFolder = outputFolder;
			this.TempFolder = tempFolder;
			this.SongRefreshInterval = songRefreshInterval;
		}



		public static RawSettings Default { get; } = new RawSettings(
			adNames: new string[] { }.ToImmutableList(),
			adKeywords: new string[] {
				"spotify",
				"listen now",
				"click here",
				"click the banner",
				"get premium"
			}.ToImmutableList(),
			songNames: new string[] { }.ToImmutableList(),
			outputFormat: OutputFormat.MP3,
			outputFolder: Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
				"Spotify Recorder",
				"[All Songs]" //Other folders should be used for each playlist, which consist of shortcuts to files in this folder (this is just the default setup though)
			),
			tempFolder: Path.Combine(Path.GetTempPath(), "Spotify Recorder"),
			songRefreshInterval: 100
		);

		//A namespace isn't needed, and just complicates things
		//	public static XNamespace SettingsNamespace { get; } = "http://www.alex-17319/spotify-recorder/settings";



		public static RawSettings FromXml(XElement e)
		{
			if (e.Name != "settings") return Default;

			return new RawSettings(
				adNames:    e.El("adNames"   )?.Els("name"   ).Select(x => x.Value).ToImmutableList().NullIfEmpty() ?? Default.AdNames   ,
				adKeywords: e.El("adKeywords")?.Els("keyword").Select(x => x.Value).ToImmutableList().NullIfEmpty() ?? Default.AdKeywords,
				songNames:  e.El("songNames" )?.Els("name"   ).Select(x => x.Value).ToImmutableList().NullIfEmpty() ?? Default.SongNames ,
				outputFormat: e.El("outputFormat")?.ValueAsEnum<OutputFormat>() ?? Default.OutputFormat,
				outputFolder: e.El("outputFolder")?.Value ?? Default.OutputFolder,
				tempFolder:   e.El("tempFolder"  )?.Value ?? Default.TempFolder,
				songRefreshInterval: e.El("songRefreshInterval")?.ValueAsInt() ?? Default.SongRefreshInterval
			);
		}

		/// <summary>
		/// Note: Creates a new XElement on-demand - it is not cached (so is safe to mutate).
		/// </summary>
		public static XElement ToXml(RawSettings s)
		{
			return new XElement(
				"settings",
				new XElement("adNames"   , s.AdNames.Select(x => new XElement("name"   , x))),
				new XElement("adKeywords", s.AdNames.Select(x => new XElement("keyword", x))),
				new XElement("songNames" , s.AdNames.Select(x => new XElement("name"   , x))),
				new XElement("outputFormat", s.OutputFormat.ToString()),
				new XElement("outputFolder", s.OutputFolder),
				new XElement("tempFolder", s.TempFolder),
				new XElement("songRefreshInterval", s.SongRefreshInterval)
			);
		}

		public override string ToString()
		{
			return ToXml(this).ToString();
		}

		public override bool Equals(object obj) => obj is RawSettings s && Equals(this, s);

		public static bool Equals(RawSettings a, RawSettings b)
		{
			return (
				Enumerable.SequenceEqual(a.AdNames, b.AdNames)
				&& Enumerable.SequenceEqual(a.AdKeywords, b.AdKeywords)
				&& Enumerable.SequenceEqual(a.SongNames, b.SongNames)
				&& a.OutputFormat == b.OutputFormat
				&& a.OutputFolder == b.OutputFolder
				&& a.TempFolder == b.TempFolder
				&& a.SongRefreshInterval == b.SongRefreshInterval
			);
		}

		public override int GetHashCode()
		{
			return HashCodes.Combine(
				HashCodes.CombineList(this.AdNames),
				HashCodes.CombineList(this.AdKeywords),
				HashCodes.CombineList(this.SongNames),
				this.OutputFormat.GetHashCode(),
				this.OutputFolder.GetHashCode(),
				this.TempFolder.GetHashCode(),
				this.SongRefreshInterval.GetHashCode()
			);
		}
	}
}
