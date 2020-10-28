using System.Text;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
	public readonly struct GameOptionsDataWrapper : LobbyOptions.ILobbyOptions
	{

		private OPIJAMILNFD Original { get; }

		public int MaxPlayers
		{
			get => Original.ALGKPIECFPC;
			set => Original.ALGKPIECFPC = value;
		}

		public byte MapId
		{
			get => Original.BFOCEACJOPK;
			set => Original.BFOCEACJOPK = value;
		}

		public float PlayerSpeedMod
		{
			get => Original.DAJDLEBMBMB;
			set => Original.DAJDLEBMBMB = value;
		}

		public float CrewLightMod
		{
			get => Original.LNKCMDOCNBI;
			set => Original.LNKCMDOCNBI = value;
		}

		public float ImposterLightMod
		{
			get => Original.NFAOBDJKOPH;
			set => Original.NFAOBDJKOPH = value;
		}

		public float KillCooldown
		{
			get => Original.HNEKLLKCJOJ;
			set => Original.HNEKLLKCJOJ = value;
		}

		public int NumCommonTasks
		{
			get => Original.LNNGPNHGGDN;
			set => Original.LNNGPNHGGDN = value;
		}

		public int NumLongTasks
		{
			get => Original.FFJKPGELKGD;
			set => Original.FFJKPGELKGD = value;
		}

		public int NumShortTasks
		{
			get => Original.OJLANPDBDGG;
			set => Original.OJLANPDBDGG = value;
		}

		public int NumEmergencyMeetings
		{
			get => Original.OEBNJBBLHBD;
			set => Original.OEBNJBBLHBD = value;
		}

		public int NumImpostors
		{
			get => Original.MAONBFOOEPK;
			set => Original.MAONBFOOEPK = value;
		}

		public bool GhostsDoTasks
		{
			get => Original.NNEENFHINBO;
			set => Original.NNEENFHINBO = value;
		}

		public int KillDistance
		{
			get => Original.MCHMMCDKECO;
			set => Original.MCHMMCDKECO = value;
		}

		public int DiscussionTime
		{
			get => Original.IECOKEIAEEE;
			set => Original.IECOKEIAEEE = value;
		}

		public int VotingTime
		{
			get => Original.MMJKMHKEAPI;
			set => Original.MMJKMHKEAPI = value;
		}

		public bool ConfirmImpostor
		{
			get => Original.BELGPJKBKGA;
			set => Original.BELGPJKBKGA = value;
		}

		public bool VisualTasks
		{
			get => Original.KPFLIHLKEBI;
			set => Original.KPFLIHLKEBI = value;
		}

		public bool IsDefaults
		{
			get => Original.MEIOIAOIBOH;
			set => Original.MEIOIAOIBOH = value;
		}

		public StringBuilder Settings
		{
			get => new StringBuilder(Original.PFPGEKOLAJA.ToString());
			set => Original.PFPGEKOLAJA = new Il2CppSystem.Text.StringBuilder(value.ToString());
		}

		public GameOptionsDataWrapper(OPIJAMILNFD original) => Original = original;
	}
}