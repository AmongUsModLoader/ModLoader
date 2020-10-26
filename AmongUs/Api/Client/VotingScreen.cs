using System;

namespace AmongUs.Api
{
    public static class VotingScreen
    {
        public static event Action<MeetingHud> UpdateEvent;

        public static void Update(MeetingHud hud) => UpdateEvent?.Invoke(hud);
    }
}
