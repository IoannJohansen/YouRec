using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecommendService : BaseService, IRecommendService
    {
        public RecommendService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        const int pageSize = 10;

        public async Task<IEnumerable<Recommend>> GetRecentlyUploaded()
        {
            return await unitOfWork.RecommendsRepository.GetRecentlyUploaded(pageSize);
        }

        public async Task<IEnumerable<Recommend>> GetMostRated()
        {
            return await unitOfWork.RecommendsRepository.GetMostRatedAsync(pageSize);
        }

        public async Task<Recommend> GetBaseRecommendDescription(int recommendId)
        {
            return await unitOfWork.RecommendsRepository.GetAsync(recommendId);
        }

        public async Task<Recommend> GetFullRecommendDescription(int recommendId)
        {
            var rec = await unitOfWork.RecommendsRepository.GetAsync(recommendId);
            return rec;
        }
    }
}
