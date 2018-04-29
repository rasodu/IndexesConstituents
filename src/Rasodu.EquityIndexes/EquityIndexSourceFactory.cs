using System;
using System.IO;
using System.Net.Http;

namespace Rasodu.EquityIndexes
{
    internal class EquityIndexSourceFactory
    {
        private HttpClient _client;
        public EquityIndexSourceFactory()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "curl/7.53.0");
        }
        internal IEquityIndexSource GetEquityIndexSource(string equityIndex)
        {
            IEquityIndexSource source = null;
            if (equityIndex == "DowJones30")
            {
                source = new EquityIndexSourceForDJ30(
                    UrlToTextReader("https://en.wikipedia.org/wiki/Dow_Jones_Industrial_Average")
                );
            }
            else if (equityIndex == "SP500")
            {
                source = new EquityIndexSourceForSP500(
                    UrlToTextReader("https://en.wikipedia.org/wiki/List_of_S%26P_500_companies")
                );
            }
            else if (equityIndex == "Nifty100")
            {
                source = new EquityIndexSourceForNifty100(
                    UrlToTextReader("https://www.nseindia.com/content/indices/ind_nifty100list.csv")
                );
            }
            return source;
        }
        private TextReader UrlToTextReader(string url)
        {
            var uri = new Uri(url);
            var uriStream = _client.GetAsync(uri).GetAwaiter().GetResult().Content.ReadAsStreamAsync().GetAwaiter().GetResult();
            TextReader uriReader = new StreamReader(uriStream);
            return uriReader;
        }
    }
}
