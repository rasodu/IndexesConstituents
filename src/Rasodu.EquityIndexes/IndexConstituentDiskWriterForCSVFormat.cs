using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.EquityIndexes
{
    internal class IndexConstituentDiskWriterForCSVFormat : IIndexConstituentDiskWriter
    {
        private TextWriter _destination;
        internal IndexConstituentDiskWriterForCSVFormat(TextWriter destination)
        {
            _destination = destination;
            _destination.NewLine = "\n";
        }
        public void ReplaceAll(List<Equity> equities)
        {
            var csv = new CsvWriter(_destination);
            csv.Configuration.Delimiter = ",";
            csv.WriteRecords<Equity>(equities);
            _destination.Flush();
        }
    }
}
