using System;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexConstituentsDiskWriterFactory
    {
        internal IIndexConstituentsDiskWriter GetCSVDiskWriter(string equityIndex)
        {
            if (equityIndex == null) throw new ArgumentNullException(nameof(equityIndex) + " can't be null.");
            var textWriter = GetTextWriterForExistingFileInTree("CSV/" + equityIndex + ".csv");
            var csvDiskWriter = new IndexConstituentsDiskWriterForCSVFormat(textWriter);
            return csvDiskWriter;
        }
        internal IIndexConstituentsDiskWriter GetJSONDiskWriter(string equityIndex)
        {
            if (equityIndex == null) throw new ArgumentNullException(nameof(equityIndex) + " can't be null.");
            var textWriter = GetTextWriterForExistingFileInTree("JSON/" + equityIndex + ".json");
            var jsonDiskWriter = new IndexConstituentsDiskWriterForJSONFormat(textWriter);
            return jsonDiskWriter;
        }
        private TextWriter GetTextWriterForExistingFileInTree(string fileName)
        {
            var parentDir = "../";
            for (var baseDir = parentDir; Directory.Exists(baseDir); baseDir += parentDir)
            {
                var dataDir = baseDir + "Data/";
                if (File.Exists(dataDir + "README.md"))
                {
                    var destinationFile = dataDir + fileName;
                    return GetTextWriterForFile(destinationFile);
                }
            }
            return null;
        }
        private TextWriter GetTextWriterForFile(string relativeFilePath)
        {
            var fullPath = Path.GetFullPath(relativeFilePath);
            TextWriter writer = File.CreateText(fullPath);
            return writer;
        }
    }
}
