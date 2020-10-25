using AmongUs.Api;

namespace AmongUs.ModLoader.Internal
{
    public static class ApiWrapper
    {
        public static IApiWrapper Instance { get; set; }
    }
    
    public interface IApiWrapper
    {
        ILogger CreateLogger(string name);
    }
}
