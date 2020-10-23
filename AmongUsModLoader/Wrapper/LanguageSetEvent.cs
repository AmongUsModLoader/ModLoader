using BepInEx.Logging;
using HarmonyLib;
using InnerNet;
using UnityEngine;

namespace AmongUsMod.Loader.WrapperTest {
	public static class LanguageSetEvent
	{
		public delegate void OnEvent(LanguageButton button);
		public static event OnEvent Event;

		[HarmonyPatch(typeof (LanguageSetter), "SetLanguage")]
		public static class GamePatch
		{
			public static void Postfix(ref LanguageButton __0)
			{
				if (Event != null) Event(__0); 
			}
		}
	}
}