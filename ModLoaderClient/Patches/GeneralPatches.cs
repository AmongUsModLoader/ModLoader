using AmongUs.Api;
using AmongUs.Client.Loader.Api;
using HarmonyLib;

namespace AmongUs.Client.Loader
{
    internal static class ModPatches
    {
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
