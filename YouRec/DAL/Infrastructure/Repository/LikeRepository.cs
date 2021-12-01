using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class LikeRepository : ILikeRepository
    {
        public LikeRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }

        private ApplicationDbContext applicationDbContext;

        public async Task<Like> AddLikeAsync(Like like)
        {
            return (await applicationDbContext.Likes.AddAsync(like)).Entity;
        }

        public async Task<int> GetLikesCountByUserIdAsync(string userId)
        {
            var res1 = applicationDbContext.Likes.Include(t => t.Recommend).Where(l => l.Recommend.UserId == userId).ToList();
            var res = await applicationDbContext.Likes.Include(t => t.Recommend).CountAsync(l => l.Recommend.UserId == userId);
            return res;
        }

        public async Task<bool> IsLiked(string userId, int recommendId)
        {
            return await applicationDbContext.Likes.FirstOrDefaultAsync(l => l.UserId == userId && l.RecommendId == recommendId) != null;
        }
    }
}
