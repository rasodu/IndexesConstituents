﻿using System.Linq;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexUpdater
    {
        private IEquityIndexSource _source;
        private IEquityIndexStore _store;
        internal EquityIndexUpdater(IEquityIndexSource source, IEquityIndexStore store)
        {
            _source = source;
            _store = store;
        }
        internal void Update()
        {
            var equitiesInIndex = _source.GetAllEquities();
            equitiesInIndex = equitiesInIndex.Distinct().ToList();
            equitiesInIndex.Sort();
            _store.ReplaceAll(equitiesInIndex);
        }
    }
}