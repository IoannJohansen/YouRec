using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IRecommendRepository
    {
        Task<Recommend> GetAsync(int id);
        Task<IEnumerable<Recommend>> GetItemsAsync();
        Task<Recommend> CreateAsync(Recommend item);
        Task DeleteAsync(Recommend item);
        Task<Recommend> UpdateAsync(Recommend item);
        Task<int> GetCountAsync();
        Task<IEnumerable<Recommend>> GetFilteredAsync(Expression<Func<Recommend, bool>> predicate);
        Task<IEnumerable<Recommend>> GetRecentlyCreatedAsync(int amount);
        Task<IEnumerable<Recommend>> GetMostRatedAsync(int amount);
    }
}
