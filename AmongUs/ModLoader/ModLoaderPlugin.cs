using System.IO;
using BepInEx;
using BepInEx.IL2CPP;

namespace AmongUs.ModLoader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        public override void Load()
        {
            if (Directory.Exists(ModLoader.ModDirectory))
            {
                //Only initialize if we have mods/need it
                ModLoader.Initialize();
                
                //Load mods asynchronously from each other but blocking the main thread during loading
                ModLoader.LoadModsAsync(Directory.GetCurrentDirectory() + "\\").GetAwaiter().GetResult();
            }

            var modCount = ModLoader.Mods.Count;
            Log.LogInfo($"ModLoader Initialized. {(modCount == 0 ? "No" : modCount.ToString())} mods have been loaded.");
        }
    }
}
