using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexConstituentsDiskWriterForCSVFormat : IIndexConstituentsDiskWriter
    {
        private TextWriter _destination;
        internal IndexConstituentsDiskWriterForCSVFormat(TextWriter destination)
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
