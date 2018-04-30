using System;
using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    class IndexesConstituentsStorageDirector
    {
        private IDictionary<string, Type> _sourceClasses;
        IndexesConstituentsStorageSingleton _storage;
        IndexConstituentsDiskWriterFactory _storeFactory;
        internal IndexesConstituentsStorageDirector()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
            _storage = IndexesConstituentsStorageSingleton.Instance;
            _storeFactory = new IndexConstituentsDiskWriterFactory();
        }
        internal IndexesConstituentsStorageSingleton GetEquityIndexesStorage()
        {
            //register equity index disk writer event
            foreach (var sourceClass in _sourceClasses)
            {
                var csvStore = _storeFactory.GetCSVDiskWriter(sourceClass.Key);
                var jsonStore = _storeFactory.GetJSONDiskWriter(sourceClass.Key);
                _storage.OnEquityIndexUpdated(sourceClass.Key, new EquityIndexUpdated(csvStore.ReplaceAll));
                _storage.OnEquityIndexUpdated(sourceClass.Key, new EquityIndexUpdated(jsonStore.ReplaceAll));
            }
            return _storage;
        }
    }
}
