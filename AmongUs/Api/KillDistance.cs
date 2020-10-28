using System.Collections.Generic;
using AmongUs.Api.Registry;

namespace AmongUs.Api
{
    public class KillDistance : RegistryObject
    {
        public static readonly Dictionary<RegistryKey, KillDistance> Registry =
            new Dictionary<RegistryKey, KillDistance>();
        
        public float Value { get; }

        public KillDistance(float value)
        {
            Value = value;
        }
    }
}
