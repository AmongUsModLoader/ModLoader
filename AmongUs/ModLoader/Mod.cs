namespace AmongUs.ModLoader
{
    public abstract class Mod
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

        public abstract void Load();
        public virtual bool Unload() => false;
    }
}
