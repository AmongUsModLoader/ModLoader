using System.Collections.Generic;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
    public readonly struct PlayerWrapper : IPlayer
    {
        private GLHCHLEDNBA Original { get; }

        public byte Id => Original.PlayerId;

        public float MaxReportDistance
        {
            get => Original.MaxReportDistance;
            set => Original.MaxReportDistance = value;
        }

        public bool CanMove
        {
            get => Original.moveable;
            set => Original.moveable = value;
        }

        public bool InVent => Original.inVent;

        public bool Infected
        {
            get => Original.NKFIIJPHEHI;
            set => Original.NKFIIJPHEHI = value;
        }

        public Color Color
        {
            get => (Color) Original.NPIGFGMGAAH.LMDCNHODEAN;
            set => Original.NPIGFGMGAAH.LMDCNHODEAN = (byte) value;
        }

        public bool Disconnected => Original.NPIGFGMGAAH.DDFPAALELOA;

        public bool IsImpostor
        {
            get => Original.NPIGFGMGAAH.FDFFLCMBLKN;
            set => Original.NPIGFGMGAAH.FDFFLCMBLKN = value;
        }

        public bool IsDead
        {
            get => Original.NPIGFGMGAAH.ENDDMNCPFHM;
            set => Original.NPIGFGMGAAH.ENDDMNCPFHM = value;
        }

        public bool Visible
        {
            get => Original.MFFCEJPIOOP;
            set => Original.MFFCEJPIOOP = value;
        }

        public float KillCooldown
        {
            get => Original.killTimer;
            set => Original.killTimer = value;
        }

        public int RemainingEmergencies
        {
            get => Original.RemainingEmergencies;
            set => Original.RemainingEmergencies = value;
        }

        public string Name
        {
            get => Original.nameText.Text;
            set => Original.nameText.Text = value;
        }

        public List<ITask> Tasks
        {
            get
            {
                var list = new List<ITask>();
                foreach (var originalTask in Original.myTasks)
                {
                    list.Add(new TaskWrapper(originalTask));
                }

                return list;
            }
        }

        //public IUsable Closest { get; set; }
        //public List<IUsable> InRange { get; }

        public PlayerWrapper(GLHCHLEDNBA original) : this() => Original = original;
    }
}
