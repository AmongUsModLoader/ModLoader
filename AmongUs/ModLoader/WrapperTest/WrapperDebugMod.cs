using System;
using System.Collections.Generic;
using BepInEx.Logging;
using HarmonyLib;
using UnhollowerBaseLib.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AmongUsMod.Loader.WrapperTest {
	
	public class WrapperDebugMod {

		//Testing init
		public void Init(ManualLogSource log) {
			log.LogMessage("Mod hath bean loadded");

			GameStartEvent.Event += instance => {
				instance.PlayerCounter.Text = "1/69";
				System.Console.WriteLine("BBBBDFJKSDFJ");
			};

			LanguageSetEvent.Event += (button) => {
				System.Console.WriteLine("Changed language to " + button.Title);
			};

			MainMenuEvent.Event += instance => {
				System.Console.WriteLine(instance.name);
			};


			UnityAction<Scene, LoadSceneMode> unityAction = (Action<Scene, LoadSceneMode>) ((scene, loadMode) =>
			{
				
			});
			SceneManager.add_sceneLoaded(unityAction);
			
			
			// MainMenuManager.Announcement = new AnnouncementPopUp();
		}
		
		public class TestComponent : MonoBehaviour
		{
			public TestComponent(IntPtr ptr)
				: base(ptr)
			{
				
			}

			private void Awake() {
				System.Console.WriteLine("AWake");
			}
		}
	}
}