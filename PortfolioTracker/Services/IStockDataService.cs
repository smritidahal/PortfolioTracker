using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioTracker.ViewModels;

namespace PortfolioTracker.Services
{
    public interface IStockDataService
    {
        public Task<Quote> GetQuote(string ticker);
        public Task<CompanyProfile> GetCompanyProfile (string ticker);
        public Task<EquityInfo> GetEquityInfo(string ticker);
    }
}
