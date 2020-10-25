using AmongUs.Api;

namespace AmongUs.Loader
{
    public abstract class Mod
    {
        public string ID { get; }
        public string Name { get; }
        public string Version { get; }

        public readonly ILogger Log;
        
        public Mod(string id, string name, string version)
        {
            ID = id;
            Name = name;
            Version = version;
            Log = Logger.Create(name);
        }

        public abstract void Load();
        public virtual bool Unload() => false;
    }
}
