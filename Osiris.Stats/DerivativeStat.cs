using Osiris.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Stats
{
    public class DerivativeStat
    {

        private float Scaling = 1.0f;
        public List<StatModifier> Modifiers { get; set; }


        public string Name { get; set; }
        public float CurrentValue {
            get { return (CurrentPercentage*MaxValue); }
        }
        public float MaxValue {
            get
            {
                return strenghtStat.TotalValue*Scaling;
            }
        }
        public float Percentage {
            get { return CurrentPercentage; }
        }


        private float CurrentPercentage;
        private Stat strenghtStat;

        public DerivativeStat(Stat cStrenghtStat, float scaling)
        {
            CurrentPercentage = 1.0f;
            strenghtStat = cStrenghtStat;
            Modifiers = new List<StatModifier>();
            Scaling = scaling;
        }

        public void ModifyValue(float ammount)
        {
            float newValue = CurrentValue + ammount;
            CurrentPercentage = newValue/MaxValue;
        }
    }
}
