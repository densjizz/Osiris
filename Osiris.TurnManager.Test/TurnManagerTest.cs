using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager.Test
{
    [TestFixture]
    public class TurnManagerTest
    {


        [Test]
        public void CreateTurnManager() {
            TurnManager mgr = new TurnManager();
            Assert.IsNotNull(mgr);
        }

        [Test]
        public void SetupTwoTeamsWithMembersOrderBySpeed()
        {

            var member1 = new MokupMember(1);
            var member2 = new MokupMember(3);
            var member3 = new MokupMember(2);
            var member4 = new MokupMember(4);

            


            TurnManager mgr = new TurnManager();
            mgr.Actors.Add(member3);
            mgr.Actors.Add(member4);
            mgr.Actors.Add(member1);
            mgr.Actors.Add(member2);
            mgr.Start();


            Assert.AreEqual(mgr.Actors[0].GetStatNamed("Agility").TotalValue, 4);
            Assert.AreEqual(mgr.Actors[1].GetStatNamed("Agility").TotalValue, 3);
            Assert.AreEqual(mgr.Actors[2].GetStatNamed("Agility").TotalValue, 2);
            Assert.AreEqual(mgr.Actors[3].GetStatNamed("Agility").TotalValue, 1);
        }
    }
}
