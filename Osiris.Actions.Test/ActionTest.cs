using NUnit.Framework;
using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;

namespace Osiris.Actions.Test
{
    [TestFixture]
    public class ActionTest
    {



        [Test]
        public void CreateAction() {
            
        }


        /// <summary>
        /// Consume an item that restores Health
        /// </summary>
        [Test]
        public void ConsumeAndItem() {


            var caster = new Mock<ISceneActor>();
            var target = new Mock<ISceneActor>();

            HealthPotion hpPotion = new HealthPotion() { Value = 50.0f};
            UseItem useItem = new UseItem() { Item = hpPotion };
            useItem.Target = target.Object;
            useItem.Caster= caster.Object;

            target.Setup(x => x.GetDerivativeStatNamed("Health")).Returns(new DerivativeStat(new Stat("Strenght", 10), 15));
            useItem.Resolve();
            var targetHP = target.Object.GetDerivativeStatNamed("Health");
            Assert.AreEqual(targetHP.CurrentValue, 200.0f);
        }
    }
}
