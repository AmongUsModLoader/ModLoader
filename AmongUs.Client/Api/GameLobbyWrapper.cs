using System.Collections.Generic;
using AmongUs.Api;

namespace AmongUs.Client.Api
{
	public readonly struct GameLobbyWrapper : IGameLobby
	{
		private static readonly Dictionary<EDGCHOJDFNC, Dictionary<LobbyOption, LobbyOptionInstance>> Options = new Dictionary<EDGCHOJDFNC, Dictionary<LobbyOption, LobbyOptionInstance>>();
		private readonly EDGCHOJDFNC _original;

		//TODO use ObservableCollection
		public List<IPlayer> Players
		{
			get
			{
				var list = new List<IPlayer>();
				
				foreach (var player in GLHCHLEDNBA.AllPlayerControls)
				{
					list.Add(new PlayerWrapper(player));
				}

				return list;
			}
		}

		public float CountDownTimer
		{
			get => _original.LHBIJMAFIAG;
			set => _original.LHBIJMAFIAG = value;
		}

		public int MinPlayers
		{
			get => _original.MinPlayers;
			set => _original.MinPlayers = value;
		}

		public int LastPlayerCount
		{
			get => _original.NIKNMFDBPKH;
			set => _original.NIKNMFDBPKH = value;
		}

		public StartingState StartState
		{
			get => (StartingState) _original.PJANPABCOJM;
			set => _original.PJANPABCOJM = (EDGCHOJDFNC.HFJIGGOIKPK) value;
		}

		public string GameStartText
		{
			get => _original.GameStartText.Text;
			set => _original.GameStartText.Text = value;
		}

		public string GameRoomName
		{
			get => _original.GameRoomName.Text;
			set => _original.GameRoomName.Text = value;
		}

		public string PlayerCounter
		{
			get => _original.PlayerCounter.Text;
			set => _original.PlayerCounter.Text = value;
		}
		
		public GameLobbyWrapper(EDGCHOJDFNC original) => _original = original;
		
		public void ResetStartState() => _original.ResetStartState();
		public T GetOption<T>(LobbyOption<T> option) => ((LobbyOptionInstance<T>) Options[_original][option]).Value;
	}
}
