using System;
using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexesConstituentUpdater
    {
        private IDictionary<string, Type> _sourceClasses;
        IndexConstituentSourceFactory _sourceFactory;
        private IndexesConstituentStorageSingleton _store;
        internal IndexesConstituentUpdater()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
            _sourceFactory = new IndexConstituentSourceFactory();
            _store = new IndexesConstituentStorageDirector().GetEquityIndexesStorage();
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
