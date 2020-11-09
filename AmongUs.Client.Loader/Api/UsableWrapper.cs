using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
    public readonly struct UsableWrapper : IUsable
    {
        private OLGLOPCGHPC Original { get; }
        
        public float UsableDistance => Original.MEJHNCFLPBP;

        public UsableWrapper(OLGLOPCGHPC original) => Original = original;

        public void SetOutline(bool on, bool mainTarget) => Original.SetOutline(on, mainTarget);

        //public float CanUse(IPlayer player, out bool canUse, out bool couldUse) => _original.CanUse(player, canUse, couldUse);

        public void Use() => Original.Use();
    }
}
