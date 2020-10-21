using System;

namespace PortfolioTracker.ViewModels
{
    public class CompanyProfile
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Exchange { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }        
        public DateTime Ipo { get; set; }
        public double MarketCapitalization { get; set; }
        public string WebUrl { get; set; }
        public string FinnhubIndustry { get; set; }
    }
}
