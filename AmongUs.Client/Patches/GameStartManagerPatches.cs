using AmongUs.Api;
using AmongUs.Client.Api;
using HarmonyLib;

namespace AmongUs.Client.Patches
{
	internal static class GameStartManagerPatches
	{

		[HarmonyPatch(typeof(EDGCHOJDFNC), "Start")]
		private static class GameStartPatch
		{
			public static void Postfix(EDGCHOJDFNC __instance) =>
				GameLobby.Start(new GameLobbyWrapper(__instance));

		}

		[HarmonyPatch(typeof(EDGCHOJDFNC), "BeginGame")]
		private static class GameBeginPatch
		{
			public static void Postfix(EDGCHOJDFNC __instance) =>
				GameLobby.TryStart(new GameLobbyWrapper(__instance));
		}

		[HarmonyPatch(typeof(EDGCHOJDFNC), "ReallyBegin")]
		private static class ReallyBeginPatch
		{
			public static void Postfix(EDGCHOJDFNC __instance, [HarmonyArgument(0)] bool neverShow) =>
				GameLobby.GameStarting(new GameLobbyWrapper(__instance), neverShow);
		}

		[HarmonyPatch(typeof(EDGCHOJDFNC), "SetStartCounter")]
		private static class StartCountDownPatch
		{
			public static void Prefix(EDGCHOJDFNC __instance, [HarmonyArgument(0)] sbyte seconds) =>
				GameLobby.SetStartCounterPre(new GameLobbyWrapper(__instance), seconds);

			public static void Postfix(EDGCHOJDFNC __instance, [HarmonyArgument(0)] sbyte seconds) =>
				GameLobby.SetStartCounterPost(new GameLobbyWrapper(__instance), seconds);
		}

		[HarmonyPatch(typeof(EDGCHOJDFNC), "Update")]
		private static class LobbyUpdatePatch
		{
			public static void Postfix(EDGCHOJDFNC __instance) =>
				GameLobby.Update(new GameLobbyWrapper(__instance));
		}

		//TODO this patch doesnt work sad emoji
		[HarmonyPatch(typeof(EDGCHOJDFNC), "MakePublic")]
		private static class MakePublicPatch
		{
			public static void Postfix(EDGCHOJDFNC __instance) =>
				GameLobby.MakePublic(new GameLobbyWrapper(__instance));
		}
	}
}