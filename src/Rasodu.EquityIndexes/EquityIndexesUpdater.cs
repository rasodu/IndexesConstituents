using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexesUpdater
    {
        public static IList<string> EquityIndexes = new List<string>
        {
            "DowJones30",
            "SP500",
            "Nifty100",
        };
        EquityIndexSourceFactory _sourceFactory;
        private EquityIndexesStorageSingleton _store;
        internal EquityIndexesUpdater()
        {
            _sourceFactory = new EquityIndexSourceFactory();
            _store = new EquityIndexesStorageDirector().GetEquityIndexesStorage();
        }
        internal void UpdateAll()
        {
            foreach (var equityIndex in EquityIndexes)
            {
                var source = _sourceFactory.GetEquityIndexSource(equityIndex);
                var equitiesInTheIndex = source.GetAllEquities();
                _store.SetDataForIndex(equityIndex, equitiesInTheIndex);
            }
        }
    }
}
