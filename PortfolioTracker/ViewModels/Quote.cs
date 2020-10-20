using System;

namespace PortfolioTracker.ViewModels
{
    public class Quote
    {
        public double O { get; set; } //open
        public double H { get; set; } //high
        public double L { get; set; } //low
        public double C { get; set; } //current
        public double Pc { get; set; } //previous close
    }
}
