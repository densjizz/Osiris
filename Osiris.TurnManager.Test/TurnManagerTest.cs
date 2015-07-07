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
        public void SetupTwoTeamsWithMembers() {

            var teamA = new Team();
            var memberA1 = new Membership(new MokupMember());
            var memberA2 = new Membership(new MokupMember());
            teamA.Members.Add(memberA1);
            teamA.Members.Add(memberA2);


            var teamB = new Team();
            var memberB1 = new Membership(new MokupMember());
            var memberB2 = new Membership(new MokupMember());
            teamB.Members.Add(memberB1);
            teamB.Members.Add(memberB2);


            TurnManager mgr = new TurnManager();
            mgr.Teams.Add(teamA);
            mgr.Teams.Add(teamB);

            mgr.Start();


        }
    }
}
