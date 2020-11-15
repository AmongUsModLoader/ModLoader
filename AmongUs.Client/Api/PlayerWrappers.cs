using System.Collections.Generic;
using AmongUs.Api;

namespace AmongUs.Client.Api
{
    public readonly struct PlayerWrapper : IPlayer
    {
        private readonly GLHCHLEDNBA _original;

        public byte Id => _original.PlayerId;

        public float MaxReportDistance
        {
            get => _original.MaxReportDistance;
            set => _original.MaxReportDistance = value;
        }

        public bool CanMove
        {
            get => _original.moveable;
            set => _original.moveable = value;
        }

        public bool InVent => _original.inVent;

        public bool Infected
        {
            get => _original.NKFIIJPHEHI;
            set => _original.NKFIIJPHEHI = value;
        }

        public Color Color
        {
            get => (Color) _original.NPIGFGMGAAH.LMDCNHODEAN;
            set => _original.NPIGFGMGAAH.LMDCNHODEAN = (byte) value;
        }

        public bool Disconnected => _original.NPIGFGMGAAH.DDFPAALELOA;

        public bool IsImpostor
        {
            get => _original.NPIGFGMGAAH.FDFFLCMBLKN;
            set => _original.NPIGFGMGAAH.FDFFLCMBLKN = value;
        }

        public bool IsDead
        {
            get => _original.NPIGFGMGAAH.ENDDMNCPFHM;
            set => _original.NPIGFGMGAAH.ENDDMNCPFHM = value;
        }

        public bool Visible
        {
            get => _original.MFFCEJPIOOP;
            set => _original.MFFCEJPIOOP = value;
        }

        public float KillCooldown
        {
            get => _original.killTimer;
            set => _original.killTimer = value;
        }

        public int RemainingEmergencies
        {
            get => _original.RemainingEmergencies;
            set => _original.RemainingEmergencies = value;
        }

        public string Name
        {
            get => _original.nameText.Text;
            set => _original.nameText.Text = value;
        }

        public List<ITask> Tasks
        {
            get
            {
                var list = new List<ITask>();
                foreach (var originalTask in _original.myTasks)
                {
                    list.Add(new TaskWrapper(originalTask));
                }

                return list;
            }
        }

        //public IUsable Closest { get; set; }
        //public List<IUsable> InRange { get; }

        public PlayerWrapper(GLHCHLEDNBA original) : this() => _original = original;
    }
}
