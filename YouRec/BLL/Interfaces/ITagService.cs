using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITagService
    {
        Task AddTagsRange(List<Tag> tag);
        Task<IEnumerable<Tag>> GetTags(int amount);
        Task<IEnumerable<Tag>> GetAllTags();
        Task<Tag> UpdateTag(Tag tag);
        Task<IEnumerable<Tag>> GetTopTags();
    }
}
