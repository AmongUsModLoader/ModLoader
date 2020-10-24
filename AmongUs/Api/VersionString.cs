using System;
using HarmonyLib;

namespace AmongUs.Api
{
    public static class VersionString
    {
        public static event Action<VersionShower> ShowEvent;
        
        [HarmonyPatch(typeof(VersionShower), "Start")]
        public static class VersionShowerPatch
        {
            public static void Postfix(VersionShower __instance) => ShowEvent?.Invoke(__instance);
        }
    }
}
