using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.IndexesConstituents.Updater.Test
{
    public class IndexConstituentsSourceForNasdaq100Test
    {
        [Fact]
        public void GetAllEquitiesTest()
        {
            //arrange
            var expectedConstituents = new List<Equity>
            {
                new Equity
                {
                    StockExchange = "NASDAQ",
                    Identifier = "ADBE",
                },
                new Equity
                {
                    StockExchange = "NASDAQ",
                    Identifier = "ATVI",
                },
            };
            var csvContent = @"
Symbol, Name, lastsale, netchange,pctchange, share_volume, Nasdaq100_points,
ATVI, Activision Blizzard Inc, 66.35, 0.56,0.85, 5039691, .4,
ADBE, Adobe Systems Incorporated, 221.6, -0.3,-0.14, 1761740, -.1,
";
            TextReader csvTextReader = new StringReader(csvContent);
            var nify100Source = new IndexConstituentsSourceForNasdaq100(csvTextReader);
            //act
            var actualEquityList = nify100Source.GetAllEquities();
            //assert
            Assert.Equal(expectedConstituents, actualEquityList);
        }
    }
}
