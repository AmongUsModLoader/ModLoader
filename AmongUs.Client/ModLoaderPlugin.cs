using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Api;
using AmongUs.Api.Loader;
using AmongUs.Api.Loader.Internal;
using AmongUs.Api.Registry;
using AmongUs.Client.Patches;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace AmongUs.Client
{
    [BepInPlugin("AUSML", "Client ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        internal static HHIDNOMFFGN _options;
        private readonly Harmony _harmony = new Harmony("amongus.modloader");
        private static int _lastTaskId = (int) CANPENMJFOD.RebootWifi;
        private static int _lastMapId = (int) DAFPFFMKPJJ.DFCBBBIBKKC.Pb;
        internal static readonly Dictionary<CANPENMJFOD, TaskType> TaskTypes = new Dictionary<CANPENMJFOD, TaskType>();
        internal static readonly Dictionary<DAFPFFMKPJJ.DFCBBBIBKKC, GameMap> MapTypes = new Dictionary<DAFPFFMKPJJ.DFCBBBIBKKC, GameMap>();
        internal static readonly Dictionary<GameMap, int> ReverseMapTypes = new Dictionary<GameMap, int>();

        static ModLoaderPlugin()
        {
            var dir = Directory.GetCurrentDirectory();
            Assembly.LoadFile(dir + Directory.GetFiles(dir).First(file => file.Contains("AmongUs.Api")));
            ApiWrapper.Instance = new ClientApiWrapper();
        }

        public override void Load()
        {
            /*UnityVersionHandler.Initialize(2019, 4, 9);
            ModLoader.Instance.IsClient = true;
            LoadVanillaRegistries();
            StartLoadingAsync().GetAwaiter().GetResult();*/
        }

        private void LoadVanillaRegistries()
        {
            //Kill distances
            Il2CppStructArray<float> OldDistancesArray() => OEFJGMAEENB.JFMGLFCHLKK;
            Il2CppStringArray OldNamesArray() => OEFJGMAEENB.GCBCGFCMMMI;
            
            for (var i = 0; i < Math.Min(OldDistancesArray().Count, OldNamesArray().Count); i++)
            {
                var key = new RegistryKey("AmongUs", OldNamesArray()[i]);
                var distance = new KillDistance(OldDistancesArray()[i]) { Key = key };
                KillDistance.Registry[key] = distance;
            }

            Registrar<KillDistance>.OnRegister += (key, distance) =>
            {
                var newSize = Math.Min(OldDistancesArray().Count, OldNamesArray().Count);
                var distancesArray = new Il2CppStructArray<float>(newSize + 1);
                var namesArray = new Il2CppStringArray(newSize + 1);
                
                for (var i = 0; i < newSize; i++)
                {
                    distancesArray[i] = OldDistancesArray()[i];
                    namesArray[i] = OldNamesArray()[i];
                }

                distancesArray[newSize] = distance.Value;
                namesArray[newSize] = Language.Translate(key.ModId, key.Name);

                OEFJGMAEENB.JFMGLFCHLKK = distancesArray;
                OEFJGMAEENB.GCBCGFCMMMI = namesArray;
            };
            
            //Tasks
            for (var i = 0; i <= _lastTaskId; i++)
            {
                var originalTask = (CANPENMJFOD) i;
                var key = new RegistryKey("AmongUs", originalTask.ToString());
                var taskType = new TaskType {Key = key};
                TaskType.Registry[key] = taskType;
                TaskTypes[originalTask] = taskType;
            }

            Registrar<TaskType>.OnRegister += (key, type) => TaskTypes[(CANPENMJFOD) (++_lastTaskId)] = type;
            
            //Maps
            for (var i = 0; i <= _lastMapId; i++)
            {
                var originalMap = (DAFPFFMKPJJ.DFCBBBIBKKC) i;
                var key = new RegistryKey("AmongUs", originalMap.ToString());
                var gameMap = new GameMap {Key = key};
                GameMap.Registry[key] = gameMap;
                MapTypes[originalMap] = gameMap;
                ReverseMapTypes[gameMap] = i;
            }

            Registrar<GameMap>.OnRegister += (key, map) =>
            {
                var count = OEFJGMAEENB.JAKFIOPEFBI.Count;
                var mapNames = new Il2CppStringArray(count);
                
                for (var i = 0; i < count; i++) mapNames[i] = OEFJGMAEENB.JAKFIOPEFBI[i];
                
                mapNames[count] = Language.Translate(key.ModId, key.Name);

                OEFJGMAEENB.JAKFIOPEFBI = mapNames;
                MapTypes[(DAFPFFMKPJJ.DFCBBBIBKKC) (++_lastMapId)] = map;
                ReverseMapTypes[map] = _lastMapId;
            };
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
                Object.DontDestroyOnLoad(gameObject);
            });
            SceneManager.add_sceneLoaded(action);

            AddPatchType(typeof(ModPatches));
            AddPatchType(typeof(GameStartManagerPatches));
            AddPatchType(typeof(PlayerColorPatches));

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
                //TODO
            }
        }
    }
}
