using System;
using AmongUs.Api;
using AmongUs.Api.Registry;

namespace AmongUs.Client
{
    public static class LobbyOptionsInitializer
    {
        public static void Start()
        {
            void Register(string name, LobbyOption option)
            {
                if (option.GetType() == typeof(LazyLobbyOption<>))
                {
                    var generic = option.GetType().GenericTypeArguments[0];
                    string BoolSerializer(object obj) => (bool) obj ? "On" : "Off";
                    string ObjectSerializer(object obj) => obj.ToString();
                    var serializer = generic == typeof(bool) ? BoolSerializer : (Func<object, string>) ObjectSerializer; 
                    var key = new RegistryKey("AmongUs", name);
                    option.Key = key;
                    //((LazyLobbyOption<object>) option).Initialize(null, serializer);
                    LobbyOptions.Registry[key] = option;
                }
            }
            
            Register("Max Players", LobbyOptions.MaxPlayers);
            Register("Ghost Tasks", LobbyOptions.GhostsDoTasks);
            Register("Map", LobbyOptions.Map);
            Register("# Impostors", LobbyOptions.Impostors);
            Register("Confirm Ejects", LobbyOptions.ConfirmEjects);
            Register("# EmergencyMeetings", LobbyOptions.EmergencyMeetings);
            Register("Anonymous Votes", LobbyOptions.AnonymousVotes);
            Register("Emergency Cooldown", LobbyOptions.EmergencyCooldown);
            Register("Discussion Time", LobbyOptions.DiscussionTime);
            Register("Voting Time", LobbyOptions.VotingTime);
            Register("Player Speed", LobbyOptions.PlayerSpeed);
            Register("Crewmate Vision", LobbyOptions.CrewmateVision);
            Register("Impostor Vision", LobbyOptions.ImpostorVision);
            Register("Kill Cooldown", LobbyOptions.KillCooldown);
            Register("Kill Distance", LobbyOptions.KillDistance);
            Register("Task Bar Updates", LobbyOptions.TaskBarUpdates);
            Register("Visual Tasks", LobbyOptions.VisualTasks);
            Register("# Common Tasks", LobbyOptions.CommonTasks);
            Register("# Long Tasks", LobbyOptions.LongTasks);
            Register("# Short Tasks", LobbyOptions.ShortTasks);
        }
    }
}
