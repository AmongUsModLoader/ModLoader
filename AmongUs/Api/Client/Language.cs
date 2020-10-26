using System;
using AmongUs.Loader;
using AmongUs.Loader.Internal;

namespace AmongUs.Api {
	public static class Language
	{
		public static event Action<LanguageButton> ChangeEvent;

		public static void Change(LanguageButton button) => ChangeEvent?.Invoke(button);
		public static string Translate(string mod, string key) => ModLoader.Instance.Mods[mod].LanguageKeys[ApiWrapper.Instance.Language][key];
	}
}
