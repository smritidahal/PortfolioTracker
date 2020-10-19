using Newtonsoft.Json;

namespace PortfolioTracker.Database.DataModels
{
    public class Equity : CosmosData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("equityType")]
        public EquityType EquityType { get; set; }

        [JsonProperty("quantity")]
        public float Quantity { get; set; }

        [JsonProperty("costPerShare")]
        public double CostPerShare { get; set; }

        [JsonProperty("currentPrice")]
        public double CurrentPrice { get; set; }

        [JsonProperty("sellPrice")]
        public float SellPrice { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("isSold")]
        public bool IsSold { get; set; }

        [JsonProperty("portfolioName")]
        public string PortfolioName { get; set; }
    }
}
