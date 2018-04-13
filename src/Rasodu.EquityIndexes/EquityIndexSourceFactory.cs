using System;
using System.IO;
using System.Net.Http;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexSourceFactory
    {
        static HttpClient client = new HttpClient();
        internal IEquityIndexSource GetSource(string equityIndex)
        {
            IEquityIndexSource source = null;
            if (equityIndex == "DowJones30")
            {
                var wikiPage = new Uri("https://en.wikipedia.org/wiki/Dow_Jones_Industrial_Average");
                var wikiPageStream = client.GetAsync(wikiPage).GetAwaiter().GetResult().Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                TextReader wikiPageReader = new StreamReader(wikiPageStream);
                source = new DJ30EquityIndexSource(wikiPageReader);
            }
            else if (equityIndex == "SP500")
            {
                var wikiPage = new Uri("https://en.wikipedia.org/wiki/List_of_S%26P_500_companies");
                var wikiPageStream = client.GetAsync(wikiPage).GetAwaiter().GetResult().Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                TextReader wikiPageReader = new StreamReader(wikiPageStream);
                source = new WikiSP500EquityIndexSource(wikiPageReader);
            }
            return source;
        }
    }
}
