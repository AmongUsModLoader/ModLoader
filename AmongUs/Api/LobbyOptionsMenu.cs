namespace AmongUs.Api
{
	//GameOptionsMenu
	public class LobbyOptionsMenu
	{
		public interface ILobbyMenu
		{

			//This name makes no sense but idk what else it should be
			LobbyOptions.ILobbyOptions CachedData { get; set; }
		}
	}
}
