using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.EquityIndexes.Test
{
    public class CSVEquityIndexStoreTest
    {
        [Fact]
        public void ReplaceAllTest()
        {
            //arrange
            var expectedCSVText = "StockExchange,Identifier\nNYSE,AXP\nNYSE,MMM\n";
            var expextedEquityList = new List<Equity>()
            {
                new Equity
                {
                    StockExchange = "NYSE",
                    Identifier = "AXP",
                },
                new Equity
                {
                    StockExchange = "NYSE",
                    Identifier = "MMM",
                }
            };
            TextWriter writer = new StringWriter();
            writer.NewLine = "\n";
            var equityStore = new CSVEquityIndexStore(writer);
            //act
            equityStore.ReplaceAll(expextedEquityList);
            var actualCSVText = writer.ToString();
            //assert
            Assert.Equal(expectedCSVText, actualCSVText);
        }
    }
}
