using BepInEx.Logging;

namespace AmongUs.ModLoader
{
    public abstract class Mod
    {
        public string ID { get; }
        public string Name { get; }
        public string Version { get; }

        public ManualLogSource Log;
        
        public Mod(string id, string name, string version)
        {
            ID = id;
            Name = name;
            Version = version;
            Log = Logger.CreateLogSource(Name);
        }

        public abstract void Load();
        public virtual bool Unload() => false;
    }
}
