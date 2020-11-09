using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
    public struct PlayerVoteStateWrapper : IPlayerVoteState
    {
        private LJEHDCNEKBG _original;
        
        public string Name
        {
            get => _original.NameText.Text;
            set => _original.NameText.Text = value;
        }

        public bool IsDead { get; set; }
        public bool Voted { get; set; }
        public bool Reported { get; set; }
        public bool VotingFinished { get; set; }

        public PlayerVoteStateWrapper(LJEHDCNEKBG original) : this() => _original = original;
    }
}