using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    internal class IndexConstituentsDiskWriterForCSVFormat : IIndexConstituentsDiskWriter
    {
        private TextWriter _destination;
        public IndexConstituentsDiskWriterForCSVFormat(TextWriter destination)
        {
            _destination = destination;
        }
        public string FileExtension()
        {
            return "csv";
        }
        public void ReplaceAll(List<Equity> equities)
        {
            _destination.NewLine = "\n";
            var csv = new CsvWriter(_destination);
            csv.Configuration.Delimiter = ",";
            csv.WriteRecords<Equity>(equities);
            _destination.Flush();
        }
    }
}
