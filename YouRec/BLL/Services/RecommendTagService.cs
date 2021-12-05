using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecommendTagService : BaseService, IRecommendTagService
    {
        public RecommendTagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<RecommendTag> AddRecommendTag(RecommendTag recommendTag)
        {
            var createdRecommendtag = await unitOfWork.RecommendTagRepository.AddTagToRecommendAsync(recommendTag);
            await unitOfWork.SaveAsync();
            return createdRecommendtag;
        }

        public async Task AddRecommendTags(IEnumerable<RecommendTag> recommendTags)
        {
            await unitOfWork.RecommendTagRepository.AddRecommendTags(recommendTags);
            
        }

        public async Task DeleteRecommendTag(int tagId, int recommendId)
        {
            await unitOfWork.RecommendTagRepository.DeleteRecommendTag(tagId, recommendId);
        }
    }
}
