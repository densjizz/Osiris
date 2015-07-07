using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Ability
{
    public class Cooldown
    {

        public float CurrentValue
        {
            get;
            set;
        }
        private float cooldownTime;

        public Cooldown(float startValue, float maxTime)
        {
            CurrentValue = startValue;
            cooldownTime = maxTime;
        }


        public void Activate()
        {
            CurrentValue = 0;
        }

        public void Step(float time) {
            CurrentValue += time;
        }

        public bool OnCooldown {
            get
            {
                return CurrentValue < cooldownTime;
            }
        }

        public bool IsReady {
            get {
                return CurrentValue >= cooldownTime;
            }
        }
    }
}
