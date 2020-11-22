using System.Collections.Generic;
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
        private static readonly SortedDictionary<int, int> MaxImpostors = new SortedDictionary<int, int>()
        {
            [0] = 1,
            [7] = 2,
            [9] = 3
        };
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

        public override void SetMaxImpostors(int playerCount, int maxImpostors)
        {
            if (playerCount == 0) playerCount = 1;
            
            MaxImpostors[playerCount] = maxImpostors;
            var size = MaxImpostors.Last().Key;
            var array = new Il2CppStructArray<int>(size);

            var lastPair = MaxImpostors.First();
            foreach (var pair in MaxImpostors)
            {
                for (var i = lastPair.Key - 1; i < pair.Key; i++)
                {
                    array[i] = lastPair.Value;
                }
                lastPair = pair;
            }

            OEFJGMAEENB.ALNGMJFMDHA = array;
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
