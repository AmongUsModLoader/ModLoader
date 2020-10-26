using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Api;

namespace AmongUs.Loader
{
    public class ModLoader : Mod
    {
        public static readonly ModLoader Instance = new ModLoader();
        public const string ModDirectory = "Mods";
        
        public readonly Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();

        private ModLoader() : base("ModLoader", "Among Us ModLoader", "0.1")
        {
            if (Instance != null) throw new InvalidOperationException($"You can not create a new instance of {ID}.");
            Side = ModSide.Common;
        }

        public override void Load()
        {
            MainMenu.VersionShowEvent += shower => shower.text.Text += $", {ID} v{Version}";
        }

        public override bool Unload() => throw new InvalidOperationException($"You can not unload the {ID}.");
        
        public void AddMod(Mod mod)
        {
            mod.Load();
            Mods[mod.ID] = mod;
        }

        public void LoadMods()
        {
            LoadModsAsync(Directory.GetCurrentDirectory() + "\\").GetAwaiter().GetResult();
            var modCount = Mods.Count - 1;
            Log.Write(
                $"ModLoader Initialized. {(modCount == 0 ? "No" : modCount.ToString())} " +
                $"{(modCount == 1 ? "mod has" : "mods have")} been found and loaded."
            );
        }

        private async Task LoadModsAsync(string dir)
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
                .FirstOrDefault(resource => resource.EndsWith(".Resources.ModEntry.txt"));
            
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
                        Log.Write($"{mod.Name}({mod.ID}) has been loaded.", LogLevel.Debug);
                    }
                }
            }
        }
    }
}
