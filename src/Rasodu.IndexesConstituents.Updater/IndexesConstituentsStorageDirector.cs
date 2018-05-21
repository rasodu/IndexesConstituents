using System;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    class IndexesConstituentsStorageDirector
    {
        private IDictionary<string, Type> _sourceClasses;
        IndexesConstituentsStorageSingleton _storage;
        Helper _helper;
        internal IndexesConstituentsStorageDirector()
        {
            _sourceClasses = new Helper().GetAllSourceClasses();
            _storage = IndexesConstituentsStorageSingleton.Instance;
            _helper = new Helper();
        }
        internal IndexesConstituentsStorageSingleton GetEquityIndexesStorage()
        {
            //register equity index disk writer event
            foreach (var sourceClass in _sourceClasses)
            {
                RegisterWritersForSource(sourceClass.Key);
            }
            return _storage;
        }
        private void RegisterWritersForSource(string equityIndexFilename)
        {
            var writerTypes = _helper.GetAllWriterClasses();
            foreach (var type in writerTypes)
            {
                //example: CSV/DowJones30.csv
                var textWriter = _helper.GetTextWriterForExistingFileInTree(type.Key.ToUpper() + Path.DirectorySeparatorChar + equityIndexFilename + "." + type.Key);
                var typeConstructor = type.Value.GetConstructor(new Type[] { typeof(TextWriter) });
                var typeObject = (IIndexConstituentsDiskWriter)typeConstructor.Invoke(new object[] { textWriter });
                _storage.OnEquityIndexUpdated(equityIndexFilename, new EquityIndexUpdated(typeObject.ReplaceAll));
            }
        }
    }
}
