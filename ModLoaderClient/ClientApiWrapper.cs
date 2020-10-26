using AmongUs.Api;
using AmongUs.Loader.Internal;
using BepInEx.Logging;
using Logger = BepInEx.Logging.Logger;
using LogLevel = AmongUs.Api.LogLevel;

namespace AmongUs.Client.Loader
{
    public class ClientApiWrapper : IApiWrapper
    {
        public ILogger CreateLogger(string name) => new ClientLogger(name);
        
        private class ClientLogger : ILogger
        {
            private readonly ManualLogSource _manualLog;

            public ClientLogger(string name) => _manualLog = Logger.CreateLogSource(name);

            public void Write(object message, LogLevel level = LogLevel.Info) => _manualLog.Log((BepInEx.Logging.LogLevel) level, message);
        }
    }
}
