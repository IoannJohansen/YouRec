using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<int> GetCountForRecommendAsync(int recommendId);
        Task<IEnumerable<Comment>> GetPagedAsync(int recommendId, int pageNum, int amount);
    }
}
