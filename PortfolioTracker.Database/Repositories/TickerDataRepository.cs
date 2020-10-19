using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioTracker.Database.DataModels;
using PortfolioTracker.Database.Services;

namespace PortfolioTracker.Database.Repositories
{
    public class TickerDataRepository : IRepository<TickerData>
    {
        private readonly IDataService<TickerData> _dbContext;

        public TickerDataRepository(IDataService<TickerData> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TickerData> AddUpdate(TickerData stock)
        {
            var response = await _dbContext.AddUpdateAsync(stock);
            return response;
        }

        public async Task<TickerData> GetItem(string id)
        {
            return await _dbContext.GetItemAsync(id);
        }

        public async Task<IEnumerable<TickerData>> GetList()
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
