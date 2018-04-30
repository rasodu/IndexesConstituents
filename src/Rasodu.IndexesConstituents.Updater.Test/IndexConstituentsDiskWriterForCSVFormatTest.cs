using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.IndexesConstituents.Updater.Test
{
    public class IndexConstituentsDiskWriterForCSVFormatTest
    {
        [Fact]
        public void ReplaceAllTest()
        {
            //arrange
            var expectedCSVText = "StockExchange,Identifier\nNYSE,AXP\nNYSE,MMM\n";
            var IndexConstituents = new List<Equity>()
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
            var equityStore = new IndexConstituentsDiskWriterForCSVFormat(writer);
            //act
            equityStore.ReplaceAll(IndexConstituents);
            var actualCSVText = writer.ToString();
            //assert
            Assert.Equal(expectedCSVText, actualCSVText);
        }
    }
}
