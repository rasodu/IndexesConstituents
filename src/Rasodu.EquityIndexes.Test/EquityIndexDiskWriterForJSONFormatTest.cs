using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.EquityIndexes.Test
{
    public class EquityIndexDiskWriterForJSONFormatTest
    {
        [Fact]
        public void ReplaceAllTest()
        {
            //arrange
            var expectedJSONText = "[\n  {\n    \"StockExchange\": \"NYSE\",\n    \"Identifier\": \"AXP\"\n  },\n  {\n    \"StockExchange\": \"NYSE\",\n    \"Identifier\": \"MMM\"\n  }\n]";
            var equityList = new List<Equity>()
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
            var equityStore = new EquityIndexDiskWriterForJSONFormat(writer);
            //act
            equityStore.ReplaceAll(equityList);
            var actualJSONText = writer.ToString();
            //assert
            Assert.Equal(expectedJSONText, actualJSONText);
        }
    }
}
