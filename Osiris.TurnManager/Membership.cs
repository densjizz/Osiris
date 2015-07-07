using Osiris.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.TurnManager
{
    public class Membership
    {
        private IStatComposed parent;
        public Guid ID { get; set; }

        public Membership(IStatComposed cParent)
        {
            ID = Guid.NewGuid();
            parent = cParent;
        }
    }
}
