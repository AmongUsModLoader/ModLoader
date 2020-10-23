using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.IL2CPP;

namespace AmongUs.ModLoader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        private const string ModDirectory = "Mods";
        
        public override void Load()
        {
            if (Directory.Exists(ModDirectory))
            {
                foreach (var file in Directory.GetFiles(ModDirectory))
                {
                    if (!file.ToLower().EndsWith(".dll")) continue;

                    ModLoader.LoadMod(Assembly.LoadFile(file));
                }
            }

            var modCount = ModLoader.Mods.Count;
            Log.LogInfo($"ModLoader Initialized. {(modCount == 0 ? "No" : modCount.ToString())} mods have been loaded.");
        }
    }
}
