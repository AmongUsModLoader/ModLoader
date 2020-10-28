using System.Collections.Generic;
using AmongUs.Api.Registry;

namespace AmongUs.Api
{
    public class TaskType : RegistryObject
    {
        public static readonly Dictionary<RegistryKey, TaskType> Registry = new Dictionary<RegistryKey, TaskType>();
    }
}
