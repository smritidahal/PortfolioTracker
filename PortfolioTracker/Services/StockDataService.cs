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

        public async Task<CompanyProfile> GetCompanyProfile(string ticker)
        {
            var compInfo = new CompanyProfile();
            var requestUri = $"stock/profile2?symbol={ticker}&token={token}";
            var httpResponseMessage = await httpClient.GetAsync(requestUri);
            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                compInfo = JsonConvert.DeserializeObject<CompanyProfile>(responseBody);
            }
            return compInfo;
        }

        public async Task<EquityInfo> GetEquityInfo(string ticker)
        {
            var q = await GetQuote(ticker);
            var c = await GetCompanyProfile(ticker);
            return new EquityInfo() { CurrentPrice = q.C, Industry = c.FinnhubIndustry, Name = c.Name };
        }

        public async Task<Quote> GetQuote(string ticker)
        {
            var stockInfo = new Quote();
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
