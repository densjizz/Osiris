using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager
{
    public class TurnManager
    {
        public List<ISceneActor> Actors;
        public SceneState state;
        public List<int> ActedThisTurn;
        public int currentActorIndex = 0;
        public ISceneActor CurrentActor;

        public TurnManager() {
            Actors = new List<ISceneActor>();
            ActedThisTurn = new List<int>();
        }

        public void Start()
        {
            Initialize();
        }

        private void OrderBySpeed()
        {
            Actors = Actors.OrderByDescending(x => x.GetStatNamed("Agility").TotalValue).ToList();
        }

        public void Initialize(){
            OrderBySpeed();
            currentActorIndex = 0;
            state = SceneState.Initializing;
        }

        public void Update() {
            if (currentActorIndex >= Actors.Count) {
                FullTurnFinished();
            }
            CurrentActor = Actors[currentActorIndex];

            if (!ActedThisTurn.Contains(CurrentActor.GetId()))
            {
                CurrentActor.PromptActions();
                ActedThisTurn.Add(CurrentActor.GetId());
                CurrentActor.Finished += currentActor_Finished;
            }
        }

        private void FullTurnFinished()
        {
            currentActorIndex = 0;
            OrderBySpeed();
        }

        void currentActor_Finished(object sender, EventArgs e)
        {
            ActorFinished();
        }

        public void ActorFinished()
        {
            currentActorIndex++;
            
        }
    }


    public enum SceneState { 
        Initializing,
        BuffPhase,
        HighSequenceTurn,
        NormalTurns,
        End,
    }
}
