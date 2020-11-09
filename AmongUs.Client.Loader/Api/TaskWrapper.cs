using System.Numerics;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
    public readonly struct TaskWrapper : ITask
    {
        private LOBBAHDOFGE Original { get; }

        public TaskType Type => ModLoaderPlugin.TaskTypes[(CANPENMJFOD) Original.MKFDJEJIEGJ];
        public IPlayer Owner => new PlayerWrapper(Original.CFBCBHOILJD);
        public int TaskStep => Original.NNNHNNLJDLF;
        public bool IsComplete => Original.FFGBCJGMHKJ;
        public Vector2 Location => new Vector2(Original.CDECNIIHCAL.x, Original.CDECNIIHCAL.y);

        public TaskWrapper(LOBBAHDOFGE original) : this() => Original = original;
    }
}
