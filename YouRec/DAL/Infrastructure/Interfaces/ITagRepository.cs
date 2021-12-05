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
        Task<Tag> AddAsync(Tag tag);
        Task AddFromListAsync(List<Tag> tags);
        Task<Tag> UpdateAsync(Tag tag);
        Task<List<Tag>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<bool> TagIsExistAsync(Tag tag);
        Task<IEnumerable<Tag>> GetTopTagsAsync(int amount);
        Task<IEnumerable<Tag>> GetTopTags(int amount);
        Task<Tag> GetTagByName(string name);
        Task DeleteRange(IEnumerable<Tag> tags);
    }
}
