namespace Rasodu.EquityIndexes
{
    class EquityIndexesStorageDirector
    {
        EquityIndexesStorageSingleton _storage;
        EquityIndexDiskWriterFactory _storeFactory;
        internal EquityIndexesStorageDirector()
        {
            _storage = EquityIndexesStorageSingleton.Instance;
            _storeFactory = new EquityIndexDiskWriterFactory();
        }
        internal EquityIndexesStorageSingleton GetEquityIndexesStorage()
        {
            //register equity index update events
            foreach (var equityIndex in EquityIndexesUpdater.EquityIndexes)
            {
                var csvStore = _storeFactory.GetCSVDiskWriter(equityIndex);
                var jsonStore = _storeFactory.GetJSONDiskWriter(equityIndex);
                _storage.OnEquityIndexUpdated(equityIndex, new EquityIndexUpdated(csvStore.ReplaceAll));
                _storage.OnEquityIndexUpdated(equityIndex, new EquityIndexUpdated(jsonStore.ReplaceAll));
            }
            return _storage;
        }
    }
}
