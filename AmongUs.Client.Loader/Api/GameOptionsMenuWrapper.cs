using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{

	public readonly struct GameOptionsMenuWrapper : ILobbyMenu
	{
		private HHIDNOMFFGN Original { get; }

		public ILobbyOptions CachedData
		{
			get => new GameOptionsDataWrapper(Original.BIAIHNECBFM);
			set => TransferData(value);
		}

		private void TransferData(ILobbyOptions options)
		{
			var data = Original.BIAIHNECBFM;
			data.KDOKPOJFEKB = options.KillCooldown;
			//Continue adding each variable set here?
		}

		public GameOptionsMenuWrapper(HHIDNOMFFGN original) => Original = original;
	}
}
