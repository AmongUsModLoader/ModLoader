using AmongUs.Api;
using UnityEngine;

namespace AmongUs.Client.Api
{
    public readonly struct PlayerVoteStateWrapper : IPlayerVoteState
    {
        private readonly LJEHDCNEKBG _original;
        
        public string Name
        {
            get => _original.NameText.Text;
            set => _original.NameText.Text = value;
        }

        public Vector3 Position
        {
            get => _original.transform.localPosition;
            set => _original.transform.localPosition = value;
        }

        public bool IsEnabled
        {
            get => _original.gameObject.activeSelf;
            set => _original.gameObject.SetActive(value);
        }

        public bool IsDead
        {
            get => _original.isDead;
            set => _original.isDead = value;
        }

        public bool Voted
        {
            get => _original.didVote;
            set => _original.didVote = value;
        }

        public bool Reported
        {
            get => _original.didReport;
            set => _original.didReport = value;
        }

        public bool VotingFinished
        {
            get => _original.voteComplete && _original.resultsShowing;
            set => _original.voteComplete = _original.resultsShowing = value;
        }

        public PlayerVoteStateWrapper(LJEHDCNEKBG original) : this() => _original = original;
    }
}