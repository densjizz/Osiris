using Osiris.Ability;
using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osiris.Abilities
{
    public class Ability
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public AbilityType GetType { get; set; }
        public float Cost { get; set; }
        protected DerivativeStat costDerivative;
        public Cooldown Cooldown;

        public Ability(string cName)
        {
            Name = cName;
            Description = "";
            GetType = AbilityType.Active;
            Cost = 0;
            Cooldown = new Cooldown(0, 0);
        }

        public Ability(string cName, DerivativeStat cDerivative)
        {
            Name = cName;
            costDerivative = cDerivative;
            Cooldown = new Cooldown(0, 0);
        }


        public bool HasEnoughRessourceToCast {
            get {
                return costDerivative.CurrentValue >= Cost;
            }
        }


        
    }

    public enum AbilityType { 
        Active,
        Toggle,
        Passive
    }
}
