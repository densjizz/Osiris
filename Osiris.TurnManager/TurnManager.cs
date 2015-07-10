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
        public List<IStatComposed> Actors;


        public TurnManager() {
            Actors = new List<IStatComposed>();
        }

        public void Start()
        {
            OrderBySpeed();
        }

        private void OrderBySpeed()
        {
            Actors = Actors.OrderByDescending(x => x.GetStatNamed("Agility").TotalValue).ToList();
        }

       
    }
}
