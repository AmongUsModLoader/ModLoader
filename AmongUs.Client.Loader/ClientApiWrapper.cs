using System.Collections.Generic;
using AmongUs.Api;
using AmongUs.Loader.Internal;
using BepInEx.Logging;
using Logger = BepInEx.Logging.Logger;
using LogLevel = AmongUs.Api.LogLevel;

namespace AmongUs.Client.Loader
{
    public class ClientApiWrapper : ApiWrapper
    {
        //TODO probably need a better way to do this, mainly one that doesn't fuck up the object lifetimes
        public override string Language => (ModLoaderPlugin._options?.EKMHEKKICFL?.HFHEGBIOKNE ?? KPOBLKLMOLL.English).ToString();

        public override ILogger CreateLogger(string name) => new ClientLogger(name);
        
        private class ClientLogger : ILogger
        {
            private readonly ManualLogSource _manualLog;

            public ClientLogger(string name) => _manualLog = Logger.CreateLogSource(name);

            public void Write(object message, LogLevel level = LogLevel.Info) =>
                _manualLog.Log((BepInEx.Logging.LogLevel) level, message);
        }
    }
}
