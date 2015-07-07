using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osiris.Stats;

namespace Osiris.Abilities
{
    public class Spell : Ability
    {
        private float damageScale;
        private Stat DamageModifier;
        private float _baseDamage;
        public float BaseDamage {
            get {
                return _baseDamage;    
            }
            
        }

        public Spell(string cName, Stat dmgModifier ,DerivativeStat costStat, float DamageScale, float baseDamage, float spellCost)
            : base(cName, costStat)
        {
            Cost = spellCost;
            DamageModifier = dmgModifier;
            damageScale = DamageScale;
            _baseDamage = baseDamage;
        }


        public float Cast() {
            float dmg = 0;
            //remove mana from pool
            costDerivative.ModifyValue(Cost*-1);

            dmg = (BaseDamage + (DamageModifier.TotalValue * damageScale));

            return dmg;
        }
    }
}
