using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager
{
    public class TurnManager
    {
        public List<Team> Teams;


        public TurnManager() {
            Teams = new List<Team>();
        }

        public void Start()
        {
            OrderTeams();
        }

        private void OrderTeams()
        {
            foreach (Team t in Teams) {
                OrderTeamMembers(t);
            }
        }

        private void OrderTeamMembers(Team t)
        {
            
        }
    }
}
