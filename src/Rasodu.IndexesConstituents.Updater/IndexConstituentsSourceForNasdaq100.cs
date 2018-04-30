using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Rasodu.IndexesConstituents.Updater
{
    public class Nasdaq100Entry
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string lastsale { get; set; }
        public string netchange { get; set; }
        public string pctchange { get; set; }
        public string share_volume { get; set; }
        public string Nasdaq100_points { get; set; }
    }
    class IndexConstituentsSourceForNasdaq100 : IIndexConstituentsSource
    {
        private TextReader _csvTextReader;
        public IndexConstituentsSourceForNasdaq100()
        {
            _csvTextReader = Helper.UrlToTextReader("https://www.nasdaq.com/quotes/nasdaq-100-stocks.aspx?render=download");
        }
        public IndexConstituentsSourceForNasdaq100(TextReader csvTextReader)
        {
            _csvTextReader = csvTextReader;
        }
        public List<Equity> GetAllEquities()
        {
            var returnEquityList = new List<Equity>();
            var csvHelperReader = new CsvReader(_csvTextReader);
            csvHelperReader.Configuration.HasHeaderRecord = true;
            csvHelperReader.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "");
            var recordList = csvHelperReader.GetRecords<Nasdaq100Entry>();
            foreach (var record in recordList)
            {
                var equity = new Equity
                {
                    StockExchange = "NASDAQ",
                    Identifier = record.Symbol,
                };
                returnEquityList.Add(equity);
            }
            returnEquityList.Sort();
            return returnEquityList;
        }
        public string IndexName()
        {
            return "Nasdaq100";
        }
    }
}
