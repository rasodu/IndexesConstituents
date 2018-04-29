using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    interface IIndexConstituentDiskWriter
    {
        void ReplaceAll(List<Equity> equities);
    }
}
