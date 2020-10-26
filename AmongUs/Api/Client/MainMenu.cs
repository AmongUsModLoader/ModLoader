using System;

namespace AmongUs.Api
{
    public static class MainMenu
    {
        public static MainMenuManager Instance;
        public static event Action<MainMenuManager> DisplayMenuEvent;
        public static event Action<VersionShower> VersionShowEvent;

        public static void ShowMenu(MainMenuManager manager) => DisplayMenuEvent?.Invoke(manager);
        public static void ShowVersion(VersionShower shower) => VersionShowEvent?.Invoke(shower);
    }
}
