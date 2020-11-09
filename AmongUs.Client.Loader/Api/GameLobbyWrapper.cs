using System.Collections.Generic;
using AmongUs.Api;

namespace AmongUs.Client.Loader.Api
{
	public readonly struct GameLobbyWrapper : IGameLobby
	{
		private EDGCHOJDFNC Original { get; }

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
			get => Original.LHBIJMAFIAG;
			set => Original.LHBIJMAFIAG = value;
		}

		public int MinPlayers
		{
			get => Original.MinPlayers;
			set => Original.MinPlayers = value;
		}

		public int LastPlayerCount
		{
			get => Original.NIKNMFDBPKH;
			set => Original.NIKNMFDBPKH = value;
		}

		public StartingState StartState
		{
			get => (StartingState) Original.PJANPABCOJM;
			set => Original.PJANPABCOJM = (EDGCHOJDFNC.HFJIGGOIKPK) value;
		}

		public string GameStartText
		{
			get => Original.GameStartText.Text;
			set => Original.GameStartText.Text = value;
		}

		public string GameRoomName
		{
			get => Original.GameRoomName.Text;
			set => Original.GameRoomName.Text = value;
		}

		public string PlayerCounter
		{
			get => Original.PlayerCounter.Text;
			set => Original.PlayerCounter.Text = value;
		}

		public void ResetStartState()
		{
			Original.ResetStartState();
		}

		public GameLobbyWrapper(EDGCHOJDFNC original) => Original = original;
	}
}
