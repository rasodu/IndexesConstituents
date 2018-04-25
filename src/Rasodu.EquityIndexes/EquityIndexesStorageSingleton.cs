using System;
using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    internal delegate void EquityIndexUpdated(List<Equity> equities);
    internal sealed class EquityIndexesStorageSingleton
    {
        private EquityIndexesStorageSingleton()
        {
            equityIndexHt = new Dictionary<string, IList<Equity>>();
            observers = new Dictionary<string, EquityIndexUpdated>();
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
        internal IDictionary<string, EquityIndexUpdated> observers;
        internal void RegisterEquityIndexUpdatedIndex(string equityIndexName, EquityIndexUpdated eventDelegate)
        {
            if (!observers.ContainsKey(equityIndexName))
            {
                observers[equityIndexName] = eventDelegate;
            }
            else
            {
                observers[equityIndexName] += eventDelegate;
            }
        }
        internal void SetDataForIndex(string equityIndexName, List<Equity> equitiesInIndex)
        {
            equityIndexHt[equityIndexName] = equitiesInIndex;
            if (observers.ContainsKey(equityIndexName))
            {
                observers[equityIndexName](equitiesInIndex);
            }
        }
    }
}
