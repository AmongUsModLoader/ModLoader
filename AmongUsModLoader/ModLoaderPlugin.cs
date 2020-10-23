using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.IL2CPP;

namespace AmongUsMod.Loader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        public override void Load()
        {
            foreach (var file in Directory.GetFiles("Mods"))
            {
                if (!file.ToLower().EndsWith(".dll")) continue;
                
                 Loader.LoadMod(Assembly.LoadFile(file));
            }

            Log.LogInfo("ModLoader Loaded.");
        }
    }
}
