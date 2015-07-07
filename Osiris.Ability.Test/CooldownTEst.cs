using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Ability.Test
{
    [TestFixture]
    public class CooldownTest
    {
        [Test]
        public void CreateCooldown() {
            float cooldownTime = 10.0f;
            Cooldown cooldown = new Cooldown(cooldownTime, cooldownTime);
            cooldown.Activate();

            Assert.IsTrue(cooldown.OnCooldown);
            Assert.IsFalse(cooldown.IsReady);

            cooldown.Step(2.0f);
            cooldown.Step(2.0f);
            cooldown.Step(2.0f);
            cooldown.Step(2.0f);
            cooldown.Step(2.0f);

            Assert.IsTrue(cooldown.IsReady);
            Assert.IsFalse(cooldown.OnCooldown);


        }
    }
}
