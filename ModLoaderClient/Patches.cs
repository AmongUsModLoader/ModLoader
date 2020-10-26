using AmongUs.Api;
using HarmonyLib;
using UnityEngine;

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
        
        [HarmonyPatch(typeof (LanguageSetter), "Start")]
        private static class LanguageStartPatch
        {
            //Called the first time you open the language settings.
            public static void Postfix(LanguageSetter __instance) {
                //Print out all the language types
                foreach (var va in __instance.DNHOHIBJNGO) {
                    System.Console.WriteLine(va.Title.Text);
                }
            }
        }
    }

    internal static class LoaderPatches
    {
        [HarmonyPatch(typeof(MainMenuManager), "LPCEHACMAPB")]
        private static class MenuConstructorPatch
        {
            public static void Postfix(MainMenuManager __instance) {
                MainMenu.Instance = __instance;
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
    
    //TODO verify if this works. I cant get among us to know that steam is open
    internal static class PetBuyablePatch
    {
        [HarmonyPatch(typeof(PetBehaviour), "get_NGBJPFEEOOP")]
        private static class MenuConstructorPatch
        {
            public static void Postfix(PetBehaviour __instance, ref string __result) {
                System.Console.WriteLine(__result);
                
            }
        }

    }
    
    //TODO Untested
    internal static class StoreMenuPatch
    {
        [HarmonyPatch(typeof(StoreMenu), "ProcessPurchase")]
        private static class MenuConstructorPatch
        {
            public static void Postfix(PetBehaviour __instance, ref string __result) {
                System.Console.WriteLine(__result);
            }
        }

    }
}
