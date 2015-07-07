using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Osiris.Constants;

namespace Osiris.Stats.Test
{
    [TestFixture]
    public class StatsTest
    {

        [Test]
        public void CreateStatWithNameAndValue()
        {
            string name = "sdsd";
            float value = 10.1f;
            Stat stat = new Stat(name, value);


            Assert.IsTrue(stat.BaseValue == value);
            Assert.IsTrue(stat.Name == name);
        }


        [Test]
        public void CreateStatModifier()
        {
            float Value = 10.0f;
            string Name = "fsdhnuh";
            StatModifier mod = new StatModifier(Name, Value);

            Assert.IsTrue(mod.Value == Value);
            Assert.IsTrue(mod.Name == Name);
        }


        [Test]
        public void AddModifierToStat()
        {
            string name = "sdsd";
            float value = 10.0f;
            Stat stat = new Stat(name, value);

            float modValue = 5.0f;
            string modName = "fsdhnuh";
            StatModifier mod = new StatModifier(modName, modValue);

            stat.AddModifier(mod);
            

            Assert.IsTrue(stat.Name == name);
            Assert.IsTrue(stat.BaseValue == value);
            Assert.IsTrue(stat.TotalValue == modValue + value);
        }



        [Test]
        public void CreateHealthStat()
        {
            string name = "sdsd";
            float value = 20.0f;
            Stat stat = new Stat(name, value);


            string hName = "Health";
            DerivativeStat hp = new DerivativeStat(stat, StatisticConstants.STRENGHT_TO_HEALTH_SCALE);


            Assert.IsTrue(hp.CurrentValue == value * StatisticConstants.STRENGHT_TO_HEALTH_SCALE);
            Assert.IsTrue(hp.MaxValue == value * StatisticConstants.STRENGHT_TO_HEALTH_SCALE);
        }

        [Test]
        public void CreateAndModifyHealthStat()
        {
            string name = "sdsd";
            float value = 20.0f;
            Stat stat = new Stat(name, value);


            string hName = "Health";
            DerivativeStat hp = new DerivativeStat(stat, StatisticConstants.STRENGHT_TO_HEALTH_SCALE);
            hp.ModifyValue(-100.0f);

            Assert.IsTrue(hp.CurrentValue == 280);
            Assert.IsTrue(hp.MaxValue == value * StatisticConstants.STRENGHT_TO_HEALTH_SCALE);
        }

        [Test]
        public void CreateAndModifyHealthWithRescaleStat()
        {
            string name = "Strenght";
            float value = 20.0f;
            float firstValue = 0.0f;
            float secondValue = 0.0f;
            float firstPercentage = 0.0f;
            float secondPercentage = 0.0f;
            Stat stat = new Stat(name, value);

            //
            string hName = "Health";
            DerivativeStat hp = new DerivativeStat(stat, StatisticConstants.STRENGHT_TO_HEALTH_SCALE);
            hp.ModifyValue(-100.0f);
            firstValue = hp.CurrentValue;
            firstPercentage = hp.Percentage;


            stat.BaseValue -= value/2;
            secondValue = hp.CurrentValue;
            secondPercentage = hp.Percentage;


            //
            Assert.IsTrue(firstValue > secondValue);
            Assert.IsTrue(firstPercentage == secondPercentage);
        }


        [Test]
        public void CreateArmorAndApplyIt()
        {
            string Name = "";
            float Value = 10.0f;
            float dmgVal = 100;
            Armor a = new Armor(Name, Value);

            float reduced = a.ApplyArmor(dmgVal);

            Assert.IsTrue(a.Reduction == 0.375f);
            Assert.IsTrue(reduced == (62.5f));
        }

        [Test]
        public void CreateArmorAndApplyItWithNegativeValues()
        {
            string Name = "";
            float Value = -10.0f;
            float dmgVal = 100;
            Armor a = new Armor(Name, Value);

            float reduced = a.ApplyArmor(dmgVal);

            Assert.IsTrue(reduced == (137.5f));
        }



        [Test]
        public void LevelUpScalingTest()
        {
            Stat intel = new Stat("Intel", 10, 2);


            Assert.IsTrue(intel.TotalValue == 10);
            intel.LevelUp();
            intel.LevelUp();
            intel.LevelUp();
            Assert.IsTrue(intel.TotalValue == 16);
        }


