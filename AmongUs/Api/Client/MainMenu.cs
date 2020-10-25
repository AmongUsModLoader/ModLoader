using System;
using HarmonyLib;

namespace AmongUs.Api {
	public static class MainMenu
	{
		public static event Action<MainMenuManager> ConstructionEvent;
		public static event Action<VersionShower> VersionShowEvent;

		[HarmonyPatch(typeof(MainMenuManager), "LPCEHACMAPB")]
		private static class MenuConstructorPatch
		{
			public static void Postfix(MainMenuManager __instance)
			{
				//Best way to debug, obviously
				System.Console.WriteLine("TEST");
			}
		}

		[HarmonyPatch(typeof(VersionShower), "Start")]
		private static class VersionShowerPatch
		{
			public static void Postfix(VersionShower __instance) => VersionShowEvent?.Invoke(__instance);
		}
	}
}
