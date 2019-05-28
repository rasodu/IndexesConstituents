using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Rasodu.IndexesConstituents.Updater
{
    public class IndexConstituentsSourceForDJ30 : IIndexConstituentsSource
    {
        private TextReader _wikiPage;

        public IndexConstituentsSourceForDJ30()
        {
            _wikiPage = Helper.UrlToTextReader("https://en.wikipedia.org/wiki/Dow_Jones_Industrial_Average");
        }
        public IndexConstituentsSourceForDJ30(TextReader wikiPage)
        {
            _wikiPage = wikiPage;
        }
        public string IndexName()
        {
            return "DowJones30";
        }
        public List<Equity> GetAllEquities()
        {
            var returnList = new List<Equity>();
            var str = _wikiPage.ReadToEnd();
            var splitedString = str.Split(@"<table class=""wikitable sortable"" id=""constituents"">");
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
                    if (cells.Count == 4)
                    {
                        var equity = new Equity
                        {
                            StockExchange = cells[1].Groups[2].Value,
                            Identifier = cells[2].Groups[2].Value,
                        };
                        returnList.Add(equity);
                    }
                }
            }
            returnList.Sort();
            return returnList;
        }
    }
}
