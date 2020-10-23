using System;
using HarmonyLib;

namespace AmongUsMod.Loader.WrapperTest {
	public static class MainMenuEvent
	{
		public delegate void OnEvent(MainMenuManager instance);
		public static event OnEvent Event;

		[HarmonyPatch(typeof (MainMenuManager), MethodType.Constructor)]
		[HarmonyPatch(new Type[] {})]
		public static class GamePatch
		{
			public static void Postfix(MainMenuManager __instance)
			{
				if (Event != null) Event(__instance); 
			}
		}
	}
}