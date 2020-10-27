using AmongUs.Api;
using AmongUs.Client.Loader.Api;
using HarmonyLib;

namespace AmongUs.Client.Loader.Patches {
	internal static class GameStartManagerPatches {
		
		[HarmonyPatch(typeof(GameStartManager), "Start")]
		private static class GameStartPatch {
			public static void Postfix(GameStartManager __instance) => GameLobby.Start(new GameLobbyWrapper(__instance));
			
		}
        
		[HarmonyPatch(typeof(GameStartManager), "BeginGame")]
		private static class GameBeginPatch
		{
			//Called when the start button is pressed. Even if there arent enough players
			public static void Postfix(GameStartManager __instance) => GameLobby.TryStart(new GameLobbyWrapper(__instance));
		}
        
		[HarmonyPatch(typeof(GameStartManager), "ReallyBegin")]
		private static class ReallyBeginPatch
		{
			//Called when the start button is pressed. Only if enough players
			public static void Postfix(GameStartManager __instance, [HarmonyArgument(0)] bool canStart) => GameLobby.GameStarting(new GameLobbyWrapper(__instance), canStart);
		}

		[HarmonyPatch(typeof(GameStartManager), "SetStartCounter")]
		private static class StartCountDownPatch {
			public static void Prefix(GameStartManager __instance, [HarmonyArgument(0)] sbyte value) => GameLobby.SetStartCounterPre(new GameLobbyWrapper(__instance), value);
            
			public static void Postfix(GameStartManager __instance, [HarmonyArgument(0)] sbyte value) => GameLobby.SetStartCounterPost(new GameLobbyWrapper(__instance), value);
		}
        
		[HarmonyPatch(typeof(GameStartManager), "Update")]
		private static class LobbyUpdatePatch
		{
			public static void Postfix(GameStartManager __instance) => GameLobby.Update(new GameLobbyWrapper(__instance));
		}
        
		[HarmonyPatch(typeof(GameStartManager), "MakePublic")]
		private static class MakePublicPatch
		{
			public static void Postfix(GameStartManager __instance) => GameLobby.MakePublic(new GameLobbyWrapper(__instance));
		}
	}
}