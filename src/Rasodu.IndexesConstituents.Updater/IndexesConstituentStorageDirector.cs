using System;
using System.Collections.Generic;

namespace Rasodu.IndexesConstituents.Updater
{
    class IndexesConstituentStorageDirector
    {
        private IDictionary<string, Type> _sourceClasses;
        IndexesConstituentStorageSingleton _storage;
        IndexConstituentDiskWriterFactory _storeFactory;
        internal IndexesConstituentStorageDirector()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
            _storage = IndexesConstituentStorageSingleton.Instance;
            _storeFactory = new IndexConstituentDiskWriterFactory();
        }
        internal IndexesConstituentStorageSingleton GetEquityIndexesStorage()
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
