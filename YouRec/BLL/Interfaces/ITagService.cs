using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITagService
    {
        Task<Tag> AddTag(Tag tag);
        Task<IEnumerable<Tag>> GetMostUsedTags(int amount);
        Task<IEnumerable<Tag>> GetAllTags();
        Task<Tag> UpdateTag(Tag tag);
        Task<IEnumerable<Tag>> GetTopTags();
        Task<Tag> GetTagByName(string name);
    }
}
