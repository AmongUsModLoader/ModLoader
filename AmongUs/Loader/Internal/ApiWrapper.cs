using AmongUs.Api;

namespace AmongUs.Loader.Internal
{
    public static class ApiWrapper
    {
        public static IApiWrapper Instance { get; set; }
    }
    
    public interface IApiWrapper
    {
        string Language { get; }

        ILogger CreateLogger(string name);
        void RegisterTask(TaskType type);
    }
}
