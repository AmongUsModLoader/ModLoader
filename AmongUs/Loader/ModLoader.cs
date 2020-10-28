using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Api;
using AmongUs.Api.Registry;

namespace AmongUs.Loader
{
    public class ModLoader : Mod
    {
        public static readonly ModLoader Instance = new ModLoader();
        public const string ModDirectory = "Mods";

        public Dictionary<string, Mod> Mods { get; } = new Dictionary<string, Mod>();
        public bool IsClient { get; set; }

        private ModLoader() : base("ModLoader", "Among Us ModLoader", "0.1")
        {
            if (Instance != null) throw new InvalidOperationException($"You can not create a new instance of {ID}.");
            Authors = new[] { "Ashley Wright (Ms. Random)", "George Kazanjian" };
            Description = "API Wrapper and Modification Loader";
            Side = ModSide.Common;
        }

        public override void Load(RegistrarProvider registrar)
        {
            MainMenu.VersionShowEvent += text => $"{text}, {ID} v{Version}\nMods: {Mods.Count}";
        }

        public override bool Unload() => throw new InvalidOperationException($"You can not unload the {ID}.");
        
        public async Task AddMod(Mod mod, Assembly assembly)
        {
            await mod.SetUnderlyingAssembly(assembly);
            mod.Load(new RegistrarProvider(mod.ID));
            Mods[mod.ID] = mod;
        }

        public async Task LoadModsAsync()
        {
            var dir = Directory.GetCurrentDirectory() + "\\";
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

                        await AddMod(mod, assembly);
                        Log.Write($"{mod.Name}({mod.ID}) has been loaded.", LogLevel.Debug);
                    }
                }
            }
        }
    }
}
