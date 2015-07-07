using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Stats
{
    public class SpeedStat
    {
        private Stat agility;
        private float _baseSpeed;


        public SpeedStat(Stat agilityStat)
        {
            agility = agilityStat;  
        }



        public float BaseSpeed {
            get { return _baseSpeed; }
        }

    }
}
