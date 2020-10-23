using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace AmongUsMod.Loader
{
    public static class Loader
    {
        public static readonly Dictionary<string, Mod> Mods = new Dictionary<string, Mod>();
        
        internal static void LoadMod(Assembly assembly)
        {
            foreach (var resource in assembly.GetManifestResourceNames())
            {
                var rm = new ResourceManager(resource, assembly);

                var set = rm.GetResourceSet(CultureInfo.CurrentCulture, false, false);
                if (set == null) continue;

                foreach (var mod in from DictionaryEntry entry in set 
                    let key = entry.Key.ToString()
                    let value = entry.Value?.ToString() 
                    where key == "Entry" && value != null 
                    select assembly.GetType(value)?.GetModAttribute() into mod 
                    where mod != null select mod)
                {
                    Mods[mod.ID] = mod;
                }
            }
        }
        
        private static Mod GetModAttribute(this ICustomAttributeProvider type)
        {
            if (type.GetCustomAttributes(typeof(Mod), true).FirstOrDefault() is Mod attribute)
            {
                return attribute;
            }

            return null;
        }
    }
}
