using System;
using AmongUs.Loader;

namespace AmongUs.Api
{
    public static class PlayerColors
    {
        [Side(ModSide.Client)]
        public static event Func<int, bool> SelectColorEvent;
        public static event Func<PlayerTab, bool> SetAvailableColorsEvent;
        public static event Func<PlayerControl, int, bool> TrySetColorEvent;

        [Side(ModSide.Client)]
        public static bool SelectColor(int color) => SelectColorEvent?.Invoke(color) != false;
        public static bool SetAvailableColors(PlayerTab tab) => SetAvailableColorsEvent?.Invoke(tab) != false;
        public static bool TrySetColor(PlayerControl control, int color) => TrySetColorEvent?.Invoke(control, color) != false;
    }
}
