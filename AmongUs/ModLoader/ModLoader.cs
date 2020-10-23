using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        private static readonly Harmony Harmony = new Harmony("among_us_modloader");

        internal static void Initialize()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);
            
            //TODO improve this
            typeof (Game).GetNestedTypes().Do(Harmony.PatchAll);
            typeof (Language).GetNestedTypes().Do(Harmony.PatchAll);
            typeof (MainMenu).GetNestedTypes().Do(Harmony.PatchAll);
            Log.LogDebug("Initialized events");
        }
        
        internal static void LoadMod(Assembly assembly)
        {
            foreach (var resource in assembly.GetManifestResourceNames())
            {
                var rm = new ResourceManager(resource, assembly);

                var set = rm.GetResourceSet(CultureInfo.CurrentCulture, false, false);
                if (set == null) continue;
                var loaded = false;

                foreach (var type in from DictionaryEntry entry in set 
                    let key = entry.Key.ToString() 
                    let value = entry.Value?.ToString() 
                    where key == "Entry" && value != null 
                    select assembly.GetType(value))
                {
                    if (!typeof(Mod).IsAssignableFrom(type) || !(type.GetConstructor(new Type[0])?.Invoke(new object[0]) is Mod mod)) continue;
                    
                    Mods[mod.ID] = mod;
                    mod.Load();
                    Log.LogDebug($"{mod.Name}({mod.ID}) has been loaded.");
                    loaded = true;
                    break;
                }
                
                if (loaded) break;
            }
        }
    }
}
