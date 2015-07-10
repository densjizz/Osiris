using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Actions
{
    public class UseItem : Action
    {
        
        public Item Item { get; set; }
        public ISceneActor Caster { get; set; }
        public ISceneActor Target { get; set; }

        public UseItem() {
            Type = ActionType.ItemUse;       
        }

        public override void Resolve()
        {
            Item.Resolve(Caster, Target);
        }
    }
}
