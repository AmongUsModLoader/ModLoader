using System.Text;

namespace AmongUs.Api
{
	//For the GameOptionsData class
	public interface ILobbyOptions
	{
		int MaxPlayers { get; set; }
		byte MapId { get; set; }
		float PlayerSpeedMod { get; set; }
		float CrewLightMod { get; set; }
		float ImposterLightMod { get; set; }
		float KillCooldown { get; set; }
		int NumCommonTasks { get; set; }
		int NumLongTasks { get; set; }
		int NumShortTasks { get; set; }
		int NumEmergencyMeetings { get; set; }
		int NumImpostors { get; set; }
		bool GhostsDoTasks { get; set; }
		int KillDistance { get; set; }
		int DiscussionTime { get; set; }
		int VotingTime { get; set; }
		bool ConfirmImpostor { get; set; }
		bool VisualTasks { get; set; }
		bool IsDefaults { get; set; }
		StringBuilder Settings { get; set; }
	}
}
