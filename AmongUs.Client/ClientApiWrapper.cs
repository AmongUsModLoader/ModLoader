using System.Linq;
using AmongUs.Api;
using AmongUs.Api.Loader.Internal;
using BepInEx.Logging;
using UnhollowerBaseLib;
using Logger = BepInEx.Logging.Logger;
using LogLevel = AmongUs.Api.LogLevel;

namespace AmongUs.Client
{
    public class ClientApiWrapper : ApiWrapper
    {
        //TODO probably need a better way to do this, mainly one that doesn't fuck up the object lifetimes
        public override string Language => (ModLoaderPlugin._options?.BIAIHNECBFM?.CFKEFOJGNGN ?? MEEPDFFHHLC.English).ToString();

        public override ILogger CreateLogger(string name) => new ClientLogger(name);
        public override void AddRegion(Region region)
        {
            var newArray = new Il2CppReferenceArray<CDLOPBGDBHF>(FOLCACGIEIK.DefaultRegions.Count + 1);
            for (var i = 0; i < FOLCACGIEIK.DefaultRegions.Count; i++)
            {
                newArray[i] = FOLCACGIEIK.DefaultRegions[i];
            }

            var newRegion = new CDLOPBGDBHF(region.Name, region.Address,
                new Il2CppReferenceArray<GBBLLNNMEBG>(region.Servers
                    .Select(server => new GBBLLNNMEBG(server.Name, region.Address, server.Port)).ToArray()));

            newArray[newArray.Length - 1] = newRegion;
            FOLCACGIEIK.DefaultRegions = newArray;
        }

        private class ClientLogger : ILogger
        {
            private readonly ManualLogSource _manualLog;

            public ClientLogger(string name) => _manualLog = Logger.CreateLogSource(name);

            public void Write(object message, LogLevel level = LogLevel.Info) =>
                _manualLog.Log((BepInEx.Logging.LogLevel) level, message);
        }
    }
}
