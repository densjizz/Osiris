using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osiris.Stats
{
    public class Stat
    {
        public string Name { get; set; }
        public float BaseValue { get; set; }
        public float Scaling { get; set; }
        public bool IsPrimary { get; set; }


        public float TotalValue
        {
            get
            {
                float result = BaseValue;
                foreach (StatModifier mod in Modifiers)
                {
                    result += mod.Value;
                }
                return result;
            }

        }
        public List<StatModifier> Modifiers { get; set; }



        public Stat(string name, float baseValue)
        {
            this.Name = name;
            this.BaseValue = baseValue;
            Modifiers = new List<StatModifier>();
            Scaling = 1;
        }

        public Stat(string name, float baseValue, float scaling)
        {
            this.Name = name;
            this.BaseValue = baseValue;
            Modifiers = new List<StatModifier>();
            Scaling = scaling;
        }


        public void LevelUp()
        {
            this.BaseValue += Scaling;
        }



        public void AddModifier(StatModifier mod)
        {
            Modifiers.Add(mod);
        }
    }
}
