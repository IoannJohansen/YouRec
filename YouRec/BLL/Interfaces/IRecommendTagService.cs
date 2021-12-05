using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRecommendTagService
    {
        Task<RecommendTag> AddRecommendTag(RecommendTag recommendTag);
        Task DeleteRecommendTag(int tagId, int recommendId);
        Task AddRecommendTags(IEnumerable<RecommendTag> recommendTags);
    }
}
