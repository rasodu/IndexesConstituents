using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rasodu.IndexesConstituents.Client
{
    public class IndexesConstituentsClient
    {
        private static IHttpHandler _client = new HttpClientHandler();
        private static ConstituentParser _parser = new ConstituentParser();
        public IndexesConstituentsClient() { }
        internal IndexesConstituentsClient(IHttpHandler client, ConstituentParser parser)
        {
            _client = client;
            _parser = parser;
        }
        public virtual async Task<IEnumerable<Constituent>> GetConstituents(Index exchange)
        {
            var request = ComposeHttpRequest(exchange);
            var json = await _client.SendAndReadAsString(request);
            return _parser.ParseConstituent(json);
        }
        private HttpRequestMessage ComposeHttpRequest(Index exchange)
        {
            var uriString = Constants.JsonDir + "/" + exchange.ToString() + ".json";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uriString),
                Method = HttpMethod.Get,
            };
            return request;
        }
    }
}