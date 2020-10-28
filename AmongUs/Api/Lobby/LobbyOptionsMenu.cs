namespace AmongUs.Api
{
	//GameOptionsMenu
	public static class LobbyOptionsMenu
	{
	}
	
	public interface ILobbyMenu
	{

		//This name makes no sense but idk what else it should be
		ILobbyOptions CachedData { get; set; }
	}
}
