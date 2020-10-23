using System;
using HarmonyLib;

namespace AmongUs.Api {
	public static class MainMenu
	{
		public static event Action<MainMenuManager> ConstructionEvent;

		[HarmonyPatch(typeof (MainMenuManager), MethodType.Constructor)]
		[HarmonyPatch(new Type[0])]
		internal static class GamePatch
		{
			public static void Postfix(MainMenuManager __instance)
			{
				ConstructionEvent?.Invoke(__instance);
			}
		}
	}
}
