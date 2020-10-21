using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioTracker.Database.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(string query);
        Task<T> GetItemAsync(string id);
        Task AddItemAsync(T item);
        Task<T> AddUpdateAsync(T item);
        Task UpdateItemAsync(string id, T item);
        Task DeleteItemAsync(string id);
    }
}
