using AmongUs.Api;
using AmongUs.Client.Loader.Api;
using HarmonyLib;

namespace AmongUs.Client.Loader.Patches
{
	internal static class GameStartManagerPatches
	{

		[HarmonyPatch(typeof(GameStartManager), "Start")]
		private static class GameStartPatch
		{
			public static void Postfix(GameStartManager __instance) =>
				GameLobby.Start(new GameLobbyWrapper(__instance));

		}

		[HarmonyPatch(typeof(GameStartManager), "BeginGame")]
		private static class GameBeginPatch
		{
			public static void Postfix(GameStartManager __instance) =>
				GameLobby.TryStart(new GameLobbyWrapper(__instance));
		}

		[HarmonyPatch(typeof(GameStartManager), "ReallyBegin")]
		private static class ReallyBeginPatch
		{
			public static void Postfix(GameStartManager __instance, [HarmonyArgument(0)] bool neverShow) =>
				GameLobby.GameStarting(new GameLobbyWrapper(__instance), neverShow);
		}

		[HarmonyPatch(typeof(GameStartManager), "SetStartCounter")]
		private static class StartCountDownPatch
		{
			public static void Prefix(GameStartManager __instance, [HarmonyArgument(0)] sbyte seconds) =>
				GameLobby.SetStartCounterPre(new GameLobbyWrapper(__instance), seconds);

			public static void Postfix(GameStartManager __instance, [HarmonyArgument(0)] sbyte seconds) =>
				GameLobby.SetStartCounterPost(new GameLobbyWrapper(__instance), seconds);
		}

		[HarmonyPatch(typeof(GameStartManager), "Update")]
		private static class LobbyUpdatePatch
		{
			public static void Postfix(GameStartManager __instance) =>
				GameLobby.Update(new GameLobbyWrapper(__instance));
		}

		//TODO this patch doesnt work sad emoji
		[HarmonyPatch(typeof(GameStartManager), "MakePublic")]
		private static class MakePublicPatch
		{
			public static void Postfix(GameStartManager __instance) =>
				GameLobby.MakePublic(new GameLobbyWrapper(__instance));
		}
	}
}