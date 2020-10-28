using System;
using AmongUs.Loader;
using AmongUs.Loader.Internal;

namespace AmongUs.Api
{
	[Side(ModSide.Client)]
	public static class Language
	{
		public static event Action<LanguageButton> ChangeEvent;

		public static void Change(LanguageButton button) => ChangeEvent?.Invoke(button);
		
		public static string Translate(string modId, string key)
		{
			if (!ModLoader.Instance.Mods.ContainsKey(modId)) return key;
			
			var mod = ModLoader.Instance.Mods[modId];
			var language = ApiWrapper.Instance.Language;
			if (!mod.LanguageKeys.ContainsKey(language)) return key;
			
			var languageKeys = mod.LanguageKeys[language];
			return languageKeys.ContainsKey(key) ? languageKeys[key] : key;
		}
	}
}
