using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
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
    }
}
