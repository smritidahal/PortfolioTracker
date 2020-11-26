using Newtonsoft.Json;

namespace PortfolioTracker.Database.DataModels
{
    public class Equity
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

        [JsonProperty("totalCost")]
        public double TotalCost { get; set; }

        [JsonProperty("marketValue")]
        public double MarketValue { get; set; }

        [JsonProperty("gainLoss")]
        public double GainLoss { get; set; }

        [JsonProperty("PortfolioDiversity")]
        public double PortfolioDiversity { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }
    }
}
