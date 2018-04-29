using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexConstituentDiskWriterFactory
    {
        internal IIndexConstituentDiskWriter GetCSVDiskWriter(string equityIndex)
        {
            IIndexConstituentDiskWriter destination = null;
            if (equityIndex == "DowJones30")
            {
                destination = new IndexConstituentDiskWriterForCSVFormat(
                    GetTextWriterForExistingFileInTree("Data/CSV/DowJones30.csv")
                );
            }
            else if (equityIndex == "SP500")
            {
                destination = new IndexConstituentDiskWriterForCSVFormat(
                    GetTextWriterForExistingFileInTree("Data/CSV/SP500.csv")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                destination = new IndexConstituentDiskWriterForCSVFormat(
                    GetTextWriterForExistingFileInTree("Data/CSV/Nifty100.csv")
                );
            }
            return destination;
        }
        internal IIndexConstituentDiskWriter GetJSONDiskWriter(string equityIndex)
        {
            IIndexConstituentDiskWriter destination = null;
            if (equityIndex == "DowJones30")
            {
                destination = new IndexConstituentDiskWriterForJSONFormat(
                    GetTextWriterForExistingFileInTree("Data/JSON/DowJones30.json")
                );
            }
            else if (equityIndex == "SP500")
            {
                destination = new IndexConstituentDiskWriterForJSONFormat(
                    GetTextWriterForExistingFileInTree("Data/JSON/SP500.json")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                destination = new IndexConstituentDiskWriterForJSONFormat(
                    GetTextWriterForExistingFileInTree("Data/JSON/Nifty100.json")
                );
            }
            return destination;
        }
        private TextWriter GetTextWriterForExistingFileInTree(string fileName)
        {
            var parentDir = "../";
            for (var baseDir = parentDir; Directory.Exists(baseDir); baseDir += parentDir)
            {
                var filePath = baseDir + fileName;
                if (File.Exists(filePath))
                {
                    return GetTextWriterForFile(filePath);
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
