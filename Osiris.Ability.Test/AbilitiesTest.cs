using NUnit.Framework;
using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Osiris.Abilities.Test
{

    [TestFixture]
    public class AbilitiesTest
    {
        [Test]
        public void CreateAbilityCostLess()
        {
            Ability ability = new Ability("MyAbility");
            ability.Description = "MyDescription";
            ability.GetType = AbilityType.Active;

            Assert.IsTrue(ability.Name == "MyAbility");
        }


        [Test]
        public void CreateAbilityWithCost()
        {
            //create a mana stat
            float IntManaScale = 17.0f;
            Stat intStat = new Stat("Intel", 15);
            DerivativeStat manaPool = new DerivativeStat(intStat, IntManaScale);


            Ability ability = new Ability("MyAbility", manaPool);
            ability.Description = "MyDescription";
            ability.GetType = AbilityType.Active;
            ability.Cost = 100.0f;

            Assert.IsTrue(ability.Name == "MyAbility");
            Assert.IsTrue(ability.HasEnoughRessourceToCast);
        }


        [Test]
        public void CreateAbilityWithCostNotEnoughRessource()
        {
            //create a mana stat
            float IntManaScale = 17.0f;
            Stat intStat = new Stat("Intel", 15);
            DerivativeStat manaPool = new DerivativeStat(intStat, IntManaScale);


            Ability ability = new Ability("MyAbility", manaPool);
            ability.Description = "MyDescription";
            ability.GetType = AbilityType.Active;
            ability.Cost = 100.0f;

            

            Assert.IsTrue(ability.Name == "MyAbility");
            Assert.IsTrue(ability.HasEnoughRessourceToCast);

            manaPool.ModifyValue(-200);

            Assert.IsFalse(ability.HasEnoughRessourceToCast);
        }


        [Test]
        public void CreateAbilityWithCostNotEnoughRessourceWithCooldown()
        {
            //create a mana stat
            float IntManaScale = 17.0f;
            Stat intStat = new Stat("Intel", 15);
            DerivativeStat manaPool = new DerivativeStat(intStat, IntManaScale);


            Ability ability = new Ability("MyAbility", manaPool);
            ability.Description = "MyDescription";
            ability.GetType = AbilityType.Active;
            ability.Cost = 100.0f;
            ability.Cooldown = new Osiris.Ability.Cooldown(0, 10);


            Assert.IsTrue(ability.Cooldown.OnCooldown);
            Assert.IsFalse(ability.Cooldown.IsReady);

            ability.Cooldown.Step(2);
            ability.Cooldown.Step(2);
            ability.Cooldown.Step(2);
            ability.Cooldown.Step(2);
            ability.Cooldown.Step(2);


            Assert.IsFalse(ability.Cooldown.OnCooldown);
            Assert.IsTrue(ability.Cooldown.IsReady);
        }

        [Test]
        public void CreateAbilityWithManaCostFromIntel() {
            float SpellCost = 133;
            float spellBaseDmg = 100;
            float spellScaleFactor = 3;
            float intelStats = 10;
            var intel = new Stat("Intelligence", intelStats);
            var mana = new DerivativeStat(intel, 20);
            mana.Name = "mana";

            var fireballSpell = new Spell("Fireball", intel, mana, spellScaleFactor, spellBaseDmg, SpellCost);


            Assert.IsTrue(fireballSpell.HasEnoughRessourceToCast);


            var manaAmmountBeforeSpellcast = mana.CurrentValue;
            var dmg = fireballSpell.Cast();
            var manaAmmountAfterSpellCast = mana.CurrentValue;
            Assert.IsTrue(manaAmmountBeforeSpellcast-manaAmmountAfterSpellCast == SpellCost );
            Assert.AreEqual(dmg, (spellBaseDmg + (intelStats * spellScaleFactor)));
        }
    }
}
