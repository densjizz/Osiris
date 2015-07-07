using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osiris.Stats
{
    public class StatModifier
    {

        public string Name { get; set; }
        virtual public float Value { get; set; }
    
        public StatModifier(float value)
        {
            Value = value;
            Name = "";
        }

        public StatModifier(string name, float value)
        {
            if (value != 0) Value = value;
            Name = name;
            
        }
    }
}
