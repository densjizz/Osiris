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

            var member1 = new MokupMember(1,1);
            var member2 = new MokupMember(2,3);
            var member3 = new MokupMember(3,2);
            var member4 = new MokupMember(4,4);

            


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

        [Test]
        public void IWantToPromptActorForActions() {
            var member1 = new MokupMember(0,1);
            var member2 = new MokupMember(1,3);
            var member3 = new MokupMember(2,2);
            var member4 = new MokupMember(3,4);

            

            
            TurnManager mgr = new TurnManager();
            mgr.Actors.Add(member3);
            mgr.Actors.Add(member4);
            mgr.Actors.Add(member1);
            mgr.Actors.Add(member2);
            mgr.Start();
            mgr.Update();

            //assert that current actor is the highest agility
            Assert.IsTrue(mgr.CurrentActor.GetId() == 3);

            //finish turn of this actor
            member4.PromptFinished();
            mgr.Update();
            //assert that current actor is the one with 3 agility
            Assert.IsTrue(mgr.CurrentActor.GetId() == 1);
            member2.PromptFinished();
            
        }



        /// <summary>
        /// Complete turn
        /// </summary>
        [Test]
        public void PromptForActionsUntilItLoopsBackToFirstMember()
        {
            var member1 = new MokupMember(0, 1);
            var member2 = new MokupMember(1, 3);
            var member3 = new MokupMember(2, 2);
            var member4 = new MokupMember(3, 4);




            TurnManager mgr = new TurnManager();
            mgr.Actors.Add(member3);
            mgr.Actors.Add(member4);
            mgr.Actors.Add(member1);
            mgr.Actors.Add(member2);
            mgr.Start();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 3);
            member4.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 1);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 2);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 0);
            member2.PromptFinished();

            //should loop back to id 3 here
            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 3);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 1);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 2);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 0);
            member2.PromptFinished();
        }



        /// <summary>
        /// Complete turn and change agility so someone else is first
        /// </summary>
        [Test]
        public void PromptForActionsUntilItLoopsBackToFirstMemberWithChangedSpeed()
        {
            var member1 = new MokupMember(0, 1);
            var member2 = new MokupMember(1, 3);
            var member3 = new MokupMember(2, 2);
            var member4 = new MokupMember(3, 4);




            TurnManager mgr = new TurnManager();
            mgr.Actors.Add(member3);
            mgr.Actors.Add(member4);
            mgr.Actors.Add(member1);
            mgr.Actors.Add(member2);
            mgr.Start();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 3);
            member4.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 1);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 2);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 0);
            member2.PromptFinished();

            member2.GetStatNamed("Agility").BaseValue += 10;

            //should loop back to id 1 here
            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 1);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 3);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 2);
            member2.PromptFinished();

            mgr.Update();
            Assert.IsTrue(mgr.CurrentActor.GetId() == 0);
            member2.PromptFinished();
        }

        
    }
}
