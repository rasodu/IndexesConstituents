using System;
using System.Collections.Generic;
using System.Text;

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
                var store = storeFactory.GetStore(equityIndex);
                storage.RegisterEquityIndexUpdatedIndex(equityIndex, new EquityIndexUpdated(store.ReplaceAll));
            }
            return storage;
        }
    }
}
