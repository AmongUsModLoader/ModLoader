using System.Collections.Generic;

namespace AmongUs.Api.Registry
{
    public readonly struct RegistrarProvider
    {
        private string OwnerMod { get; }

        internal RegistrarProvider(string ownerMod) => OwnerMod = ownerMod;

        public Registrar<T> GetRegistrar<T>(Dictionary<RegistryKey, T> registry) where T : RegistryObject => new Registrar<T>(registry, OwnerMod);
    }
}
