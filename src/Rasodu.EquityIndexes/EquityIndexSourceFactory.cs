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
            if (equityIndex == "SP500")
            {
                var wikiPage = new Uri("https://en.wikipedia.org/wiki/List_of_S%26P_500_companies");
                var wikiPageStream = client.GetAsync(wikiPage).GetAwaiter().GetResult().Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                TextReader wikiPageReader = new StreamReader(wikiPageStream);
                source = new WikiStockIndexSource(wikiPageReader);
            }
            return source;
        }
    }
}
