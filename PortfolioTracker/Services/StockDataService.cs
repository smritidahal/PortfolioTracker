using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PortfolioTracker.ViewModels;

namespace PortfolioTracker.Services
{
    public class StockDataService : IStockDataService
    {
        private const string token = "bu5oiaf48v6qku349ve0";
        private readonly HttpClient httpClient;

        public StockDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Quote> GetStockDataAsync(string ticker)
        {
            var stockInfo = new Quote();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var requestUri = $"quote?symbol={ticker}&token={token}";
            var httpResponseMessage = await httpClient.GetAsync(requestUri);
            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            if(httpResponseMessage.IsSuccessStatusCode)
            {
                stockInfo = JsonConvert.DeserializeObject<Quote>(responseBody);
            }
            return stockInfo;
        }
    }
}
