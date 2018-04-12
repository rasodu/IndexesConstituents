using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Rasodu.EquityIndexes
{
    internal class WikiSP500EquityIndexSource : IEquityIndexSource
    {
        private TextReader _wikiPage;
        internal WikiSP500EquityIndexSource(TextReader wikiPage)
        {
            _wikiPage = wikiPage;
        }
        public List<Equity> GetAllEquities()
        {
            var returnList = new List<Equity>();
            var str = _wikiPage.ReadToEnd();
            var splitedString = str.Split(@"<table class=""wikitable sortable"">");
            if (splitedString.Length < 2)
            {
                return returnList;
            }
            str = splitedString[1];
            splitedString = str.Split("</table>");
            if (splitedString.Length < 2)
            {
                return returnList;
            }
            str = splitedString[0];
            str = str.Replace("\n", "");
            str = str.Replace("\r", "");
            str = str.Replace(" ", "");
            String rowPattern = @"<tr>(.*?)</tr>";
            String cellPattern = @"<td><a(.*?)>(.*?)</a></td>";
            foreach (Match m in Regex.Matches(str, rowPattern))
            {
                if (m.Groups.Count == 2)
                {
                    var cells = Regex.Matches(m.Groups[1].Value, cellPattern);
                    if (cells.Count >= 1)
                    {
                        var equity = new Equity
                        {
                            StockExchange = FindExchangeFromString(cells[0].Groups[1].Value),
                            Identifier = cells[0].Groups[2].Value,
                        };
                        returnList.Add(equity);
                    }
                }
            }
            returnList.Sort();
            return returnList;
        }
        private string FindExchangeFromString(string str)
        {
            str = str.ToLower();
            if (str.Contains("nyse"))
            {
                return "NYSE";
            }
            else if (str.Contains("nasdaq"))
            {
                return "NASDAQ";
            }
            return "UNKNOWN";
        }
    }
}
