using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouRecWeb.Model;

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

        public async Task<Recommend> GetRecommendDescription(int recommendId)
        {
            return await unitOfWork.RecommendsRepository.GetDescriptionAsync(recommendId);
        }

        public async Task<Recommend> CreateNewRecommend(CreateRecommendDto createRecommendDto)
        {
            var mappedRecommend = mapper.Map<CreateRecommendDto, Recommend >(createRecommendDto);
            var createdRecommend = await unitOfWork.RecommendsRepository.CreateAsync(mappedRecommend);
            createdRecommend.CreationDate = DateTime.Now;
            await unitOfWork.SaveAsync();
            return createdRecommend;
        }

        public Task<Recommend> AddImages(Recommend recommend, IEnumerable<string> images)
        {

            throw new NotImplementedException();
        }
    }
}
