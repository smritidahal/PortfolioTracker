using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioTracker.ViewModels;

namespace PortfolioTracker.Services
{
    public interface IStockDataService
    {
        public Task<Quote> GetStockDataAsync(string ticker);
    }
}
