using AmongUs.Api;
using AmongUs.Client.Loader.Api;
using HarmonyLib;
using UnityEngine;

namespace AmongUs.Client.Loader.Patches
{
    internal static class ModPatches
    {
        [HarmonyPatch(typeof(GPOHFPAIEMA), "Update")]
        private static class MeetingHudUpdatePatch
        {
            public static void Postfix(GPOHFPAIEMA __instance) =>
                VotingScreen.Update(new VotingScreenWrapper(__instance));
        }
        
        
        /*[HarmonyPatch(typeof(PlayerControl), "SetSkinImage")]
        [HarmonyPatch(new []{ typeof(uint), typeof(SpriteRenderer)})]
        private static class HackyPatchy
        {
            public static void Postfix(PlayerControl __instance, [HarmonyArgument(0)] SkinData a,[HarmonyArgument(1)] SpriteRenderer b) {
                System.Console.WriteLine("Ooga booga");
            }
        }*/
    }

    internal static class LoaderPatches
    {
        [HarmonyPatch(typeof(CGFOAAMFEFA), "Start")]
        private static class VersionShowerPatch
        {
            public static void Postfix(CGFOAAMFEFA __instance) =>
                __instance.text.Text = MainMenu.ShowVersion(__instance.text.Text);
        }
    }
}
