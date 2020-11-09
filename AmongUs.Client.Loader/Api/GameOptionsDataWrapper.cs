using System.Text;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
	public readonly struct GameOptionsDataWrapper : ILobbyOptions
	{

		private OEFJGMAEENB Original { get; }

		public int MaxPlayers
		{
			get => Original.PCKBBJFMMFL;
			set => Original.PCKBBJFMMFL = value;
		}

		public GameMap Map
		{
			get => ModLoaderPlugin.MapTypes[(DAFPFFMKPJJ.DFCBBBIBKKC) Original.HGMAKPLFANN];
			set => Original.HGMAKPLFANN = (byte) ModLoaderPlugin.ReverseMapTypes[value];
		}

		public float PlayerSpeed
		{
			get => Original.LOHPLKGPFNA;
			set => Original.LOHPLKGPFNA = value;
		}

		public float CrewMateVision
		{
			get => Original.FNLABFPPJJM;
			set => Original.FNLABFPPJJM = value;
		}

		public float ImpostorVision
		{
			get => Original.PJEHIKCGHMD;
			set => Original.PJEHIKCGHMD = value;
		}

		public float KillCooldown
		{
			get => Original.KDOKPOJFEKB;
			set => Original.KDOKPOJFEKB = value;
		}

		public int CommonTasks
		{
			get => Original.OAHKBIHPHGB;
			set => Original.OAHKBIHPHGB = value;
		}

		public int LongTasks
		{
			get => Original.LGBIDHFOBCA;
			set => Original.LGBIDHFOBCA = value;
		}

		public int ShortTasks
		{
			get => Original.LPJNEJIIFNB;
			set => Original.LPJNEJIIFNB = value;
		}

		public int EmergencyMeetingsAllowed
		{
			get => Original.BLCAKAJBHLC;
			set => Original.BLCAKAJBHLC = value;
		}

		public int EmergencyMeetingCooldown
		{
			get => Original.LIFCGGNFEML;
			set => Original.LIFCGGNFEML = value;
		}

		public int ImpostorCount
		{
			get => Original.FIEIHPHGJPL;
			set => Original.FIEIHPHGJPL = value;
		}

		public bool GhostsDoTasks
		{
			get => Original.KPMMNAPPMLK;
			set => Original.KPMMNAPPMLK = value;
		}

		public int KillDistance
		{
			get => Original.CCIEDBPKKMP;
			set => Original.CCIEDBPKKMP = value;
		}

		public int DiscussionTime
		{
			get => Original.PHKOBAMEEGK;
			set => Original.PHKOBAMEEGK = value;
		}

		public int VotingTime
		{
			get => Original.FAGPOFNMCPK;
			set => Original.FAGPOFNMCPK = value;
		}

		public bool ConfirmImpostor
		{
			get => Original.JFAKHFFMHIO;
			set => Original.JFAKHFFMHIO = value;
		}

		public bool VisualTasks
		{
			get => Original.GMJFJNNICHC;
			set => Original.GMJFJNNICHC = value;
		}

		public bool AnonymousVotes
		{
			get => Original.IAFJLBELLDA;
			set => Original.IAFJLBELLDA = value;
		}

		public TaskBarUpdates TaskBarUpdates
		{
			get => (TaskBarUpdates) Original.BNIJDCGPMKO;
			set => Original.BNIJDCGPMKO = (BNIJDCGPMKO) value;
		}

		public bool IsDefaults
		{
			get => Original.LPMMFCBBPBH;
			set => Original.LPMMFCBBPBH = value;
		}

		public string Settings
		{
			get => Original.EJGNHIIMKJO.ToString();
			set => Original.EJGNHIIMKJO = new Il2CppSystem.Text.StringBuilder(value);
		}

		public GameOptionsDataWrapper(OEFJGMAEENB original) => Original = original;
	}
}
