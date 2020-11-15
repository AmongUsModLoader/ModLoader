using AmongUs.Api;

namespace AmongUs.Client.Api
{
	public readonly struct GameOptionsMenuWrapper : ILobbyMenu
	{
		private readonly HHIDNOMFFGN _original;

		public ILobbyOptions CachedData
		{
			get => new GameOptionsDataWrapper(_original.BIAIHNECBFM);
			set => TransferData(value);
		}

		private void TransferData(ILobbyOptions options)
		{
			var data = _original.BIAIHNECBFM;
			data.KDOKPOJFEKB = options.KillCooldown;
			//Continue adding each variable set here?
		}

		public GameOptionsMenuWrapper(HHIDNOMFFGN original) => _original = original;
	}
}
