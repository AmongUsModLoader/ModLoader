using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{

	public readonly struct GameOptionsMenuWrapper : ILobbyMenu
	{
		private GameOptionsMenu Original { get; }

		public ILobbyOptions CachedData
		{
			get => new GameOptionsDataWrapper(Original.EKMHEKKICFL);
			set => TransferData(value);
		}

		private void TransferData(ILobbyOptions options)
		{
			var data = Original.EKMHEKKICFL;
			data.HNEKLLKCJOJ = options.KillCooldown;
			//Continue adding each variable set here?
		}

		public GameOptionsMenuWrapper(GameOptionsMenu original) => Original = original;
	}
}
