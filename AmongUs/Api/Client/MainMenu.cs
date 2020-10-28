using System;
using AmongUs.Loader;

namespace AmongUs.Api
{
    [Side(ModSide.Client)]
    public static class MainMenu
    {
        public static MainMenuManager Instance;
        public static event Action<MainMenuManager> DisplayMenuEvent;
        public static event Func<string, string> VersionShowEvent;

        public static void ShowMenu(MainMenuManager manager) => DisplayMenuEvent?.Invoke(manager);
        public static string ShowVersion(string text) => VersionShowEvent?.Invoke(text) ?? text;
    }
}
