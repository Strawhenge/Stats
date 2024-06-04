using System.Collections.Generic;

namespace Strawhenge.Stats.Unity
{
    public interface IStatSetupGroup
    {
        IEnumerable<IStatSetup> All();
    }
}