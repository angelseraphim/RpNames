using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using Random = System.Random;

namespace RpNames
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "RpNames";
        public override string Name => "RpNames";
        public override string Author => "angelseraphim.";

        public static Plugin plugin;
        public static Random random;

        public override void OnEnabled()
        {
            plugin = this;
            random = new Random();
            Log.Info("I`m alive!!!");
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            plugin = null;
            random = null;
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
            base.OnDisabled();
        }

        private void OnChangingRole(ChangingRoleEventArgs ev)
        {
            Team team = ev.NewRole.GetTeam();
            if (!Config.NameConstructor.TryGetValue(team, out var constructor))
                return;

            Timing.CallDelayed(0.1f, () => constructor.Apply(ev.Player));
        }
    }
}
