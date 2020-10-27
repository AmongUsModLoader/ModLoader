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
		
		public static void SetStartCounterPost(IGameLobby manager, float value) => SetStartCounterEventPost?.Invoke(manager, value);
		
		public static void SetStartCounterPre(IGameLobby manager, float value) => SetStartCounterEventPre?.Invoke(manager, value);

		public static void Update(IGameLobby manager) => UpdateEvent?.Invoke(manager);
		
		public static void MakePublic(IGameLobby manager) => MakePublicEvent?.Invoke(manager);

		public static void TryStart(IGameLobby manager) => TryStartEvent?.Invoke(manager);

		public static void GameStarting(IGameLobby manager, bool b) => GameStartingEvent?.Invoke(manager, b);
	}

	public interface IGameLobby 
	{
		float CountDownTimer { get; set; }
	}
}
