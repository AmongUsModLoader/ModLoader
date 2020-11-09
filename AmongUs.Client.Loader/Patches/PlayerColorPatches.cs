using AmongUs.Api;
using AmongUs.Client.Loader.Api;
using HarmonyLib;

namespace AmongUs.Client.Loader.Patches
{
    internal static class PlayerColorPatches
    {
        /*[HarmonyPatch(typeof (EDOJGCNHOLG), "AIJPLBKCABM")]
        private static class UpdateAvailableColorsPatch
        {
            public static bool Prefix(EDOJGCNHOLG __instance) => PlayerColors.PostSetAvailableColorsEvent(new PlayerTabWrapper(__instance));
        }

        //TODO fix this method call cause it seems to not exist anymore
        [HarmonyPatch(typeof (EDOJGCNHOLG), "JBBOGJHCEOI")]
        private static class SelectColorPatch
        {
            public static bool Prefix(EDOJGCNHOLG __instance, [HarmonyArgument(0)] int color) => PlayerColors.PostSelectColorEvent((Color) color);
        }*/

        [HarmonyPatch(typeof (GLHCHLEDNBA), "CheckColor")]
        private static class CheckColorPatch
        {
            public static bool Prefix(GLHCHLEDNBA __instance, [HarmonyArgument(0)] byte color) => PlayerColors.PostTrySetColorEvent(new PlayerWrapper(__instance), (Color) color);
        }
    }
}
