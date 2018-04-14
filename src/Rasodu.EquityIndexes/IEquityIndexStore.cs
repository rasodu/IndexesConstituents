using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    interface IEquityIndexStore
    {
        void ReplaceAll(List<Equity> equities);
    }
}
