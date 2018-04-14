using System.IO;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexStoreFactory
    {
        internal IEquityIndexStore GetStore(string equityIndex)
        {
            IEquityIndexStore destination = null;
            if (equityIndex == "DowJones30")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForFileInTree("CSV/DowJones30.csv")
                );
            }
            else if (equityIndex == "SP500")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForFileInTree("CSV/SP500.csv")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForFileInTree("CSV/Nifty100.csv")
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
