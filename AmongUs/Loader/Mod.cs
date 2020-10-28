using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AmongUs.Api;
using AmongUs.Api.Registry;

namespace AmongUs.Loader
{
    public abstract class Mod
    {
        public string ID { get; }
        public string Name { get; }
        public string Version { get; }
        public string[] Authors { get; protected set; }
        public string Description { get; protected set; }

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
        private Assembly _assembly;

        internal Dictionary<string, Dictionary<string, string>> LanguageKeys { get; } = new Dictionary<string, Dictionary<string, string>>();

        private readonly Dictionary<string, string> _resourceCache = new Dictionary<string, string>();
        private readonly HashSet<string> _unknownResources = new HashSet<string>();
        private Dictionary<string, string> _resourceNames;

        public Mod(string id, string name, string version)
        {
            ID = id;
            Name = name;
            Version = version;
            Log = Logger.Create(name);
        }

        public abstract void Load(RegistrarProvider registrar);
        public virtual bool Unload() => false;

        internal async Task SetUnderlyingAssembly(Assembly assembly)
        {
            _assembly = assembly;
            _resourceNames = assembly.GetManifestResourceNames().ToDictionary(source => source.Substring(source.IndexOf(".", StringComparison.Ordinal) + 1));
            
            var language = 
                from resource in _resourceNames.Keys where resource.StartsWith("Resources.Language.")
                let name = resource.Replace("Resources.Language.", "").Replace(".txt", "")
                select (name, GetResource("Language/" + name + ".txt"));

            foreach (var (key, stream) in language)
            {
                var dictionary = new Dictionary<string, string>();
                using (var reader = new StreamReader(stream))
                {
                    foreach (var languageKey in (await reader.ReadToEndAsync()).Split('\n'))
                    {
                        var pair = languageKey.Split('=');
                        if (pair.Length >= 2)
                        {
                            dictionary[pair[0]] = pair[1];
                        }
                    }

                    LanguageKeys[key] = dictionary;
                }
            }
        }

        public Stream GetResource(string name)
        {
            if (name == null) return null;
            if (_resourceCache.ContainsKey(name)) return _assembly.GetManifestResourceStream(_resourceCache[name]);
            if (_unknownResources.Contains(name)) return null;

            var key = "Resources." + name.Replace("/", ".");
            var resourceName = _resourceNames.ContainsKey(key) ? _resourceNames[key] : null;
            
            if (resourceName == null) _unknownResources.Add(name);
            else _resourceCache[name] = resourceName;
            
            return resourceName == null ? null : _assembly.GetManifestResourceStream(resourceName);
        }
    }
}
