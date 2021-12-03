using BLL.Interfaces;
using DAL.Data;
using DAL.Model;
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

    }
}
