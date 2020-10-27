using AmongUs.Api;

namespace AmongUs.Client.Loader.Api 
{
	public readonly struct GameLobbyWrapper : IGameLobby 
	{
		private GameStartManager Original { get; }

		
		public float CountDownTimer 
		{
			get => Original.AKLOKGOIKHP;
			set => Original.AKLOKGOIKHP = value;
		}

		public int MinPlayers {
			get => Original.MinPlayers;
			set => Original.MinPlayers = value;
		}
		
		public int LastPlayerCount { 
			get => Original.OHFFOOPPAFK;
			set => Original.OHFFOOPPAFK = value;
		}

		public StartingState StartState {
			get => (StartingState)(int)Original.FEFLPKBHACE;
			set => Original.FEFLPKBHACE = (GameStartManager.PNMJGJHIGIN)value;
		}
		
		public GameLobbyWrapper(GameStartManager original) => Original = original;
	}
}