using BepInEx.Logging;
using HarmonyLib;
using InnerNet;
using UnityEngine;

namespace AmongUsMod.Loader.WrapperTest {
	public static class GameStartEvent
	{
		public delegate void OnEvent(GameStartManager instance);
		public static event OnEvent Event;

		[HarmonyPatch(typeof (GameStartManager), "Start")]
		public static class GamePatch
		{
			public static void Postfix(GameStartManager __instance)
			{
				if (Event != null) Event(__instance); 
			}
		}
	}
}