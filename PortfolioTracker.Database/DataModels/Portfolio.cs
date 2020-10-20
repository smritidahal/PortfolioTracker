using Newtonsoft.Json;
using System.Collections.Generic;

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

        [JsonProperty("holdings")]
        public IList<Equity> Holdings { get; set; }
    }
}
