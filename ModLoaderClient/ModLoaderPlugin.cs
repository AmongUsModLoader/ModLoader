using System;
using System.IO;
using System.Reflection;
using AmongUs.Loader;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;

namespace AmongUs.Client.Loader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        private readonly Harmony _harmony = new Harmony("amongus.modloader");

        public override void Load()
        {
            var loader = ModLoader.Instance;
            InitializeLoaderEvents();
            loader.AddMod(loader);

            if (!Directory.Exists(ModLoader.ModDirectory)) return;
            
            InitializeModEvents();
            loader.LoadMods();
        }
        
        private void AddPatchType(Type type) => type.GetNestedTypes(BindingFlags.NonPublic).Do(_harmony.PatchAll);

        private void InitializeLoaderEvents()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);
            AddPatchType(typeof(ModPatches));
        }
        
        private void InitializeModEvents()
        {
            AddPatchType(typeof(LoaderPatches));
            Log.LogDebug("Initialized Events.");
        }
    }
}
