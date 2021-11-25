using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> CreateAsync(T item);
        Task Delete(T item);
        Task<T> UpdateAsync(T item);
        Task<int> GetCount();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
    }
}
