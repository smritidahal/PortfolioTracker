using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PortfolioTracker.Database.DataModels
{
    public class Portfolio : CosmosData
    {
        [JsonProperty("name")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Portfolios Name { get; set; }

        [JsonProperty("totalValue")]
        public double TotalValue { get; set; }

        [JsonProperty("netValue")]
        public double NetValue { get; set; }
    }
}
