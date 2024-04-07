using Microsoft.Extensions.Configuration;
using ServicesAbstractions;
using System.Text.Json;

namespace Services
{
    public class FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : IFinnhubService
    {
        readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={configuration.GetSection("FinnhubAPI").GetValue<string>("AcessToken")}"),
                    Method = HttpMethod.Get
                };

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                var stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new(stream);
                string response = streamReader.ReadToEnd();
                var responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>?>(response);

                if (responseDictionary == null)
                    return null;
                if (responseDictionary.ContainsKey("error"))
                    return new Dictionary<string, object>()
                    {
                        { "error", responseDictionary["error"] }
                    };
                return responseDictionary;
            }
        }
    }
}
