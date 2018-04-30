using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.IndexesConstituents.Updater.Test
{
    public class IndexConstituentsDiskWriterForJSONFormatTest
    {
        [Fact]
        public void ReplaceAllTest()
        {
            //arrange
            var expectedJSONText = "[\n  {\n    \"StockExchange\": \"NYSE\",\n    \"Identifier\": \"AXP\"\n  },\n  {\n    \"StockExchange\": \"NYSE\",\n    \"Identifier\": \"MMM\"\n  }\n]";
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
            var equityStore = new IndexConstituentsDiskWriterForJSONFormat(writer);
            //act
            equityStore.ReplaceAll(IndexConstituents);
            var actualJSONText = writer.ToString();
            //assert
            Assert.Equal(expectedJSONText, actualJSONText);
        }
    }
}
