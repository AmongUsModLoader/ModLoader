using AmongUs.Api;

namespace AmongUs.Client.Api
{
    public readonly struct UsableWrapper : IUsable
    {
        private readonly OLGLOPCGHPC _original;
        
        public float UsableDistance => _original.MEJHNCFLPBP;

        public UsableWrapper(OLGLOPCGHPC original) => _original = original;

        public void SetOutline(bool on, bool mainTarget) => _original.SetOutline(on, mainTarget);

        //public float CanUse(IPlayer player, out bool canUse, out bool couldUse) => _original.CanUse(player, canUse, couldUse);

        public void Use() => _original.Use();
    }
}
