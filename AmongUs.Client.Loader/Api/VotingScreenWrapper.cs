using System.Numerics;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
    public readonly struct VotingScreenWrapper : IVotingScreen
    {
        private GPOHFPAIEMA Original { get; }

        public string TitleText
        {
            get => Original.TitleText.Text;
            set => Original.TitleText.Text = value;
        }

        public Vector3 TimerPosition
        {
            get
            {
                var origin = Original.GOCOEAPLJFA;
                return new Vector3(origin.x, origin.y, origin.z);
            }
            set => Original.GOCOEAPLJFA = new UnityEngine.Vector3(value.X, value.Y, value.Z);
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

        public IPlayerVoteState SkipVoteButton => new PlayerVoteStateWrapper(Original.SkipVoteButton);

        public IPlayerVoteState[] PlayerStates
        {
            get
            {
                var oldArray = Original.OMJGIAMFODK;
                var newArray = new IPlayerVoteState[oldArray.Count];
                for (var index = 0; index < oldArray.Count; index++)
                {
                    newArray[index] = new PlayerVoteStateWrapper(oldArray[index]);
                }
                return newArray;
            }
        }

        //public GameData.IHEKEPMDGIJ ExiledPlayer { get; set; }

        public bool Tied
        {
            get => Original.GBOFEFNNKCF;
            set => Original.GBOFEFNNKCF = value;
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

        public VotingScreenWrapper(GPOHFPAIEMA original) => Original = original;
    }
}
