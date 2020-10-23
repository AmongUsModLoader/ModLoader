using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using AmongUs.Api;
using BepInEx.Logging;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;

namespace AmongUs.ModLoader
{
    public static class ModLoader
    {
        public static readonly ManualLogSource Log = Logger.CreateLogSource("ModLoader");
        public static readonly Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();
        private static readonly Harmony Harmony = new Harmony("amongus.modloader");
        public const string ModDirectory = "Mods";

        internal static void Initialize()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);
            
            //TODO improve this
            typeof (Game).GetNestedTypes().Do(Harmony.PatchAll);
            typeof (Language).GetNestedTypes().Do(Harmony.PatchAll);
            typeof (MainMenu).GetNestedTypes().Do(Harmony.PatchAll);
            Log.LogDebug("Initialized events");
        }

        internal static async ValueTask LoadModsAsync(string dir)
        {
            foreach (var file in Directory.GetFiles(ModDirectory))
            {
                if (!file.ToLower().EndsWith(".dll")) continue;
                
                await LoadModAsync(Assembly.LoadFile(dir + file));
            }
        }
        
        private static async ValueTask LoadModAsync(Assembly assembly)
        {
            var modInfo = assembly.GetManifestResourceStream("ModEntry");
            if (modInfo != null)
            {
                var entryType = assembly.GetType(await new StreamReader(modInfo).ReadToEndAsync());
                if (entryType == null || !typeof(Mod).IsAssignableFrom(entryType) ||
                    !(entryType.GetConstructor(new Type[0])?.Invoke(new object[0]) is Mod mod)) return;
                
                mod.Load();
                Mods[mod.ID] = mod;
                Log.LogDebug($"{mod.Name}({mod.ID}) has been loaded.");
            }
        }
    }
}
