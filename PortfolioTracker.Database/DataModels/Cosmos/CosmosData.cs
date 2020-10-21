using Newtonsoft.Json;
using System;
using Microsoft.Azure.Cosmos;

namespace PortfolioTracker.Database.DataModels
{
    public abstract class CosmosData
    {

        [JsonProperty("id")]
        public string Id
        {
            get { return pkId?.ToLowerInvariant(); }
            set { pkId = value; }
        }
        private string pkId;

        [Newtonsoft.Json.JsonIgnore]
        public virtual PartitionKey PartitionKey
        {
            get { return new PartitionKey(Id); }
        }
    }
}
