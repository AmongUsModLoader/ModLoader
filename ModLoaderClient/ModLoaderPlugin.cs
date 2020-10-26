using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Loader;
using AmongUs.Loader.Internal;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;
using UnityEngine;

namespace AmongUs.Client.Loader
{
    [BepInPlugin("AUSML", "Client ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        internal static GameOptionsMenu _options;
        private readonly Harmony _harmony = new Harmony("amongus.modloader");

        static ModLoaderPlugin()
        {
            Assembly.LoadFile(Directory.GetCurrentDirectory() + "\\BepInEx\\plugins\\AmongUsModLoader.dll");
            ApiWrapper.Instance = new ClientApiWrapper();
        }

        public override void Load()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);
            ModLoader.Instance.IsClient = true;
            StartLoading().GetAwaiter().GetResult();
        }

        private async Task StartLoading()
        {
            var loader = ModLoader.Instance;
            AddPatchType(typeof(LoaderPatches));
            await loader.AddMod(loader, loader.GetType().Assembly);

            if (!Directory.Exists(ModLoader.ModDirectory)) return;

            AddPatchType(typeof(ModPatches));
            Log.LogDebug("Initialized Events.");
            await loader.LoadModsAsync();
            var modCount = loader.Mods.Count - 1;
            Log.LogInfo(
                $"ModLoader Initialized. {(modCount == 0 ? "No" : modCount.ToString())} " +
                $"{(modCount == 1 ? "mod has" : "mods have")} been found and loaded."
            );
        }

        private void AddPatchType(Type type) => type.GetNestedTypes(BindingFlags.NonPublic).Do(_harmony.PatchAll);
        
        public class ModLoaderUnityComponent : MonoBehaviour
        {
            public ModLoaderUnityComponent(IntPtr ptr) : base(ptr) {}

            private void Start() => _options = GetComponent<GameOptionsMenu>();
        }
    }
}
