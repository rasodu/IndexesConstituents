using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.IndexesConstituents.Updater.Test
{
    public class IndexConstituentSourceForNifty100Test
    {
        [Fact]
        public void GetAllEquitiesTest()
        {
            //arrange
            var expectedEquityList = new List<Equity>
            {
                new Equity
                {
                    StockExchange = "NSE",
                    Identifier = "ABB",
                },
                new Equity
                {
                    StockExchange = "NSE",
                    Identifier = "ACC",
                },
            };
            var csvContent = @"
Company Name,Industry,Symbol,Series,ISIN Code
ACC Ltd.,CEMENT & CEMENT PRODUCTS,ACC,EQ,INE012A01025
ABB India Ltd.,INDUSTRIAL MANUFACTURING,ABB,EQ,INE117A01022
";
            TextReader csvTextReader = new StringReader(csvContent);
            var nify100Source = new IndexConstituentSourceForNifty100(csvTextReader);
            //act
            var actualEquityList = nify100Source.GetAllEquities();
            //assert
            Assert.Equal(expectedEquityList, actualEquityList);
        }
    }
}
