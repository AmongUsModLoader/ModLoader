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
		
		public GameLobbyWrapper(GameStartManager og) => Original = og;
	}
}