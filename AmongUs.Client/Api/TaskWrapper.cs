using System.Numerics;
using AmongUs.Api;

namespace AmongUs.Client.Api
{
    public readonly struct TaskWrapper : ITask
    {
        private readonly LOBBAHDOFGE _original;

        public TaskType Type => ModLoaderPlugin.TaskTypes[(CANPENMJFOD) _original.MKFDJEJIEGJ];
        public IPlayer Owner => new PlayerWrapper(_original.CFBCBHOILJD);
        public int TaskStep => _original.NNNHNNLJDLF;
        public bool IsComplete => _original.FFGBCJGMHKJ;
        public Vector2 Location => new Vector2(_original.CDECNIIHCAL.x, _original.CDECNIIHCAL.y);

        public TaskWrapper(LOBBAHDOFGE original) : this() => _original = original;
    }
}
