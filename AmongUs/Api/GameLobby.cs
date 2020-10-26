using System;

namespace AmongUs.Api {
	public static class GameLobby
	{
		public static event Action<GameStartManager> StartEvent;
		public static event Action<GameStartManager, float?> SetStartCounterEventPost;
		public static event Action<GameStartManager, float?> SetStartCounterEventPre;
		public static event Action<GameStartManager> UpdateEvent;
		public static event Action<GameStartManager> MakePublicEvent;

		public static void Start(GameStartManager manager) => StartEvent?.Invoke(manager);
		
		public static void SetStartCounterPost(GameStartManager manager, float value) => SetStartCounterEventPost?.Invoke(manager, value);
		
		public static void SetStartCounterPre(GameStartManager manager, float value) => SetStartCounterEventPre?.Invoke(manager, value);

		public static void Update(GameStartManager manager) => UpdateEvent?.Invoke(manager);
		
		public static void MakePublic(GameStartManager manager) => MakePublicEvent?.Invoke(manager);

	}
}
