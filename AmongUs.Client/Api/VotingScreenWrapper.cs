using AmongUs.Api;
using UnityEngine;

namespace AmongUs.Client.Api
{
    public readonly struct VotingScreenWrapper : IVotingScreen
    {
        private readonly GPOHFPAIEMA _original;

        public string TitleText
        {
            get => _original.TitleText.Text;
            set => _original.TitleText.Text = value;
        }
        
        public Vector3 VotePosition
        {
            get => _original.VoteOrigin;
            set => _original.VoteOrigin = value;
        }

        public Vector3 VoteButtonSize
        {
            get =>_original.VoteButtonOffsets;
            set => _original.VoteButtonOffsets = value;
        }

        public IPlayerVoteState SkipVoteButton => new PlayerVoteStateWrapper(_original.SkipVoteButton);

        public IPlayerVoteState[] PlayerStates
        {
            get
            {
                var oldArray = _original.OMJGIAMFODK;
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
            get => _original.GBOFEFNNKCF;
            set => _original.GBOFEFNNKCF = value;
        }

        public string TimerText
        {
            get => _original.TimerText.Text;
            set => _original.TimerText.Text = value;
        }

        public float DiscussionTime
        {
            get => _original.discussionTimer;
            set => _original.discussionTimer = value;
        }

        public VotingScreenWrapper(GPOHFPAIEMA original) => _original = original;
    }
}
