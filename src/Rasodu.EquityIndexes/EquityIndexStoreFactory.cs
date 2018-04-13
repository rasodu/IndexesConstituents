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
                    GetTextWriterForSolutionFile("CSV/DowJones30.csv")
                );
            }
            else if (equityIndex == "SP500")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForSolutionFile("CSV/SP500.csv")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                destination = new CSVEquityIndexStore(
                    GetTextWriterForSolutionFile("CSV/Nifty100.csv")
                );
            }
            return destination;
        }
        private TextWriter GetTextWriterForSolutionFile(string relativePath)
        {
            var fullPath = Path.GetFullPath("../../../../../" + relativePath);
            TextWriter writer = File.CreateText(fullPath);
            return writer;
        }
    }
}
