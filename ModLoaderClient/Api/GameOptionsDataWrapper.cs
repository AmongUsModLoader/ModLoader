using AmongUs.Api;

namespace AmongUs.Client.Loader.Api {
	public readonly struct GameOptionsDataWrapper : LobbyOptions.ILobbyOptions{
		
		private OPIJAMILNFD Original { get; }

		public float KillCooldown {
			get => Original.HNEKLLKCJOJ;
			set => Original.HNEKLLKCJOJ = value;
		}
		
		public GameOptionsDataWrapper(OPIJAMILNFD original) => Original = original;
		
	}
}