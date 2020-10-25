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
            var loader = ModLoader.Instance;
            loader.InitializeLoaderEvents();
            loader.AddMod(loader);

            if (Directory.Exists(ModLoader.ModDirectory))
            {
                loader.InitializeModEvents();

                //Load mods asynchronously from each other but blocking the main thread during loading
                loader.LoadModsAsync(Directory.GetCurrentDirectory() + "\\").GetAwaiter().GetResult();
            }

            var modCount = loader.Mods.Count - 1;
            Log.LogInfo(
                $"ModLoader Initialized. {(modCount == 0 ? "No" : modCount.ToString())} " +
                $"{(modCount == 1 ? "mod has" : "mods have")} been found and loaded."
            );
        }
    }
}
