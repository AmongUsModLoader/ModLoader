using System;
using BepInEx.Logging;
using HarmonyLib;
using InnerNet;
using UnityEngine;

namespace AmongUs.Api {
	public static class Game
	{
		public static event Action<GameStartManager> StartEvent;

		[HarmonyPatch(typeof (GameStartManager), "Start")]
		public static class GamePatch
		{
			public static void Postfix(GameStartManager __instance)
			{
				StartEvent?.Invoke(__instance);
			}
		}
	}
}
