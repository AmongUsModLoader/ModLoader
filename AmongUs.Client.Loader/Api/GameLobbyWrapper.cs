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

		public int MinPlayers
		{
			get => Original.MinPlayers;
			set => Original.MinPlayers = value;
		}

		public int LastPlayerCount
		{
			get => Original.OHFFOOPPAFK;
			set => Original.OHFFOOPPAFK = value;
		}

		public StartingState StartState
		{
			get => (StartingState) Original.FEFLPKBHACE;
			set => Original.FEFLPKBHACE = (GameStartManager.PNMJGJHIGIN) value;
		}

		public string GameStartText
		{
			get => Original.GameStartText.Text;
			set => Original.GameStartText.Text = value;
		}

		public string GameRoomName
		{
			get => Original.GameRoomName.Text;
			set => Original.GameRoomName.Text = value;
		}

		public string PlayerCounter
		{
			get => Original.PlayerCounter.Text;
			set => Original.PlayerCounter.Text = value;
		}

		public void ResetStartState()
		{
			Original.ResetStartState();
		}

		public GameLobbyWrapper(GameStartManager original) => Original = original;
	}
}
