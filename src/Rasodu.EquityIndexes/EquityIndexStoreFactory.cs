using System.IO;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexStoreFactory
    {
        internal IEquityIndexStore GetCSVStore(string equityIndex)
        {
            IEquityIndexStore destination = null;
            if (equityIndex == "DowJones30")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForFileInTree("Data/CSV/DowJones30.csv")
                );
            }
            else if (equityIndex == "SP500")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForFileInTree("Data/CSV/SP500.csv")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForFileInTree("Data/CSV/Nifty100.csv")
                );
            }
            return destination;
        }
        internal IEquityIndexStore GetJSONStore(string equityIndex)
        {
            IEquityIndexStore destination = null;
            if (equityIndex == "DowJones30")
            {
                destination = new JSONEquityIndexStore(
                    GetTextWriterForFileInTree("Data/JSON/DowJones30.json")
                );
            }
            else if (equityIndex == "SP500")
            {
                destination = new JSONEquityIndexStore(
                    GetTextWriterForFileInTree("Data/JSON/SP500.json")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                destination = new JSONEquityIndexStore(
                    GetTextWriterForFileInTree("Data/JSON/Nifty100.json")
                );
            }
            return destination;
        }
        private TextWriter GetTextWriterForFileInTree(string filename)
        {
            var parentDir = "../";
            for (var baseDir = parentDir; Directory.Exists(baseDir); baseDir += parentDir)
            {
                var filePath = baseDir + filename;
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
