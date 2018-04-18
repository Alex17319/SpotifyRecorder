﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyRec
{
	public class SpotifyController
	{
		//Currently not used but might be in future & it's good to have access
		public SpotifyProcessManager SpotifyProcessManager { get; }

		public SpotifyController(SpotifyProcessManager spotifyProcessManager)
		{
			this.SpotifyProcessManager = SpotifyProcessManager;
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

		private const int KEYEVENTF_KEYUP = 0x0002;
		private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
		private const byte KEYEVENTF_SILENT = 0x0004;

		private void PressKey(Keys key)
		{
			byte modifierKey = GetModifierAsKey(key);
			byte unmodifiedKey = unchecked((byte)key);

			if (modifierKey != 0) {
				keybd_event(modifierKey, modifierKey, 0, 0);
			}

			keybd_event(unmodifiedKey, unmodifiedKey, 0, 0);
			keybd_event(unmodifiedKey, unmodifiedKey, KEYEVENTF_KEYUP, 0);

			if (modifierKey != 0) {
				keybd_event(modifierKey, modifierKey, KEYEVENTF_KEYUP, 0);
			}
		}

		private byte GetModifierAsKey(Keys key)
		{
			var modifier = key & Keys.Modifiers;

			if (modifier == 0) return 0;

			switch (key)
			{
				case Keys.Shift: return (byte)Keys.ShiftKey;
				case Keys.Control: return (byte)Keys.ControlKey;
				case Keys.Alt: return (byte)Keys.Menu;
				//throw new NotSupportedException(
				//	"AFAIK there is no non-modifier key that can be held to simulate the alt modifier, "
				//	+ "and IDK how to send a modifier key, so the alt modifier key isn't supported. "
				//	+ "Full key value: '" + (int)key + "'."
				//);
				default: throw new NotSupportedException(
					"Unknown modifier key. Full key value: '" + (int)key + "'."
				);
			}
		}

		public void PlayPause()
		{
			//The Keys.Play and Keys.Pause keys have no effect on spotify,
			//so we just have to use Keys.MediaPlayPause
			PressKey(Keys.MediaPlayPause);
		}

		public void NextTrack(int num = 1)
		{
			for (int i = 0; i < num; i++) {
				PressKey(Keys.MediaNextTrack);
			}
		}

		public void PrevTrack(int num = 1)
		{
			for (int i = 0; i < num; i++) {
				PressKey(Keys.MediaPreviousTrack);
			}
		}

		public void VolumeUp(int num = 1)
		{
			for (int i = 0; i < num; i++) {
				PressKey(Keys.VolumeUp);
			}
		}

		public void VolumeDown(int num = 1)
		{
			for (int i = 0; i < num; i++) {
				PressKey(Keys.VolumeDown);
			}
		}

		public void MuteUnmute(int num = 1)
		{
			for (int i = 0; i < num; i++) {
				PressKey(Keys.VolumeMute);
			}
		}
	}
}
