using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioTracker.Database.DataModels;
using PortfolioTracker.Database.Services;

namespace PortfolioTracker.Database.Repositories
{
    public class PortfolioRepository : IRepository<Portfolio>
    {
        private readonly IDataService<Portfolio> _dbContext;

        public PortfolioRepository(IDataService<Portfolio> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Portfolio> AddUpdate(Portfolio portfolio)
        {
            var response = await _dbContext.AddUpdateAsync(portfolio);
            return response;
        }

        public async Task<Portfolio> GetItem(string id)
        {
            return await _dbContext.GetItemAsync(id);
        }

        public async Task<IEnumerable<Portfolio>> GetList()
        {
            return await _dbContext.GetItemsAsync("select * from c");
        }

        public async Task Delete(string id)
        {
            var data = GetItem(id);
            if (data != null)
            {
                await _dbContext.DeleteItemAsync(id.ToString());
            }
        }
    }
}
