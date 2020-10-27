using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Client.Loader.Patches;
using AmongUs.Loader;
using AmongUs.Loader.Internal;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.IL2CPP.UnityEngine;
using HarmonyLib;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FieldInfo = Il2CppSystem.Reflection.FieldInfo;
using Object = UnityEngine.Object;

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
            StartLoadingAsync().GetAwaiter().GetResult();
        }

        private async Task StartLoadingAsync()
        {
            var loader = ModLoader.Instance;
            AddPatchType(typeof(LoaderPatches));
            await loader.AddMod(loader, loader.GetType().Assembly);

            if (!Directory.Exists(ModLoader.ModDirectory)) return;

            //TODO this feels really bad/hacky
            //It is. But it be like that
            ClassInjector.RegisterTypeInIl2Cpp<ModLoaderUnityComponent>();
            // ClassInjector.RegisterTypeInIl2Cpp<ModsButton>();

            UnityAction<Scene, LoadSceneMode> action = null;
            action = (Action<Scene, LoadSceneMode>) ((scene, loadMode) =>
            {
                SceneManager.remove_sceneLoaded(action);
                var gameObject = new GameObject(nameof(ModLoaderPlugin));
                gameObject.AddComponent<ModLoaderUnityComponent>();
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
            });
            SceneManager.add_sceneLoaded(action);
            //

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
                //TODO this.. doesn't seem to work lol
                _options = GetComponent<GameOptionsMenu>();
                System.Console.WriteLine("GDSFSDF");
               // System.Console.WriteLine( GetComponentInParent<GameOptionsMenu>().name);

               //TODO someone plez unhorrify this 
               // GameObject.FindObjectOfType<>()
               var button = GameObject.Find("HowToPlayButton");
               var buttonManager = GameObject.Find("PassiveButtonManager");
               // var manager = GameObject.Find("MainMenuManager");
               // button.GetComponent<PassiveButton>();
               System.Console.WriteLine(button.name);

               // TextTranslator.
               
               var gameObject = new GameObject(nameof(Button));
               gameObject.AddComponent<PassiveButton>();
               gameObject.AddComponent<ButtonRolloverHandler>();
               
               UnityAction action = null;
               action = (Action) (() =>
               {
                  System.Console.WriteLine(" finally this god damn button works");
               });
               
               gameObject.GetComponent<PassiveButton>().OnClick.AddListener(action);

               gameObject.name = "GamerButton";
               UnityEngine.Object.DontDestroyOnLoad(gameObject);
               
               System.Console.WriteLine(button.layer + " " + button.transform.position.x + " " + button.transform.position.y +  " " +button.transform.position.z);
               System.Console.WriteLine(gameObject.layer + " " + gameObject.transform.position.x + " " + gameObject.transform.position.y +  " " +gameObject.transform.position.z);

               /*Object[] components = GameObject.FindObjectsOfType<Object>();
               foreach (var VARIABLE in components) {
                   System.Console.WriteLine(VARIABLE.name + " : " + VARIABLE.GetType().Name);
               }*/

               foreach(var pp in button.GetComponents<Component>()) {
                   CopyComponent(pp, gameObject);
                   System.Console.WriteLine(pp.name + " : a" );
               }
               
               gameObject.transform.position = new Vector3(3, -2.45f, 0);
               buttonManager.GetComponent<PassiveButtonManager>().RegisterOne(gameObject.GetComponent<PassiveButton>());
            }
            
            T CopyComponent<T>(T original, GameObject destination) where T : Component
            {
                Il2CppSystem.Type type = original.GetIl2CppType();
                Component copy = destination.AddComponent(type);
                Il2CppReferenceArray<FieldInfo> fields = type.GetFields(Il2CppSystem.Reflection.BindingFlags.Default);
                foreach (FieldInfo field in fields)
                {
                    field.SetValue(copy, field.GetValue(original));
                }
                return copy as T;
            }
        }
    }
}
