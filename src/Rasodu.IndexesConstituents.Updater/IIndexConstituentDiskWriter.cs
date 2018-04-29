using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    interface IIndexConstituentDiskWriter
    {
        void ReplaceAll(List<Equity> equities);
    }
}
