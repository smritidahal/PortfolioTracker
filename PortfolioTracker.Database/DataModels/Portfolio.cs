using Newtonsoft.Json;
namespace PortfolioTracker.Database.DataModels
{
    public class Portfolio : CosmosData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("totalValue")]
        public double TotalValue { get; set; }

        [JsonProperty("netValue")]
        public double NetValue { get; set; }
    }
}
