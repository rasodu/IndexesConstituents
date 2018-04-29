using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Rasodu.EquityIndexes.Test
{
    public class IndexConstituentSourceForDJ30Test
    {
        [Fact]
        public void GetAllEquities()
        {
            //arrange
            var expectedWikipage = @"
more text here-->
<table class=""wikitable sortable"">
<tr>
<th>Company</th>
<th>Exchange</th>
<th>Symbol</th>
<th>Industry</th>
<th>Date Added</th>
<th>Notes</th>
</tr>
<tr>
<td><a href=""/wiki/3M"" title=""3M"">3M</a></td>
<td><a href=""/wiki/New_York_Stock_Exchange"" title=""New York Stock Exchange"">NYSE</a></td>
<td><a rel=""nofollow"" class=""external text"" href=""https://www.nyse.com/quote/XNYS:MMM"">MMM</a></td>
<td><a href=""/wiki/Conglomerate_(company)"" title=""Conglomerate (company)"">Conglomerate</a></td>
<td>1976-08-09</td>
<td>as Minnesota Mining and Manufacturing</td>
</tr>
<tr>
<td><a href=""/wiki/American_Express"" title=""American Express"">American Express</a></td>
<td><a href=""/wiki/New_York_Stock_Exchange"" title=""New York Stock Exchange"">NYSE</a></td>
<td><a rel=""nofollow"" class=""external text"" href=""https://www.nyse.com/quote/XNYS:AXP"">AXP</a></td>
<td><a href=""/wiki/Consumer_finance"" class=""mw-redirect"" title=""Consumer finance"">Consumer finance</a></td>
<td>1982-08-30</td>
<td></td>
</tr>
</table>
<--more text here
";
            TextReader reader = new StringReader(expectedWikipage);
            IIndexConstituentSource wiki = new IndexConstituentSourceForDJ30(reader);
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
            //act
            var actualEquityList = wiki.GetAllEquities();
            //assert
            Assert.Equal(expectedEquityList, actualEquityList);
        }
    }
}
