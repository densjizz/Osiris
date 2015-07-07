using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Stats
{
    public class Armor : Stat
    {
        public float ReductionFactor = 0.06f;

        public Armor(string name, float baseValue, float Reduction)
            : base(name, baseValue)
        {
            ReductionFactor = Reduction;
        }

        public Armor(string name, float baseValue) : base(name, baseValue) {
            
        }

        public float Reduction {
            get { return ((ReductionFactor * TotalValue) / (1.0f + ReductionFactor * TotalValue)); }
        }

        public float Augmentation
        {   
            get
            {
                var armorAbs = Math.Abs(TotalValue);
                return ((ReductionFactor * armorAbs) / (1.0f + ReductionFactor * armorAbs));
            }
        }



        public float ApplyArmor(float val)
        {
            float returnValue = 0;
            if (TotalValue > 0)
            {
                returnValue = val - (Reduction * val);
            }
            else if (TotalValue < 0)
            {
                returnValue = val + (Augmentation * val);
            }
            return (float)(Math.Round(returnValue, 3));
        }
    }
}
