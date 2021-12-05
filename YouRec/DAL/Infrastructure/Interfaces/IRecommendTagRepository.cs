using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRecommendTagRepository
    {
        Task<RecommendTag> AddTagToRecommendAsync(RecommendTag recommendTag);
        Task DeleteRecommendTag(int tagId, int recommendId);
        Task RemoveRecommendTags(int recommendId);
        Task AddRecommendTags(IEnumerable<RecommendTag> recommendTags);
    }
}
