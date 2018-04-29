using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    interface IIndexConstituentSource
    {
        List<Equity> GetAllEquities();
    }
}
