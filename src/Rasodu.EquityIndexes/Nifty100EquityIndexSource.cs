using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.EquityIndexes
{
    class Nifty100Entry
    {
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Symbol { get; set; }
        public string Series { get; set; }
        public string ISINCode { get; set; }
    }
    class Nifty100EquityIndexSource : IEquityIndexSource
    {
        private TextReader _csvTextReader;
        public Nifty100EquityIndexSource(TextReader csvTextReader)
        {
            _csvTextReader = csvTextReader;
            //var text = _csvTextReader.ReadToEnd();
        }
        public List<Equity> GetAllEquities()
        {
            var returnEquityList = new List<Equity>();
            var csvHelperReader = new CsvReader(_csvTextReader);
            csvHelperReader.Configuration.HasHeaderRecord = true;
            csvHelperReader.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "");
            var recordList = csvHelperReader.GetRecords<Nifty100Entry>();
            foreach (var record in recordList)
            {
                var equity = new Equity
                {
                    StockExchange = "NSE",
                    Identifier = record.Symbol,
                };
                returnEquityList.Add(equity);
            }
            returnEquityList.Sort();
            return returnEquityList;
        }
    }
}
