using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Actions
{
    public abstract class Action
    {
        public ActionType Type { get; protected set; }


        public virtual void Resolve() { 
            
        }
    }




    public enum ActionType { 
        Attack,
        ItemUse,
        CastSpell,
        Defense
    }
}
