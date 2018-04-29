using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    interface IIndexConstituentSource
    {
        List<Equity> GetAllEquities();
    }
}
