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
        Task<Recommend> GetDescriptionAsync(int id);
        Task<IEnumerable<Recommend>> GetItemsAsync();
        Task<Recommend> CreateAsync(Recommend item);
        Task DeleteByIdAsync(int item);
        Task<Recommend> UpdateAsync(Recommend item);
        Task<int> GetCountAsync();
        Task<IEnumerable<Recommend>> GetFiltered(Expression<Func<Recommend, bool>> predicate);
        Task<IEnumerable<Recommend>> GetRecentlyUploaded(int amount);
        Task<IEnumerable<Recommend>> GetMostRatedAsync(int amount);


        Task<IEnumerable<Recommend>> GetSortedByNameAscPaged(int amount, int numPage, string userId);
        Task<IEnumerable<Recommend>> GetSortedByNameDescPaged(int amount, int numPage, string userId);
        Task<IEnumerable<Recommend>> GetSortedByDateDescPaged(int amount, int numPage, string userId);
        Task<IEnumerable<Recommend>> GetSortedByDateAscPaged(int amount, int numPage, string userId);
        Task<IEnumerable<Recommend>> GetSortedByRatingDescPaged(int amount, int numPage, string userId);
        Task<IEnumerable<Recommend>> GetSortedByRatingAscPaged(int amount, int numPage, string userId);
        Task<IEnumerable<Recommend>> GetForUserId(int amount, int numPage, string userId);
        Task<int> GetCountForUserIdAsync(string userId);
    }
}
