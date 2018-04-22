using System;
using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    internal sealed class EquityIndexesStorageSingleton
    {
        private EquityIndexesStorageSingleton()
        {
            equityIndexHt = new Dictionary<string, IList<Equity>>();
        }
        private static readonly Lazy<EquityIndexesStorageSingleton> _lazy = new Lazy<EquityIndexesStorageSingleton>(() => new EquityIndexesStorageSingleton());
        internal static EquityIndexesStorageSingleton Instance
        {
            get
            {
                return _lazy.Value;
            }
        }
        internal IDictionary<string, IList<Equity>> equityIndexHt;
        internal void SetDataForIndex(string equityIndexName, IList<Equity> equitiesInIndex)
        {
            equityIndexHt[equityIndexName] = equitiesInIndex;
        }
    }
}
