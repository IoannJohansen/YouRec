using BLL.Interfaces;
using DAL.Data;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecommendTagRepository : IRecommendTagRepository
    {
        public RecommendTagRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }

        private ApplicationDbContext applicationDbContext;

        public async Task<RecommendTag> AddTagToRecommendAsync(RecommendTag recommendTag)
        {
            return (await applicationDbContext.RecommendTags.AddAsync(recommendTag)).Entity;
        }

        public async Task DeleteRecommendTag(int tagId, int recommendId)
        {
            var recommendTag = await applicationDbContext.RecommendTags.FirstOrDefaultAsync(recTag=> recTag.Id == tagId && recTag.RecommendId == recommendId);
            applicationDbContext.RecommendTags.Remove(recommendTag);
        }

        public async Task RemoveRecommendTags(int recommendId) => await Task.Run(() =>
        {
            var recTags = applicationDbContext.RecommendTags.Where(r => r.RecommendId == recommendId);
            applicationDbContext.RecommendTags.RemoveRange(recTags);
        });

        public async Task AddRecommendTags(IEnumerable<RecommendTag> recommendTags)
        {
            await applicationDbContext.RecommendTags.AddRangeAsync(recommendTags);
        }
    }
}
