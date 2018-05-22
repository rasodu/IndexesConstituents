using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Rasodu.IndexesConstituents.Client.Test
{
    public class IndexesConstituentsClientTest
    {
        [Fact]
        public void GetConstituentsTest()
        {
            //arrange
            IEnumerable<Constituent> expectedConstituentList = new List<Constituent>(){
                new Constituent{
                    StockExchange = "NASDAQ",
                    Identifier = "AAPL",
                },
            };
            var json = "Sample json response";
            var expectedUriString = "https://raw.githubusercontent.com/rasodu/IndexesConstituents/master/Data/JSON/DowJones30.json";
            var client = new Mock<IHttpHandler>();
            client.Setup(c => c.SendAndReadAsString(It.IsAny<HttpRequestMessage>())).ReturnsAsync(json);
            var parser = new Mock<ConstituentParser>();
            parser.Setup(p => p.ParseConstituent(json)).Returns(expectedConstituentList);
            var indexClient = new IndexesConstituentsClient(client.Object, parser.Object);
            //act
            var result = indexClient.GetConstituents(Index.DowJones30).GetAwaiter().GetResult();
            //assert
            client.Verify(c => c.SendAndReadAsString(It.Is<HttpRequestMessage>(r => r.RequestUri.AbsoluteUri == expectedUriString)), Times.Once());
            parser.Verify(p => p.ParseConstituent(It.Is<string>(str => str == json)), Times.Once());
            Assert.Equal(expectedConstituentList, result);
        }
    }
}