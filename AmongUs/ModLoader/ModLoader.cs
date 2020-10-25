using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Api;
using BepInEx;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;

namespace AmongUs.ModLoader
{
    public class ModLoader : Mod
    {
        private static readonly BepInPlugin LoaderInfo = typeof(ModLoaderPlugin).GetCustomAttribute<BepInPlugin>();
        public static readonly ModLoader Instance = new ModLoader();
        public const string ModDirectory = "Mods";
        
        public readonly Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();
        private readonly Harmony _harmony = new Harmony("amongus.modloader");

        private ModLoader() : base("ModLoader", LoaderInfo.Name, LoaderInfo.Version.ToString())
        {
            if (Instance != null) throw new InvalidOperationException($"You can not create a new instance of {ID}.");
        }

        public override void Load()
        {
            MainMenu.VersionShowEvent += shower => shower.text.Text += $", ${ID} v{Version}";
        }

        public override bool Unload() => throw new InvalidOperationException($"You can not unload the {ID}.");

        private void AddPatchType(Type type) => type.GetNestedTypes().Do(_harmony.PatchAll);

        internal void InitializeLoaderEvents()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);
            AddPatchType(typeof(MainMenu));
        }
        
        internal void InitializeModEvents()
        {
            //TODO improve this
            AddPatchType(typeof(Game));
            AddPatchType(typeof(Language));
            Log.LogDebug("Initialized Events.");
        }

        internal void AddMod(Mod mod)
        {
            mod.Load();
            Mods[mod.ID] = mod;
        }
        
        internal async Task LoadModsAsync(string dir)
        {
            foreach (var file in Directory.GetFiles(ModDirectory))
            {
                if (!file.ToLower().EndsWith(".dll")) continue;

                await LoadModAsync(Assembly.LoadFile(dir + file));
            }
        }

        private async Task LoadModAsync(Assembly assembly)
        {
            var firstEntryName = assembly.GetManifestResourceNames()
                .FirstOrDefault(resource => resource.EndsWith(".ModEntry.txt"));
            
            if (firstEntryName != null)
            {
                using (var entry = assembly.GetManifestResourceStream(firstEntryName))
                {
                    if (entry != null)
                    {
                        var entryType = assembly.GetType(await new StreamReader(entry).ReadToEndAsync());
                        if (entryType == null || !typeof(Mod).IsAssignableFrom(entryType) ||
                            !(entryType.GetConstructor(new Type[0])?.Invoke(new object[0]) is Mod mod)) return;

                        AddMod(mod);
                        Log.LogDebug($"{mod.Name}({mod.ID}) has been loaded.");
                    }
                }
            }
        }
    }
}
