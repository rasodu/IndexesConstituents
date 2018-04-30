using System;
using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexesConstituentsUpdater
    {
        private IDictionary<string, Type> _sourceClasses;
        IndexConstituentsSourceFactory _sourceFactory;
        private IndexesConstituentsStorageSingleton _store;
        internal IndexesConstituentsUpdater()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
            _sourceFactory = new IndexConstituentsSourceFactory();
            _store = new IndexesConstituentsStorageDirector().GetEquityIndexesStorage();
        }
        internal void UpdateAll()
        {
            foreach (var sourceClass in _sourceClasses)
            {
                var source = _sourceFactory.GetEquityIndexSource(sourceClass.Key);
                var equitiesInTheIndex = source.GetAllEquities();
                _store.SetDataForIndex(sourceClass.Key, equitiesInTheIndex);
            }
        }
    }
}
