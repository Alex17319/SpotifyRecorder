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

		public static RawSettings Load(string settingsFolder, Logger logger)
		{
			logger.Log("Loading settings from folder '" + settingsFolder + "'.");
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
				var res = RawSettings.FromXml(
					XDocument.Load(fs).Root
				);
				logger.Log("Sucessfully loaded saved settings.");
				return res;
			}

			RawSettings LoadDefaultSettings()
			{
				logger.Log("No saved settings found; reverting to default settings.");
				var defaultSettings = RawSettings.Default;
				RawSettings.ToXml(defaultSettings).Save(settingsFilePath);
				logger.Log("Retrieved and saved default settings.");
				return defaultSettings;
			}
		}
	}
}
