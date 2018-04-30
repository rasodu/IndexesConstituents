using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    interface IIndexConstituentsSource
    {
        string IndexName();
        List<Equity> GetAllEquities();
    }
}
