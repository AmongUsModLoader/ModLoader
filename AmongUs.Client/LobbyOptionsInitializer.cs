using System;
using AmongUs.Api;
using AmongUs.Api.Registry;

namespace AmongUs.Client
{
    public static class LobbyOptionsInitializer
    {
        public static void RegisterAll()
        {
            void Register<T>(string name, LobbyOption<T> option, Func<OEFJGMAEENB, T> getter, Action<OEFJGMAEENB, T> setter)
            {
                if (!(option is LazyLobbyOption<T> lazyOption)) return;

                string Serialize(T obj)
                {
                    if (obj is bool b)
                    {
                        return b ? "On" : "Off";
                    }

                    return obj.ToString();
                }
                
                var key = new RegistryKey("AmongUs", name);
                option.Key = key;
                lazyOption.Initialize(lobby => new LazyOptionInstance<T>(lobby, getter, setter), Serialize);
                LobbyOptions.Registry[key] = option;
            }
            
            Register("Max Players", LobbyOptions.MaxPlayers, options => options.PCKBBJFMMFL, (options, value) => options.PCKBBJFMMFL = value);
            Register("Ghost Tasks", LobbyOptions.GhostsDoTasks, options => options.KPMMNAPPMLK, (options, value) => options.KPMMNAPPMLK = value);
            Register("Map", LobbyOptions.Map, options => ModLoaderPlugin.MapTypes[(DAFPFFMKPJJ.DFCBBBIBKKC) options.HGMAKPLFANN], (options, value) => options.HGMAKPLFANN = (byte) ModLoaderPlugin.ReverseMapTypes[value]);
            Register("# Impostors", LobbyOptions.Impostors, options => options.FIEIHPHGJPL, (options, value) => options.FIEIHPHGJPL = value);
            Register("Confirm Ejects", LobbyOptions.ConfirmEjects, options => options.JFAKHFFMHIO, (options, value) => options.JFAKHFFMHIO = value);
            Register("# EmergencyMeetings", LobbyOptions.EmergencyMeetings, options => options.LIFCGGNFEML, (options, value) => options.LIFCGGNFEML = value);
            Register("Anonymous Votes", LobbyOptions.AnonymousVotes, options => options.IAFJLBELLDA, (options, value) => options.IAFJLBELLDA = value);
            Register("Emergency Cooldown", LobbyOptions.EmergencyCooldown, options => options.BLCAKAJBHLC, (options, value) => options.BLCAKAJBHLC = value);
            Register("Discussion Time", LobbyOptions.DiscussionTime, options => options.PHKOBAMEEGK, (options, value) => options.PHKOBAMEEGK = value);
            Register("Voting Time", LobbyOptions.VotingTime, options => options.FAGPOFNMCPK, (options, value) => options.FAGPOFNMCPK = value);
            Register("Player Speed", LobbyOptions.PlayerSpeed, options => options.LOHPLKGPFNA, (options, value) => options.LOHPLKGPFNA = value);
            Register("Crewmate Vision", LobbyOptions.CrewmateVision, options => options.FNLABFPPJJM, (options, value) => options.FNLABFPPJJM = value);
            Register("Impostor Vision", LobbyOptions.ImpostorVision, options => options.PJEHIKCGHMD, (options, value) => options.PJEHIKCGHMD = value);
            Register("Kill Cooldown", LobbyOptions.KillCooldown, options => options.KDOKPOJFEKB, (options, value) => options.KDOKPOJFEKB = value);
            Register("Kill Distance", LobbyOptions.KillDistance, options => ModLoaderPlugin.KillDistances[options.CCIEDBPKKMP], (options, value) => options.CCIEDBPKKMP = ModLoaderPlugin.ReverseKillDistances[value]);
            Register("Task Bar Updates", LobbyOptions.TaskBarUpdates, options => (TaskBarUpdates) options.BNIJDCGPMKO, (options, value) => options.BNIJDCGPMKO = (BNIJDCGPMKO) value);
            Register("Visual Tasks", LobbyOptions.VisualTasks, options => options.GMJFJNNICHC, (options, value) => options.GMJFJNNICHC = value);
            Register("# Common Tasks", LobbyOptions.CommonTasks, options => options.OAHKBIHPHGB, (options, value) => options.OAHKBIHPHGB = value);
            Register("# Long Tasks", LobbyOptions.LongTasks, options => options.LGBIDHFOBCA, (options, value) => options.LGBIDHFOBCA = value);
            Register("# Short Tasks", LobbyOptions.ShortTasks, options => options.LPJNEJIIFNB, (options, value) => options.LPJNEJIIFNB = value);
        }
        
        private class LazyOptionInstance<T> : LobbyOptionInstance<T>
        {
            private Func<OEFJGMAEENB, T> _getter;
            private Action<OEFJGMAEENB, T> _setter;
            
            public override T Value
            {
                get => _getter(GLHCHLEDNBA.GameOptions);
                set
                {
                    _setter(GLHCHLEDNBA.GameOptions, value);
                    TriggerSettingsUpdate();
                }
            }

            public LazyOptionInstance(IGameLobby lobby, Func<OEFJGMAEENB, T> getter, Action<OEFJGMAEENB, T> setter) : base(lobby)
            {
                _getter = getter;
                _setter = setter;
            }
        }
    }
}
