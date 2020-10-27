using System;

namespace AmongUs.Api
{
    public static class PlayerColors
    {
        public static event Func<PlayerTab, bool> SetAvailableColorsEvent;
        public static event Func<int, bool> SelectColorEvent;
        public static event Func<PlayerControl, int, bool> TrySetColorEvent;

        public static bool SetAvailableColors(PlayerTab tab) => SetAvailableColorsEvent?.Invoke(tab) != false;
        public static bool SelectColor(int color) => SelectColorEvent?.Invoke(color) != false;
        public static bool TrySetColor(PlayerControl tab, int color) => TrySetColorEvent?.Invoke(tab, color) != false;
    }
}
