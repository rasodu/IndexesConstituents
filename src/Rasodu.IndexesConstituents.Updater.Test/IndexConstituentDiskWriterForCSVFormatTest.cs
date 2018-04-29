using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.IndexesConstituents.Updater.Test
{
    public class IndexConstituentDiskWriterForCSVFormatTest
    {
        [Fact]
        public void ReplaceAllTest()
        {
            //arrange
            var expectedCSVText = "StockExchange,Identifier\nNYSE,AXP\nNYSE,MMM\n";
            var expectedEquityList = new List<Equity>()
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
            var equityStore = new IndexConstituentDiskWriterForCSVFormat(writer);
            //act
            equityStore.ReplaceAll(expectedEquityList);
            var actualCSVText = writer.ToString();
            //assert
            Assert.Equal(expectedCSVText, actualCSVText);
        }
    }
}
