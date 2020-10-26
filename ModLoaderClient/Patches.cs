using AmongUs.Api;
using HarmonyLib;

namespace AmongUs.Client.Loader
{
    internal static class ModPatches
    {
        [HarmonyPatch(typeof(GameStartManager), "Start")]
        private static class GameStartPatch
        {
            public static void Postfix(GameStartManager __instance) {
                System.Console.WriteLine("asdfasdfasdf");
                __instance.MinPlayers = 0;
                GameLobby.Start(__instance);
            }
        }
        
        [HarmonyPatch(typeof(GameStartManager), "BeginGame")]
        private static class GameBeginPatch
        {
            //Called when the start button is pressed. Even if there arent enough players
            public static void Postfix(GameStartManager __instance) => GameLobby.TryStart(__instance);
        }
        
        [HarmonyPatch(typeof(GameStartManager), "ReallyBegin")]
        private static class ReallyBeginPatch
        {
            //Called when the start button is pressed. Only if enough players
            public static void Postfix(GameStartManager __instance, bool IGOMGMBEDDI) => GameLobby.GameStarting(__instance, IGOMGMBEDDI);
        }

        [HarmonyPatch(typeof(GameStartManager), "SetStartCounter")]
        private static class StartCountDownPatch {
            public static void Prefix(GameStartManager __instance, sbyte HOPFNGJCCPN) => GameLobby.SetStartCounterPre(__instance, HOPFNGJCCPN);
            
            public static void Postfix(GameStartManager __instance, sbyte HOPFNGJCCPN) => GameLobby.SetStartCounterPost(__instance, HOPFNGJCCPN);
        }
        
        [HarmonyPatch(typeof(GameStartManager), "Update")]
        private static class LobbyUpdatePatch
        {
            public static void Postfix(GameStartManager __instance) => GameLobby.Update(__instance);
        }
        
        [HarmonyPatch(typeof(GameStartManager), "MakePublic")]
        private static class MakePublicPatch
        {
            public static void Postfix(GameStartManager __instance) => GameLobby.MakePublic(__instance);
        }

        [HarmonyPatch(typeof(LanguageSetter), "SetLanguage")]
        private static class LanguageSetPatch
        {
            public static void Postfix(ref LanguageButton __0) => Language.Change(__0);
        }

        [HarmonyPatch(typeof(MeetingHud), "Update")]
        private static class MeetingHudUpdatePatch
        {
            public static void Postfix(MeetingHud __instance) => VotingScreen.Update(__instance);
        }
    }

    internal static class LoaderPatches
    {
        [HarmonyPatch(typeof(MainMenuManager), "Start")]
        private static class MenuStartPatch
        {
            public static void Postfix(MainMenuManager __instance) => MainMenu.ShowMenu(__instance);
        }
        
        [HarmonyPatch(typeof(VersionShower), "Start")]
        private static class VersionShowerPatch
        {
            public static void Postfix(VersionShower __instance) => MainMenu.ShowVersion(__instance);
        }
    }
}
