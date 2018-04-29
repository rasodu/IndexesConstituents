using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    interface IEquityIndexDiskWriter
    {
        void ReplaceAll(List<Equity> equities);
    }
}
