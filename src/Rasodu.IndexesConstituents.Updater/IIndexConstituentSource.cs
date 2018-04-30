using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    interface IIndexConstituentSource
    {
        string IndexName();
        List<Equity> GetAllEquities();
    }
}
