using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioTracker.Database.DataModels;
using PortfolioTracker.Database.Services;

namespace PortfolioTracker.Database.Repositories
{
    public class EquityRepository : IRepository<Equity>
    {
        private readonly IDataService<Equity> _dbContext;

        public EquityRepository(IDataService<Equity> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Equity> AddUpdate(Equity stock)
        {
            var response = await _dbContext.AddUpdateAsync(stock);
            return response;
        }

        public async Task<Equity> GetItem(string id)
        {
            return await _dbContext.GetItemAsync(id);
        }

        public async Task<IEnumerable<Equity>> GetList()
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
