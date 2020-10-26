using System.Collections.Generic;
using AmongUs.Api;
using AmongUs.Loader.Internal;
using BepInEx.Logging;
using Logger = BepInEx.Logging.Logger;
using LogLevel = AmongUs.Api.LogLevel;

namespace AmongUs.Client.Loader
{
    public class ClientApiWrapper : IApiWrapper
    {
        private static int _lastTaskId = (int) LJGAMCIMPMO.RebootWifi;
        internal static readonly Dictionary<TaskType, int> TaskTypes = new Dictionary<TaskType, int>();

        public string Language => ModLoaderPlugin._options.EKMHEKKICFL.HFHEGBIOKNE.ToString();
        
        public ILogger CreateLogger(string name) => new ClientLogger(name);

        public void RegisterTask(TaskType type) => TaskTypes[type] = ++_lastTaskId;

        private class ClientLogger : ILogger
        {
            private readonly ManualLogSource _manualLog;

            public ClientLogger(string name) => _manualLog = Logger.CreateLogSource(name);

            public void Write(object message, LogLevel level = LogLevel.Info) =>
                _manualLog.Log((BepInEx.Logging.LogLevel) level, message);
        }
    }
}
