using System.Collections.Generic;

namespace Rasodu.EquityIndexes
{
    internal class Updater
    {
        private IList<string> _equityIndexes = new List<string>
        {
            "DowJones30",
            "SP500",
            "Nifty100",
        };
        EquityIndexSourceFactory _sourceFactory;
        private EquityIndexesStorageSingleton _store;
        internal Updater()
        {
            _sourceFactory = new EquityIndexSourceFactory();
            _store = EquityIndexesStorageSingleton.Instance;
        }
        internal void UpdateAll()
        {
            foreach (var equityIndex in _equityIndexes)
            {
                var source = _sourceFactory.GetSource(equityIndex);
                var equitiesInTheIndex = source.GetAllEquities();
                _store.SetDataForIndex(equityIndex, equitiesInTheIndex);
            }
        }
    }
}
