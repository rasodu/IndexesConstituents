namespace Rasodu.IndexesConstituents.Updater
{
    class IndexesConstituentStorageDirector
    {
        IndexesConstituentStorageSingleton _storage;
        IndexConstituentDiskWriterFactory _storeFactory;
        internal IndexesConstituentStorageDirector()
        {
            _storage = IndexesConstituentStorageSingleton.Instance;
            _storeFactory = new IndexConstituentDiskWriterFactory();
        }
        internal IndexesConstituentStorageSingleton GetEquityIndexesStorage()
        {
            //register equity index disk writer event
            foreach (var equityIndex in IndexesConstituentUpdater.EquityIndexes)
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
