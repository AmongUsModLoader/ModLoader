using AmongUs.Api;
using Il2CppSystem.Text;

namespace AmongUs.Client.Api
{
	public readonly struct GameOptionsDataWrapper : ILobbyOptions
	{

		private readonly OEFJGMAEENB _original;

		public int MaxPlayers
		{
			get => _original.PCKBBJFMMFL;
			set => _original.PCKBBJFMMFL = value;
		}

		public GameMap Map
		{
			get => ModLoaderPlugin.MapTypes[(DAFPFFMKPJJ.DFCBBBIBKKC) _original.HGMAKPLFANN];
			set => _original.HGMAKPLFANN = (byte) ModLoaderPlugin.ReverseMapTypes[value];
		}

		public float PlayerSpeed
		{
			get => _original.LOHPLKGPFNA;
			set => _original.LOHPLKGPFNA = value;
		}

		public float CrewMateVision
		{
			get => _original.FNLABFPPJJM;
			set => _original.FNLABFPPJJM = value;
		}

		public float ImpostorVision
		{
			get => _original.PJEHIKCGHMD;
			set => _original.PJEHIKCGHMD = value;
		}

		public float KillCooldown
		{
			get => _original.KDOKPOJFEKB;
			set => _original.KDOKPOJFEKB = value;
		}

		public int CommonTasks
		{
			get => _original.OAHKBIHPHGB;
			set => _original.OAHKBIHPHGB = value;
		}

		public int LongTasks
		{
			get => _original.LGBIDHFOBCA;
			set => _original.LGBIDHFOBCA = value;
		}

		public int ShortTasks
		{
			get => _original.LPJNEJIIFNB;
			set => _original.LPJNEJIIFNB = value;
		}

		public int EmergencyMeetingsAllowed
		{
			get => _original.BLCAKAJBHLC;
			set => _original.BLCAKAJBHLC = value;
		}

		public int EmergencyMeetingCooldown
		{
			get => _original.LIFCGGNFEML;
			set => _original.LIFCGGNFEML = value;
		}

		public int ImpostorCount
		{
			get => _original.FIEIHPHGJPL;
			set => _original.FIEIHPHGJPL = value;
		}

		public bool GhostsDoTasks
		{
			get => _original.KPMMNAPPMLK;
			set => _original.KPMMNAPPMLK = value;
		}

		public int KillDistance
		{
			get => _original.CCIEDBPKKMP;
			set => _original.CCIEDBPKKMP = value;
		}

		public int DiscussionTime
		{
			get => _original.PHKOBAMEEGK;
			set => _original.PHKOBAMEEGK = value;
		}

		public int VotingTime
		{
			get => _original.FAGPOFNMCPK;
			set => _original.FAGPOFNMCPK = value;
		}

		public bool ConfirmImpostor
		{
			get => _original.JFAKHFFMHIO;
			set => _original.JFAKHFFMHIO = value;
		}

		public bool VisualTasks
		{
			get => _original.GMJFJNNICHC;
			set => _original.GMJFJNNICHC = value;
		}

		public bool AnonymousVotes
		{
			get => _original.IAFJLBELLDA;
			set => _original.IAFJLBELLDA = value;
		}

		public TaskBarUpdates TaskBarUpdates
		{
			get => (TaskBarUpdates) _original.BNIJDCGPMKO;
			set => _original.BNIJDCGPMKO = (BNIJDCGPMKO) value;
		}

		public bool IsDefaults
		{
			get => _original.LPMMFCBBPBH;
			set => _original.LPMMFCBBPBH = value;
		}

		public string Settings
		{
			get => _original.EJGNHIIMKJO.ToString();
			set => _original.EJGNHIIMKJO = new StringBuilder(value);
		}

		public GameOptionsDataWrapper(OEFJGMAEENB original) => _original = original;
	}
}
