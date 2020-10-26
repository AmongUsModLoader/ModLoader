using AmongUs.Api;
using HarmonyLib;

namespace AmongUs.Client.Loader
{
    internal static class ModPatches
    {
        [HarmonyPatch(typeof (GameStartManager), "Start")]
        private static class GameStartPatch
        {
            public static void Postfix(GameStartManager __instance) => Game.Start(__instance);
        }
        
        [HarmonyPatch(typeof (LanguageSetter), "SetLanguage")]
        private static class LanguageSetPatch
        {
            public static void Postfix(ref LanguageButton __0) => Language.Change(__0);
        }
    }

    internal static class LoaderPatches
    {
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
            public static void Postfix(VersionShower __instance) => MainMenu.ShowVersion(__instance);
        }
    }
}
