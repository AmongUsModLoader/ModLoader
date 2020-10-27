using AmongUs.Api;
using HarmonyLib;
using UnityEngine;

namespace ModLoaderClient.Patches
{
    internal static class PlayerColorPatches
    {
        [HarmonyPatch(typeof (PlayerTab), "UpdateAvailableColors")]
        private static class UpdateAvailableColorsPatch
        {
            public static bool Prefix(PlayerTab __instance) => PlayerColors.SetAvailableColors(__instance);
        }

        [HarmonyPatch(typeof (PlayerTab), "JBBOGJHCEOI")]
        private static class SelectColorPatch
        {
            public static bool Prefix([HarmonyArgument(0)] int color) => PlayerColors.SelectColor(color);
        }

        [HarmonyPatch(typeof (PlayerControl), "CheckColor")]
        private static class CheckColorPatch
        {
            public static bool Prefix(PlayerControl __instance, [HarmonyArgument(0)] byte color) =>
                PlayerColors.TrySetColor(__instance, color);
        }
    }
}
