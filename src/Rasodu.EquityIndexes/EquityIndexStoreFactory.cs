using System.IO;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexStoreFactory
    {
        internal IEquityIndexStore GetStore(string equityIndex)
        {
            IEquityIndexStore destination = null;
            if(equityIndex == "SP500")
            {
                var fullPath = GetAbsolutePathFromSolutionRoot("CSV/SP500.csv");
                TextWriter writer = File.CreateText(fullPath);
                destination = new CSVEquityIndexStore(writer);
            }
            return destination;
        }
        private string GetAbsolutePathFromSolutionRoot(string relativePath)
        {
            return Path.GetFullPath("../../../../../" + relativePath);
        }
    }
}
