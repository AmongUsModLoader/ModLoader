using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace AmongUs.ModLoader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        public override void Load()
        {
            ModLoader.InitializeLoaderEvents();
            ModLoader.AddMod(new ModLoader());
            
            if (Directory.Exists(ModLoader.ModDirectory))
            {
                ModLoader.InitializeModEvents();
                
                //Load mods asynchronously from each other but blocking the main thread during loading
                ModLoader.LoadModsAsync(Directory.GetCurrentDirectory() + "\\").GetAwaiter().GetResult();
            }

            var modCount = ModLoader.Mods.Count;
            Log.LogInfo($"ModLoader Initialized. {(modCount == 0 ? "No" : modCount.ToString())} {(modCount == 1 ? "mod has" : "mods have")} been loaded.");
        }
    }
}
