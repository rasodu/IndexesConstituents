using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    interface IIndexConstituentsDiskWriter
    {
        void ReplaceAll(List<Equity> equities);
    }
}
