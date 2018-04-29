using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Rasodu.EquityIndexes.Test
{
    public class IndexConstituentSourceForSP500Tests
    {
        [Fact]
        public void GetAllEquitiesTest()
        {
            //arrange
            var expectedWikipage = @"
more text here-->
<table class=""wikitable sortable"">
<tr>
<th><a href=""/wiki/Ticker_symbol"" title=""Ticker symbol"">Ticker symbol</a></th>
<th>Security</th>
<th><a href=""/wiki/SEC_filing"" title=""SEC filing"">SEC filings</a></th>
<th><a href=""/wiki/Global_Industry_Classification_Standard"" title=""Global Industry Classification Standard"">GICS</a> Sector</th>
<th>GICS Sub Industry</th>
<th>Address of Headquarters</th>
<th>Date first added<sup id=""cite_ref-3"" class=""reference""><a href=""#cite_note-3"">[3]</a></sup><sup id=""cite_ref-4"" class=""reference""><a href=""#cite_note-4"">[4]</a></sup></th>
<th><a href=""/wiki/Central_Index_Key"" title=""Central Index Key"">CIK</a></th>
</tr>
<tr>
<td><a rel=""nofollow"" class=""external text"" href=""https://www.nyse.com/quote/XNYS:MMM"">MMM</a></td>
<td><a href=""/wiki/3M"" title=""3M"">3M Company</a></td>
<td><a rel=""nofollow"" class=""external text"" href=""https://www.sec.gov/cgi-bin/browse-edgar?CIK=MMM&amp;action=getcompany"">reports</a></td>
<td>Industrials</td>
<td>Industrial Conglomerates</td>
<td><a href=""/wiki/St._Paul,_Minnesota"" class=""mw-redirect"" title=""St. Paul, Minnesota"">St. Paul, Minnesota</a></td>
<td></td>
<td>0000066740</td>
</tr>
<tr>
<td><a rel=""nofollow"" class=""external text"" href=""https://www.nyse.com/quote/XNYS:ABT"">ABT</a></td>
<td><a href=""/wiki/Abbott_Laboratories"" title=""Abbott Laboratories"">Abbott Laboratories</a></td>
<td><a rel=""nofollow"" class=""external text"" href=""https://www.sec.gov/cgi-bin/browse-edgar?CIK=ABT&amp;action=getcompany"">reports</a></td>
<td>Health Care</td>
<td>Health Care Equipment</td>
<td><a href=""/wiki/North_Chicago,_Illinois"" title=""North Chicago, Illinois"">North Chicago, Illinois</a></td>
<td>1964-03-31</td>
<td>0000001800</td>
</tr>
</table>
<--more text here
";
            TextReader reader = new StringReader(expectedWikipage);
            IIndexConstituentSource wiki = new IndexConstituentSourceForSP500(reader);
            var expectedEquityList = new List<Equity>()
            {
                new Equity
                {
                    StockExchange = "NYSE",
                    Identifier = "ABT",
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
