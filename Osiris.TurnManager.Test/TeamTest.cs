using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager.Test
{
    [TestFixture]
    public class TeamTest
    {
        [Test]
        public void CreateTeam() {
            Team aTeam = new Team();
            aTeam.Name = "Alpha";

            Assert.IsTrue(aTeam.Name == "Alpha");
            Assert.IsTrue(aTeam.TeamUID != null);
        }


        [Test]
        public void IwantToCreateATeamAndAddMembers() {

            var obj1 = new MokupMember();
            var obj2 = new MokupMember();

            Team aTeam = new Team();
            aTeam.Name = "Alpha";

            var member1 = new Membership(obj1);
            var member2 = new Membership(obj2);

            aTeam.Members.Add(member1);
            aTeam.Members.Add(member2);


            Assert.IsTrue(aTeam.Name == "Alpha");
            Assert.IsTrue(aTeam.TeamUID != null);
            Assert.AreEqual(aTeam.Members.Count, 2);
        }
    }
}
