using System;
using System.Collections.Generic;
using Xunit;

namespace Rasodu.IndexesConstituents.Client.Test
{
    public class ConstituentParserTest
    {
        [Fact]
        public void ParseConstituentTest()
        {
            //arrange
            var parser = new ConstituentParser();
            var inputJson = "[{\"StockExchange\": \"NASDAQ\",\"Identifier\": \"AAPL\"},{\"StockExchange\": \"NASDAQ\",\"Identifier\": \"CSCO\"}]";
            IEnumerable<Constituent> expectedOutput = new List<Constituent>()
            {
                new Constituent{
                    StockExchange = "NASDAQ",
                    Identifier = "AAPL",
                },
                new Constituent{
                    StockExchange = "NASDAQ",
                    Identifier = "CSCO",
                },
            };
            //act
            var actualOutput = parser.ParseConstituent(inputJson);
            //assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void ParseConstituentTestIncorrectJson()
        {
            //arrange
            var parser = new ConstituentParser();
            var malformedJson = "[{\"IncorrectIndex\": \"NASDAQ\",\"Identifier\": \"AAPL\"}]";
            //act
            var exception = Assert.Throws<IndexConstituentClientException>(() => parser.ParseConstituent(malformedJson));
            //assert
            Assert.Equal("Problem while parsing JSON string", exception.Message);
        }
    }
}
