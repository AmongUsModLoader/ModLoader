using System;
using HarmonyLib;

namespace AmongUs.Api {
	public static class Language
	{
		public static event Action<LanguageButton> ChangeEvent;

		[HarmonyPatch(typeof (LanguageSetter), "SetLanguage")]
		private static class GamePatch
		{
			public static void Postfix(ref LanguageButton __0) => ChangeEvent?.Invoke(__0);
		}
	}
}
