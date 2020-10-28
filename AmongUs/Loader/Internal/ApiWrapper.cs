using AmongUs.Api;

namespace AmongUs.Loader.Internal
{
    public abstract class ApiWrapper
    {
        public static ApiWrapper Instance { get; set; }

        [Side(ModSide.Client)]
        public abstract string Language { get; }

        public abstract ILogger CreateLogger(string name);
    }
}
