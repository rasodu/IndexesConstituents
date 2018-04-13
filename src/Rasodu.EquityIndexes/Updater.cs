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
        EquityIndexStoreFactory _storeFactory;
        internal Updater()
        {
            _sourceFactory = new EquityIndexSourceFactory();
            _storeFactory = new EquityIndexStoreFactory();
        }
        internal void UpdateAll()
        {
            foreach (var equityIndex in _equityIndexes)
            {
                var source = _sourceFactory.GetSource(equityIndex);
                var store = _storeFactory.GetStore(equityIndex);
                var equityIndexUpdater = new EquityIndexUpdater(source, store);
                equityIndexUpdater.Update();
            }
        }
    }
}
