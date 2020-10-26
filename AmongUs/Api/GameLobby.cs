using System;

namespace AmongUs.Api {
	public static class GameLobby
	{
		public static event Action<GameStartManager> LobbyLoadEvent;
		public static event Action<GameStartManager, float?> SetStartCounterEventPost;
		public static event Action<GameStartManager, float?> SetStartCounterEventPre;
		public static event Action<GameStartManager> UpdateEvent;
		public static event Action<GameStartManager> MakePublicEvent;
		/// <summary>
		/// Called when the game tries the start. EX: Start button is pressed
		/// </summary>
		public static event Action<GameStartManager> TryStartEvent;
		/// <summary>
		/// Called when the game tries the start while meeting player requirements.
		/// </summary>
		public static event Action<GameStartManager, bool> GameStartingEvent;


		//"Load", this is when the lobby loads, not when the game starts
		public static void Start(GameStartManager manager) => LobbyLoadEvent?.Invoke(manager);
		
		public static void SetStartCounterPost(GameStartManager manager, float value) => SetStartCounterEventPost?.Invoke(manager, value);
		
		public static void SetStartCounterPre(GameStartManager manager, float value) => SetStartCounterEventPre?.Invoke(manager, value);

		public static void Update(GameStartManager manager) => UpdateEvent?.Invoke(manager);
		
		public static void MakePublic(GameStartManager manager) => MakePublicEvent?.Invoke(manager);

		public static void TryStart(GameStartManager manager) => TryStartEvent?.Invoke(manager);

		public static void GameStarting(GameStartManager manager, bool b) => GameStartingEvent?.Invoke(manager, b);

	}
}
