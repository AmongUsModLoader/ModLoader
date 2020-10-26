using AmongUs.Loader.Internal;

namespace AmongUs.Api
{
    public class TaskType
    {
        public string Name { get; }
        
        public TaskType(string name)
        {
            Name = name;
            ApiWrapper.Instance.RegisterTask(this);
        }
    }
}
