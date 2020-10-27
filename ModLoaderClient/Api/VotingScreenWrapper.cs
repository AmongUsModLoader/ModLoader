using System.Numerics;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
    public readonly struct VotingScreenWrapper : IVotingScreen
    {
        private MeetingHud Original { get; }

        public string TitleText
        {
            get => Original.TitleText.Text;
            set => Original.TitleText.Text = value;
        }

        public Vector3 TimerPosition
        {
            get
            {
                var origin = Original.BEDJEPCINAI;
                return new Vector3(origin.x, origin.y, origin.z);
            }
            set => Original.BEDJEPCINAI = new UnityEngine.Vector3(value.X, value.Y, value.Z);
        }

        public Vector3 VotePosition
        {
            get
            {
                var origin = Original.VoteOrigin;
                return new Vector3(origin.x, origin.y, origin.z);
            }
            set => Original.VoteOrigin = new UnityEngine.Vector3(value.X, value.Y, value.Z);
        }

        public Vector3 VoteButtonSize
        {
            get
            {
                var origin = Original.VoteButtonOffsets;
                return new Vector3(origin.x, origin.y, origin.z);
            }
            set => Original.VoteButtonOffsets = new UnityEngine.Vector3(value.X, value.Y, value.Z);
        }

        public PlayerVoteArea SkipVoteButton
        {
            get => Original.SkipVoteButton;
            set => Original.SkipVoteButton = value;
        }

        public PlayerVoteArea[] PlayerStates
        {
            get => Original.FALDLDJHDDJ;
            set => Original.FALDLDJHDDJ = PlayerStates;
        }

        //public GameData.IHEKEPMDGIJ ExiledPlayer { get; set; }

        public bool Tied
        {
            get => Original.CEIGAJCFLEM;
            set => Original.CEIGAJCFLEM = value;
        }

        public string TimerText
        {
            get => Original.TimerText.Text;
            set => Original.TimerText.Text = value;
        }

        public float DiscussionTime
        {
            get => Original.discussionTimer;
            set => Original.discussionTimer = value;
        }

        public VotingScreenWrapper(MeetingHud original) => Original = original;
    }
}
