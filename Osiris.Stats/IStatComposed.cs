using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Stats
{
    public interface IStatComposed
    {
        Stat GetStatNamed(string name);
        DerivativeStat GetDerivativeStatNamed(string name);
    }
}
