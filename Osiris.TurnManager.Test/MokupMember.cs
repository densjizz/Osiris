using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager.Test
{
    public class MokupMember : IStatComposed
    {

        public List<Stat> Statistics;
        public List<DerivativeStat> Attributes;


        public MokupMember(float agilityValue) {
            Statistics = new List<Stat>();
            Attributes = new List<DerivativeStat>();

            var str = new Stat("Strenght", 10);
            Statistics.Add(str);
            var agi = new Stat("Agility", agilityValue);
            Statistics.Add(agi);
            var intel = new Stat("Intelligence", 10);
            Statistics.Add(intel);

            var health = new DerivativeStat(str, 10);
            health.Name = "Health";
            var mana = new DerivativeStat(intel, 17);
            mana.Name = "Mana";

            Attributes.Add(health);
            Attributes.Add(mana);
        }

        public Stat GetStatNamed(string name)
        {
            foreach (Stat s in Statistics) {
                if (s.Name == name) return s;
            }

            return null;
        }


        public DerivativeStat GetDerivativeStatNamed(string name)
        {
            foreach (DerivativeStat a in Attributes)
            {
                if (a.Name == name) return a;
            }

            return null;
        }
    }
}
