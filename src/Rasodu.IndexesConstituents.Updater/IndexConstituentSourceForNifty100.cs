using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    class Nifty100Entry
    {
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Symbol { get; set; }
        public string Series { get; set; }
        public string ISINCode { get; set; }
    }
    public class IndexConstituentSourceForNifty100 : IIndexConstituentSource
    {
        private TextReader _csvTextReader;
        public IndexConstituentSourceForNifty100()
        {
            _csvTextReader = Helper.UrlToTextReader("https://www.nseindia.com/content/indices/ind_nifty100list.csv");
        }
        public IndexConstituentSourceForNifty100(TextReader csvTextReader)
        {
            _csvTextReader = csvTextReader;
        }
        public string IndexName()
        {
            return "Nifty100";
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
