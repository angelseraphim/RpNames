using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;
using RpNames.Constructor;

namespace RpNames
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Basic RP names that are accepted if the constructor rpnames is empty")]
        public List<string> MainRpNames { get; set; } = new List<string>() { "Enter RP name here :3" };

        [Description("RP name constructor, set rpnames to empty to use the main RP names")]
        public Dictionary<Team, NameConstructor> NameConstructor { get; set; } = new Dictionary<Team, NameConstructor>()
        {
            {Team.ChaosInsurgency, new NameConstructor("%id% | %rpname% | %nick%", new List<string>() {"ExampleName", "ExampleRpName" }) },
            {Team.ClassD, new NameConstructor("%id% | D-%random% | %nick%", new List<string>()) },
            {Team.FoundationForces, new NameConstructor("%id% | %rpname% | %nick%", new List<string>()) },
            {Team.Scientists, new NameConstructor("%id% | %rpname% | %nick%", new List<string>()) },
            {Team.SCPs, new NameConstructor("%id% | %role% | %nick%", new List<string>()) },
        };
    }
}
