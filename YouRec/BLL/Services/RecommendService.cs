using AutoMapper;
using BLL.DTO;
using BLL.Helper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var mappedRecommend = mapper.Map<CreateRecommendDto, Recommend>(createRecommendDto);
            var createdRecommend = await unitOfWork.RecommendsRepository.CreateAsync(mappedRecommend);
            createdRecommend.CreationDate = DateTime.Now;
            await unitOfWork.SaveAsync();
            return createdRecommend;
        }

        public async Task<(IEnumerable<Recommend>, int)> GetSorted(RecommendsSorteddDto sortDto)
        {
            if (sortDto.SortOrder==SortOrder.asc)
            {
               return await AscSort(sortDto);
            }
            else
            {
                return await DescSort(sortDto);
            }
        }

        private async Task<(IEnumerable<Recommend>, int)> AscSort(RecommendsSorteddDto sortDto)
        {
            switch (sortDto.SortMode)
            {
                case SortMode.Name:
                    var sortedByName = await unitOfWork.RecommendsRepository.GetSortedByNameAscPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByName, sortedByName.Count());
                case SortMode.UserRating:
                    var sortedByrating = await unitOfWork.RecommendsRepository.GetSortedByRatingAscPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByrating, sortedByrating.Count());
                case SortMode.PublishDate:
                    var sortedByRating = await unitOfWork.RecommendsRepository.GetSortedByDateAscPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByRating, sortedByRating.Count());

                default:
                    break;
            }
            return (null, 0);
        }

        private async Task<(IEnumerable<Recommend>, int)> DescSort(RecommendsSorteddDto sortDto)
        {
            switch (sortDto.SortMode)
            {
                case SortMode.Name:
                    var sortedByName = await unitOfWork.RecommendsRepository.GetSortedByNameDescPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByName, sortedByName.Count());
                case SortMode.UserRating:
                    var sortedByrating = await unitOfWork.RecommendsRepository.GetSortedByRatingDescPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByrating, sortedByrating.Count());
                case SortMode.PublishDate:
                    var sortedByRating = await unitOfWork.RecommendsRepository.GetSortedByDateDescPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByRating, sortedByRating.Count());

                default:
                    break;
            }
            return (null, 0);
        }

        public async Task<(IEnumerable<Recommend>, int)> GetForUserId(RecommendsSorteddDto sortDto)
        {
            var recommends = await unitOfWork.RecommendsRepository.GetForUserId(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
            return (recommends, recommends.Count());
        }
    }
}
