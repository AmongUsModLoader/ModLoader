using System;
using System.IO;
using System.Reflection;
using AmongUs.Loader;
using AmongUs.Loader.Internal;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;

namespace AmongUs.Client.Loader
{
    [BepInPlugin("AUSML", "Client ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        private readonly Harmony _harmony = new Harmony("amongus.modloader");
        
        static ModLoaderPlugin()
        {
            Assembly.LoadFile(Directory.GetCurrentDirectory() + "\\BepInEx\\plugins\\AmongUsModLoader.dll");
            ApiWrapper.Instance = new ClientApiWrapper();
        }

        public override void Load()
        {
            var loader = ModLoader.Instance;
            UnityVersionHandler.Initialize(2019, 4, 9);
            AddPatchType(typeof(LoaderPatches));
            loader.AddMod(loader);

            if (!Directory.Exists(ModLoader.ModDirectory)) return;
            
            AddPatchType(typeof(ModPatches));
            Log.LogDebug("Initialized Events.");
            loader.LoadMods();
        }
        
        private void AddPatchType(Type type) => type.GetNestedTypes(BindingFlags.NonPublic).Do(_harmony.PatchAll);
    }
}
