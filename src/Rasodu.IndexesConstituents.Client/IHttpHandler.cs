using System.Net.Http;
using System.Threading.Tasks;
internal interface IHttpHandler
{
    Task<string> SendAndReadAsString(HttpRequestMessage request);
}
internal class HttpClientHandler : IHttpHandler
{
    private static readonly HttpClient _client = new HttpClient();
    public async Task<string> SendAndReadAsString(HttpRequestMessage request)
    {
        var response = await _client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}