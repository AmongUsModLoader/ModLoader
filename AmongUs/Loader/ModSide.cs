using System;

namespace AmongUs.Loader
{
    [Flags]
    public enum ModSide
    {
        Client = 1,
        Server = 2,
        Common = 3
    }
}
