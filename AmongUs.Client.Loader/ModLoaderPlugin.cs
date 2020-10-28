using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Api;
using AmongUs.Api.Registry;
using AmongUs.Client.Loader.Patches;
using AmongUs.Loader;
using AmongUs.Loader.Internal;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Il2CppSystem.Linq;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AmongUs.Client.Loader
{
    [BepInPlugin("AUSML", "Client ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        internal static GameOptionsMenu _options;
        private readonly Harmony _harmony = new Harmony("amongus.modloader");
        private static int _lastTaskId = (int) LJGAMCIMPMO.RebootWifi;
        internal static readonly Dictionary<TaskType, int> TaskTypes = new Dictionary<TaskType, int>();

        static ModLoaderPlugin()
        {
            Assembly.LoadFile(Directory.GetCurrentDirectory() + "\\BepInEx\\plugins\\AmongUs.dll");
            ApiWrapper.Instance = new ClientApiWrapper();
        }

        public override void Load()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);
            ModLoader.Instance.IsClient = true;
            LoadVanillaRegistries();
            StartLoadingAsync().GetAwaiter().GetResult();
        }

        private void LoadVanillaRegistries()
        {
            //Kill distances
            for (var i = 0; i < Math.Min(OPIJAMILNFD.OKGJOLEBGPG.Count, OPIJAMILNFD.OHDFNBCBJLN.Count); i++)
            {
                var key = new RegistryKey("AmongUs", OPIJAMILNFD.OHDFNBCBJLN[i]);
                var distance = new KillDistance(OPIJAMILNFD.OKGJOLEBGPG[i]) { Key = key };
                KillDistance.Registry[key] = distance;
            }

            Registrar<KillDistance>.OnRegister += (key, distance) =>
            {
                var newSize = Math.Min(OPIJAMILNFD.OKGJOLEBGPG.Count, OPIJAMILNFD.OHDFNBCBJLN.Count);
                var distancesArray = new Il2CppStructArray<float>(newSize);
                var namesArray = new Il2CppStringArray(newSize);
                
                for (var i = 0; i < newSize; i++)
                {
                    distancesArray[i] = OPIJAMILNFD.OKGJOLEBGPG[i];
                    namesArray[i] = OPIJAMILNFD.OHDFNBCBJLN[i];
                }

                distancesArray[newSize - 1] = distance.Value;
                namesArray[newSize - 1] = distance.Key.Name;

                OPIJAMILNFD.OKGJOLEBGPG = distancesArray;
                OPIJAMILNFD.OHDFNBCBJLN = namesArray;
            };
            
            //Tasks
            for (var i = 0; i <= _lastTaskId; i++)
            {
                var originalTask = (LJGAMCIMPMO) i;
                var key = new RegistryKey("AmongUs", originalTask.ToString());
                var taskType = new TaskType { Key = key };
                TaskType.Registry[key] = taskType;
            }
            
            Registrar<TaskType>.OnRegister += (key, type) => TaskTypes[type] = ++_lastTaskId;
        }

        private async Task StartLoadingAsync()
        {
            var loader = ModLoader.Instance;
            AddPatchType(typeof(LoaderPatches));
            await loader.AddMod(loader, loader.GetType().Assembly);

            if (!Directory.Exists(ModLoader.ModDirectory)) return;

            ClassInjector.RegisterTypeInIl2Cpp<ModLoaderUnityComponent>();

            UnityAction<Scene, LoadSceneMode> action = null;
            action = (Action<Scene, LoadSceneMode>) ((scene, loadMode) =>
            {
                SceneManager.remove_sceneLoaded(action);
                var gameObject = new GameObject(nameof(ModLoaderPlugin));
                gameObject.AddComponent<ModLoaderUnityComponent>();
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
            });
            SceneManager.add_sceneLoaded(action);

            AddPatchType(typeof(ModPatches));
            AddPatchType(typeof(GameStartManagerPatches));

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

            private void Start()
            {
                _options = GetComponent<GameOptionsMenu>();
            }
        }
    }
}
