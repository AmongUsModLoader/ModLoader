using AmongUs.Loader.Internal;

namespace AmongUs.Api
{
    public static class Logger
    {
        public static ILogger Create(string name) => ApiWrapper.Instance.CreateLogger(name);
    }
    
    public interface ILogger
    {
        void Write(object message, LogLevel level = LogLevel.Info);
    }
    
    public enum LogLevel
    {
        Fatal = 1,
        Error = 2,
        Warning = 4,
        Message = 8,
        Info = 16,
        Debug = 32
    }
}
