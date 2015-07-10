using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Actions
{
    public class HealthPotion : Item
    {
        public float Value { get; set; }


        public override void Resolve(Stats.ISceneActor Caster, Stats.ISceneActor Target)
        {
            var health = Target.GetDerivativeStatNamed("Health");
            health.ModifyValue(Value);
        }   
    }
}
