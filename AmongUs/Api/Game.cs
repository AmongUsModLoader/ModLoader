using System;

namespace AmongUs.Api {
	public static class Game
	{
		public static event Action<GameStartManager> StartEvent;

		public static void Start(GameStartManager manager) => StartEvent?.Invoke(manager);
	}
}
