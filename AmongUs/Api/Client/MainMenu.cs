using System;

namespace AmongUs.Api {
	public static class MainMenu {
		
		public static MainMenuManager Instance;
		
		public static event Action<MainMenuManager> ConstructionEvent;
		public static event Action<VersionShower> VersionShowEvent;

		public static void ConstructMenu(MainMenuManager manager) => ConstructionEvent?.Invoke(manager);
		public static void ShowVersion(VersionShower shower) => VersionShowEvent?.Invoke(shower);
	}
}
