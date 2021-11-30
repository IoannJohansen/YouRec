using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface ILikeRepository
    {
        Task<Like> AddLikeAsync(Like like);
        Task RemoveLikeAsync(Like like);
        Task<int> GetLikesCountByUserIdAsync(string userId);
    }
}
