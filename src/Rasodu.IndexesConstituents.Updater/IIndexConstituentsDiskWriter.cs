using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    interface IIndexConstituentsDiskWriter
    {
        string FileExtension();
        void ReplaceAll(List<Equity> equities);
    }
}
