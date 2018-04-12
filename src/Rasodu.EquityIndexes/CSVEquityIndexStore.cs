using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.EquityIndexes
{
    internal class CSVEquityIndexStore : IEquityIndexStore
    {
        private TextWriter _destination;
        internal CSVEquityIndexStore(TextWriter destination)
        {
            _destination = destination;
        }
        public void ReplaceAll(List<Equity> equities)
        {
            var csv = new CsvWriter(_destination);
            csv.Configuration.Delimiter = ",";
            //csv.WriteHeader<Equity>();
            csv.WriteRecords<Equity>(equities);
            //csv.WriteRecords(equities);
            _destination.Flush();
        }
    }
}
