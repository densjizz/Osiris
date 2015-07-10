using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Stats
{

    public delegate void FinishedDelegate();

    public interface ISceneActor
    {
        Stat GetStatNamed(string name);
        DerivativeStat GetDerivativeStatNamed(string name);
        int GetId();

        void PromptActions();
        event EventHandler Finished;
    }


    
}