        [Test]
        public void CreateCharacterWithPrimaryStatsAndInflictPhysicDamage()
        {
            //primary
            var strenght = new Stat("Strenght", 10f, 1f);
            var agility = new Stat("Agility", 10f, 1f);
            var intelligence = new Stat("Intelligence", 10f, 1f);
            //derivative
            var health = new DerivativeStat(strenght, 10);
            var mana = new DerivativeStat(intelligence, 17);
            var armor = new Armor("Armor", 3);
            var magicResist = new Armor("Magic Resist", 10, 0.02f);


            var dmg = 25;
            float dmgReducedByArmor = armor.ApplyArmor(dmg);

            Assert.IsTrue(health.CurrentValue == 100);
            health.ModifyValue(dmgReducedByArmor * -1);
            Assert.AreEqual(health.CurrentValue, 100 - dmgReducedByArmor);
        }


        [Test]
        public void CreateCharacterWithPrimaryStatsAndInflictMagicDamage()
        {
            //primary
            var strenght = new Stat("Strenght", 10f, 1f);
            var agility = new Stat("Agility", 10f, 1f);
            var intelligence = new Stat("Intelligence", 10f, 1f);
            //derivative
            var health = new DerivativeStat(strenght, 10);
            var mana = new DerivativeStat(intelligence, 17);
            var armor = new Armor("Armor", 3);
            var magicResist = new Armor("Magic Resist", 10, 0.02f);


            var dmg = 25;
            float dmgReducedByArmor = magicResist.ApplyArmor(dmg);

            Assert.IsTrue(health.CurrentValue == 100);
            health.ModifyValue(dmgReducedByArmor * -1);
            Assert.AreEqual(health.CurrentValue, 100 - dmgReducedByArmor);
        }


        [Test]
        public void CreateCharacterWithPrimaryStatsAndRemoveMana()
        {
            //primary
            var strenght = new Stat("Strenght", 10f, 1f);
            var agility = new Stat("Agility", 10f, 1f);
            var intelligence = new Stat("Intelligence", 10f, 1f);
            //derivative
            var health = new DerivativeStat(strenght, 10);
            var mana = new DerivativeStat(intelligence, 17);
            var armor = new Armor("Armor", 3);
            var magicResist = new Armor("Magic Resist", 10, 0.02f);


            var manaConsumption = 10;
            mana.ModifyValue(manaConsumption * -1);
            Assert.IsTrue(mana.CurrentValue == 160);
        }

        //armor is modified by attribute
        [Test]
        public void CreateCharacterWithPrimaryStatsAndScaleArmor()
        {
            //primary
            var strenght = new Stat("Strenght", 10f, 1f);
            var armorModified = new Armor("Armor", 3);
            var armorFlat = new Armor("Armor", 3);

            ReferenceStatModifier m = new ReferenceStatModifier(strenght, 0.1f);
            armorModified.AddModifier(m);


            float dmgValue = 100.0f;
            var result1 = armorFlat.ApplyArmor(dmgValue);


            var result2 = armorModified.ApplyArmor(dmgValue);
            

            Assert.IsTrue(result1 > result2);
        }


        //armor can be modified by statistics in combat
        [Test]
        public void CreateCharacterWithPrimaryStatsAndScaleArmorAndModifyArmorMeanwhile()
        {
            //primary
            var strenght = new Stat("Strenght", 10f, 1f);
            var armorModified = new Armor("Armor", 3);
            var armorFlat = new Armor("Armor", 3);

            ReferenceStatModifier m = new ReferenceStatModifier(strenght, 0.1f);
            armorModified.AddModifier(m);


            float dmgValue = 100.0f;
            var result1 = armorFlat.ApplyArmor(dmgValue);


            var result2 = armorModified.ApplyArmor(dmgValue);


            Assert.IsTrue(result1 > result2);


            strenght.BaseValue += 10;

            var result3 = armorModified.ApplyArmor(dmgValue);

            Assert.IsTrue(result2 > result3);
        }


    }
}
   
