using System;
using System.Collections.Generic;

namespace AmongUs.Api.Registry
{
    public readonly struct Registrar<T> where T : RegistryObject
    {
        public static event Action<RegistryKey, T> OnRegister;
        private Dictionary<RegistryKey, T> Registry { get; }
        private string OwnerMod { get; }

        internal Registrar(Dictionary<RegistryKey, T> registry, string ownerMod)
        {
            OwnerMod = ownerMod;
            Registry = registry;
        }

        public void Register(string name, T value)
        {
            var key = new RegistryKey(OwnerMod, name);
            value.Key = key;
            OnRegister?.Invoke(key, value);
            Registry[key] = value;
        }
    }
}
