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
