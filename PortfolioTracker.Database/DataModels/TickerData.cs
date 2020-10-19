﻿using Newtonsoft.Json;
using System;

namespace PortfolioTracker.Database.DataModels
{
    public class TickerData : CosmosData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

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
    }
}
