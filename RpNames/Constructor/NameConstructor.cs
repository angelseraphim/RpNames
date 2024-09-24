using Exiled.API.Features;
using System.Collections.Generic;

namespace RpNames.Constructor
{
    public class NameConstructor
    {
        public string NameStructure { get; set; }
        public List<string> RpNames { get; set; }
        public NameConstructor() { }
        public NameConstructor(string nameStructure, List<string> rpNames)
        {
            NameStructure = nameStructure;
            RpNames = rpNames;
        }
        public void Apply(Player player)
        {
            int Random = Plugin.random.Next(1000, 9999);
            string NewName = RpNames.Count != 0
                ? NameStructure.Replace("%id%", player.Id.ToString()).Replace("%nick%", player.Nickname).Replace("%random%", Random.ToString()).Replace("%role%", player.Role.Name).Replace("%rpname%", RpNames.RandomItem())
                : NameStructure.Replace("%id%", player.Id.ToString()).Replace("%nick%", player.Nickname).Replace("%random%", Random.ToString()).Replace("%role%", player.Role.Name).Replace("%rpname%", Plugin.plugin.Config.MainRpNames.RandomItem());

            player.DisplayNickname = NewName;
        }
    }
}
