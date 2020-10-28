using System;

namespace AmongUs.Api.Registry
{
    public abstract class RegistryObject
    {
        private RegistryKey _key;

        public RegistryKey Key
        {
            get => _key;
            set
            {
                if (_key.IsValid) throw new InvalidOperationException($"Object {this} already has a registry key set; {_key}"); 
                _key = value;
            }
        }
    }
}
