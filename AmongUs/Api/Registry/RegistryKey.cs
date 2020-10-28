using System;

namespace AmongUs.Api.Registry
{
    public readonly struct RegistryKey : IEquatable<RegistryKey>
    {
        public string ModId { get; }
        public string Name { get; }

        public bool IsValid => ModId != null && Name != null;

        public RegistryKey(string modId, string name)
        {
            ModId = modId ?? throw new ArgumentNullException(nameof(modId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public bool Equals(RegistryKey other) => ModId == other.ModId && Name == other.Name;
        public override bool Equals(object obj) => obj is RegistryKey other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                return (ModId.GetHashCode() * 397) ^ Name.GetHashCode();
            }
        }

        public static bool operator ==(RegistryKey left, RegistryKey right) => left.Equals(right);
        public static bool operator !=(RegistryKey left, RegistryKey right) => !left.Equals(right);

        public override string ToString() => $"{nameof(ModId)}: {ModId}, {nameof(Name)}: {Name}";
    }
}
