using System;
using AmongUs.Api;

namespace AmongUs.Loader
{
    public abstract class Mod
    {
        public string ID { get; }
        public string Name { get; }
        public string Version { get; }

        public bool ClientRequires
        {
            get => _clientRequires;
            protected set
            {
                switch (Side)
                {
                    case ModSide.Server when value:
                        throw new ArgumentException("Can't enable ClientRequires when Side == ModSide.Server");
                    case ModSide.Client when !value:
                        throw new ArgumentException("Can't disable ClientRequires when Side == ModSide.Client");
                }
                _clientRequires = value;
            }
        }

        public ModSide Side
        {
            get => _side;
            protected set
            {
                switch (value)
                {
                    case ModSide.Client:
                        ClientRequires = true;
                        break;
                    case ModSide.Server when ClientRequires:
                        throw new ArgumentException("Can't set Side to ModSide.Server when ClientRequires is true. (Use ModSide.Common)");
                }
                _side = value;
            }
        }

        public ILogger Log { get; }
        
        private bool _clientRequires;
        private ModSide _side;

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
