using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Stats
{
    public class ReferenceStatModifier : StatModifier
    {

        private Stat Reference;
        private float scale;

        public ReferenceStatModifier(Stat statRef, float Scale) : base(statRef.Name, 0){
            Reference = statRef;
            scale = Scale;
        }


        public override float Value
        {
            get
            {
                return Reference.TotalValue * scale;
            }
            set
            {
                throw (new Exception("cannot set value of reference stat"));
            }
        }
    }
}
