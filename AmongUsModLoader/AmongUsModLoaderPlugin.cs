using System;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.IL2CPP;

namespace AmongUsModLoader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class AmongUsModLoaderPlugin : BasePlugin
    {
        public override void Load() {
            var modsFolder =  Directory.CreateDirectory(Config.ConfigFilePath + Path.DirectorySeparatorChar + "Mods");
            
            foreach (var file in modsFolder.GetFiles()) {
                if (file.Name.EndsWith(".dll")) {
                    var dllMod = Assembly.LoadFile(file.FullName);

                    foreach (var type in dllMod.GetExportedTypes()) {
                        var a = Activator.CreateInstance(type);
                        if (a != null && type.IsClass && a.GetType().IsAssignableFrom(typeof(AmongUsModInitializer))) {
                            type.InvokeMember("Entry", BindingFlags.InvokeMethod, null, a, null);
                        }
                    }
                }
            }
            
            //This is where we start to do stuff lol
        }
    }
}
