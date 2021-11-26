using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> CreateAsync(T item);
        Task DeleteAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<int> GetCountAsync();
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate);
    }
}
