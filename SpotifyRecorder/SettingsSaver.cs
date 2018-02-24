using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec
{
	public class SettingsSaver
	{
		public SettingsHost SettingsHost { get; }
		public string SettingsFolder { get; }
		/// <summary>
		/// Used by <see cref="SaveAfterWaiting"/>. Does not affect the behaviour of <see cref="SaveNow"/>.
		/// </summary>
		public int SaveDelay { get; }

		private Timer _timer { get; }
		private Logger _logger { get; }

		/// <summary>
		/// True if any settings have changed since the last save
		/// </summary>
		public bool SettingsDirty { get; private set; }

		public SettingsSaver(SettingsHost settingsHost, string settingsFolder, int saveDelay, Logger logger)
		{
			if (saveDelay <= 0) throw new ArgumentOutOfRangeException("Must be greater than zero.");

			this.SettingsHost = settingsHost ?? throw new ArgumentNullException(nameof(settingsHost));
			this.SettingsFolder = settingsFolder ?? throw new ArgumentNullException(nameof(settingsFolder));
			this.SaveDelay = saveDelay;
			this._logger = logger;

			this._timer = new Timer() { Interval = saveDelay };
			this._timer.Tick += delegate { SaveNow(); };

			this.SettingsDirty = true;

			settingsHost.AnySettingChanged += delegate { SettingsDirty = true; };
		}

		public void SaveNow()
		{
			_timer.Stop(); //Resets the timer to the start of the interval

			if (!SettingsDirty) return;

			var inProgressSavePath = Path.Combine(SettingsFolder, SettingsLoader.IncompleteSettingsFileName);
			var oldSavePath = Path.Combine(SettingsFolder, SettingsLoader.OldSettingsFileName);
			var savePath = Path.Combine(SettingsFolder, SettingsLoader.SettingsFileName);

			//This process, along with the fact that the loader checks for a file at the "old save path"
			//if one at the normal save path isn't found, ensures that there is always a save file available,
			//so it should never get corrupted/lost or anything.
			SettingsHost.ToRaw().ToXml().Save(inProgressSavePath);

			if (File.Exists(savePath)) File.Move(savePath, oldSavePath);
			File.Move(inProgressSavePath, savePath);
			File.Delete(oldSavePath);

			SettingsDirty = false;
			_logger.Log("Saved all settings.", LogType.MinorMessage);
		}

		/// <summary>
		/// Start a timer that will trigger all settings to be saved after <see cref="SaveDelay"/> milliseconds.
		/// For multiple calls within a short period, calling this will avoid triggering extra
		/// saves (and won't reset the timer either).
		/// </summary>
		public void SaveAfterWaiting()
		{
			_timer.Enabled = true;
		}
	}
}
