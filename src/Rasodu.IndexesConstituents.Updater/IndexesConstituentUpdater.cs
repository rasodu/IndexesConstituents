using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexesConstituentUpdater
    {
        public static IList<string> EquityIndexes = new List<string>
        {
            "DowJones30",
            "SP500",
            "Nifty100",
        };
        IndexConstituentSourceFactory _sourceFactory;
        private IndexesConstituentStorageSingleton _store;
        internal IndexesConstituentUpdater()
        {
            _sourceFactory = new IndexConstituentSourceFactory();
            _store = new IndexesConstituentStorageDirector().GetEquityIndexesStorage();
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
