using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AmongUsMod.Loader.WrapperTest;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;

namespace AmongUsMod.Loader
{
    [BepInPlugin("AUSML", "Among Us ModLoader", "0.1")]
    [BepInProcess("Among Us.exe")]
    public class ModLoaderPlugin : BasePlugin
    {
        public Harmony Harmony { get; } = new Harmony("debug.mod");
        
        public override void Load()
        {
            UnityVersionHandler.Initialize(2019, 4, 9);

            Directory.CreateDirectory("Mods");
            foreach (var file in Directory.GetFiles("Mods"))
            {
                if (!file.ToLower().EndsWith(".dll")) continue;
                
                 Loader.LoadMod(Assembly.LoadFile(file));
            }

            Log.LogInfo("ModLoader Loaded.");
            
            var test = new WrapperDebugMod();
            test.Init(Log);
            
            //This is horrific, and needs to be changed before we add more events
            ((IEnumerable<Type>) typeof (GameStartEvent).GetNestedTypes()).Do<Type>(new Action<Type>(this.Harmony.PatchAll));
            ((IEnumerable<Type>) typeof (LanguageSetEvent).GetNestedTypes()).Do<Type>(new Action<Type>(this.Harmony.PatchAll));
            ((IEnumerable<Type>) typeof (MainMenuEvent).GetNestedTypes()).Do<Type>(new Action<Type>(this.Harmony.PatchAll));
        }
    }
}
