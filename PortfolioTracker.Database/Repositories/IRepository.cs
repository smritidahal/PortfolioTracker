using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioTracker.Database.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetItem(string id);

        Task<T> AddUpdate(T item);

        Task<IEnumerable<T>> GetList();

        Task Delete(string id);
    }
}
