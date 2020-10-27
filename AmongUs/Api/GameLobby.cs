using System;

namespace AmongUs.Api {
	public static class GameLobby
	{
		public static event Action<IGameLobby> LobbyLoadEvent;
		public static event Action<IGameLobby, float?> SetStartCounterEventPost;
		public static event Action<IGameLobby, float?> SetStartCounterEventPre;
		public static event Action<IGameLobby> UpdateEvent;
		public static event Action<IGameLobby> MakePublicEvent;
		/// <summary>
		/// Called when the game tries the start. EX: Start button is pressed
		/// </summary>
		public static event Action<IGameLobby> TryStartEvent;
		/// <summary>
		/// Called when the game tries the start while meeting player requirements.
		/// </summary>
		public static event Action<IGameLobby, bool> GameStartingEvent;

		
		//"Load", this is when the lobby loads, not when the game starts
		public static void Start(IGameLobby manager) => LobbyLoadEvent?.Invoke(manager);
		
		public static void SetStartCounterPost(IGameLobby manager, float seconds) => SetStartCounterEventPost?.Invoke(manager, seconds);
		
		public static void SetStartCounterPre(IGameLobby manager, float seconds) => SetStartCounterEventPre?.Invoke(manager, seconds);

		public static void Update(IGameLobby manager) => UpdateEvent?.Invoke(manager);
		
		public static void MakePublic(IGameLobby manager) => MakePublicEvent?.Invoke(manager);

		public static void TryStart(IGameLobby manager) => TryStartEvent?.Invoke(manager);

		public static void GameStarting(IGameLobby manager, bool neverShow) => GameStartingEvent?.Invoke(manager, neverShow);
	}

	public interface IGameLobby 
	{
		float CountDownTimer { get; set; }
		int MinPlayers { get; set; }
		int LastPlayerCount { get; set; }
		StartingState StartState { get; set; }
		string GameStartText { get; set; }
		string GameRoomName { get; set; }
		string PlayerCounter { get; set; }
		void ResetStartState();
	}

	public enum StartingState {
		NotStarting,
		Countdown,
		Starting
	}
}
