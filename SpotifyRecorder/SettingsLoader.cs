using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyRec
{
	public static class SettingsLoader
	{
		public const string SettingsFileName = "Settings.xml";
		public const string OldSettingsFileName = "Settings.old.xml";
		public const string IncompleteSettingsFileName = "Settings.incomplete.xml";

		public static RawSettings Load(string settingsFolder)
		{
			if (settingsFolder == null) throw new ArgumentNullException(nameof(settingsFolder));

			var settingsFilePath = Path.Combine(settingsFolder, SettingsFileName);
			var oldSettingsFilePath = Path.Combine(settingsFolder, OldSettingsFileName);

			if (!File.Exists(settingsFilePath)) {
				if (!File.Exists(oldSettingsFilePath)) {
					return LoadDefaultSettings();
				}
				File.Move(oldSettingsFilePath, settingsFilePath);
			}

			using (var fs = File.OpenRead(settingsFilePath))
			{
				return RawSettings.FromXml(
					XDocument.Load(fs).Root
				);
			}

			RawSettings LoadDefaultSettings()
			{
				var defaultSettings = RawSettings.Default;
				RawSettings.ToXml(defaultSettings).Save(settingsFilePath);
				return defaultSettings;
			}
		}
	}
}
