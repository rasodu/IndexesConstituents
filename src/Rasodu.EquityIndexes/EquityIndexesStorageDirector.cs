namespace Rasodu.EquityIndexes
{
    class EquityIndexesStorageDirector
    {
        internal EquityIndexesStorageSingleton GetEquityIndexesStorage()
        {
            var storage = EquityIndexesStorageSingleton.Instance;
            var storeFactory = new EquityIndexStoreFactory();
            foreach (var equityIndex in Updater.EquityIndexes)
            {
                var csvStore = storeFactory.GetCSVStore(equityIndex);
                var jsonStore = storeFactory.GetJSONStore(equityIndex);
                storage.RegisterEquityIndexUpdatedIndex(equityIndex, new EquityIndexUpdated(csvStore.ReplaceAll));
                storage.RegisterEquityIndexUpdatedIndex(equityIndex, new EquityIndexUpdated(jsonStore.ReplaceAll));
            }
            return storage;
        }
    }
}
