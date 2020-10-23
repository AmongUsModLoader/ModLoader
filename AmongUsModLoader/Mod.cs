using System;

namespace AmongUsMod.Loader
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Mod : Attribute
    {
        public string ID { get; }
        public string Name { get; }
        public string Version { get; }

        public Mod(string id, string name, string version)
        {
            ID = id;
            Name = name;
            Version = version;
        }
    }
}
