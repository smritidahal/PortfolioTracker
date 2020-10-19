using System;

namespace PortfolioTracker.ViewModels
{
    public class Quote
    {
        public double o { get; set; } //open
        public double h { get; set; } //high
        public double l { get; set; } //low
        public double c { get; set; } //current
        public double pc { get; set; } //previous close
    }
}
