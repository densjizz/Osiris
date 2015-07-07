using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager
{
    public class Team
    {
        public Guid TeamUID { get; private set; }
        public string Name { get; set; }
        public List<Membership> Members;

        public Team() {
            TeamUID = Guid.NewGuid();
            Members = new List<Membership>();
        }

    }
}
