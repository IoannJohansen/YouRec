using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> GetAsync(int id);
        Task<IEnumerable<Tag>> GetItemsAsync();
        Task<Tag> CreateAsync(Tag item);
        Task Delete(Tag item);
        Task<Tag> UpdateAsync(Tag item);
        Task<int> GetCount();
        Task<bool> IsExist(Tag item);
        Task AddTags(IEnumerable<Tag> items);
    }
}
