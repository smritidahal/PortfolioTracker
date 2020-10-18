using System;

namespace PortfolioTracker.Data
{
    public class StockData
    {
        public string CompName { get; set; }
        public string Ticker { get; set; }
        public float NumShares { get; set; }
        public float CurrentPrice { get; set; }
        public float BuyPrice { get; set; }
        public float SellPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
    }
}
