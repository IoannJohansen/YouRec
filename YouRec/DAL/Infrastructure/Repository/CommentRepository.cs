using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<int> GetCountForRecommendAsync(int recommendId)
        {
            return await _applicationDbContext.Comments.CountAsync(c => c.RecommendId == recommendId);
        }

        public async Task<IEnumerable<Comment>> GetPagedAsync(int recommendId, int pageNum, int pageSize)
        {
            return await _applicationDbContext.Comments.Where(c => c.RecommendId == recommendId).Skip(pageNum*pageSize).Take(pageSize).Include(c=>c.User).ToListAsync();
        }
    }
}
