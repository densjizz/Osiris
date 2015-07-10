using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Actions
{
    public abstract class Item
    {

        public string Name { get; set; }
        
        
        public virtual void Resolve(ISceneActor Caster, ISceneActor Target)
        {
            
        }
    }
}
