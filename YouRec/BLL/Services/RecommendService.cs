using AutoMapper;
using BLL.DTO;
using BLL.Helper;
using BLL.Interfaces;
using BLL.Services.Base;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YouRecWeb.Model;

namespace BLL.Services
{
    public class RecommendService : BaseService, IRecommendService
    {
        public RecommendService(Cloudinary cloudinary, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this._cloudinary = cloudinary;
        }

        private readonly Cloudinary _cloudinary;
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
            if (sortDto.SortOrder == SortOrder.asc)
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
            var totalCount = await unitOfWork.RecommendsRepository.GetCountForUserIdAsync(sortDto.UserId);
            switch (sortDto.SortMode)
            {
                case SortMode.Name:
                    var sortedByName = await unitOfWork.RecommendsRepository.GetSortedByNameAscPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByName, totalCount);
                case SortMode.UserRating:
                    var sortedByrating = await unitOfWork.RecommendsRepository.GetSortedByRatingAscPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByrating, totalCount);
                case SortMode.PublishDate:
                    var sortedByRating = await unitOfWork.RecommendsRepository.GetSortedByDateAscPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByRating, totalCount);

                default:
                    break;
            }
            return (null, 0);
        }

        private async Task<(IEnumerable<Recommend>, int)> DescSort(RecommendsSorteddDto sortDto)
        {
            var totalCount = await unitOfWork.RecommendsRepository.GetCountForUserIdAsync(sortDto.UserId);
            switch (sortDto.SortMode)
            {
                case SortMode.Name:
                    var sortedByName = await unitOfWork.RecommendsRepository.GetSortedByNameDescPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByName, totalCount);
                case SortMode.UserRating:
                    var sortedByrating = await unitOfWork.RecommendsRepository.GetSortedByRatingDescPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByrating, totalCount);
                case SortMode.PublishDate:
                    var sortedByRating = await unitOfWork.RecommendsRepository.GetSortedByDateDescPaged(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
                    return (sortedByRating, totalCount);

                default:
                    break;
            }
            return (null, -1);
        }

        public async Task<(IEnumerable<Recommend>, int)> GetForUserId(RecommendsSorteddDto sortDto)
        {
            var recommends = await unitOfWork.RecommendsRepository.GetForUserId(sortDto.Amount, sortDto.PageNumber, sortDto.UserId);
            var totalCount = await unitOfWork.RecommendsRepository.GetCountForUserIdAsync(sortDto.UserId);
            return (recommends, totalCount);
        }

        public async Task DeleteById(int id)
        {
            var imgLinks = await unitOfWork.ImageRepository.GetLinksById(id);
            foreach (var url in imgLinks)
            {
                await DeleteImageFromCloud(url);
            }
            await unitOfWork.RecommendsRepository.DeleteByIdAsync(id);
            await unitOfWork.SaveAsync();
        }

        public async Task<Recommend> UpdateRecommendInfo(UpdateRecommendDto updateRecommendDto)
        {
            var recommend = await unitOfWork.RecommendsRepository.GetById(updateRecommendDto.RecommendId);
            recommend.GroupId = updateRecommendDto.GroupId;
            recommend.AuthorRating = updateRecommendDto.AuthorRating;
            recommend.Name = updateRecommendDto.Name;
            recommend.Text = updateRecommendDto.Text;
            await unitOfWork.RecommendTagRepository.RemoveRecommendTags(updateRecommendDto.RecommendId);
            await unitOfWork.SaveAsync();
            return recommend;
        }

        public async Task UpdateImages(UpdateRecommendDto updateRecommendDto)
        {
            if (updateRecommendDto.ImageLinks.Count != 0)
            {
                var oldImages = await unitOfWork.ImageRepository.GetImagesByRecommendIdAsync(updateRecommendDto.RecommendId);
                foreach (var image in oldImages)
                {
                    await DeleteImageFromCloud(image.Original);
                }
                await unitOfWork.ImageRepository.DeleteAllImagesForRecommendId(updateRecommendDto.RecommendId);
                foreach (var item in updateRecommendDto.ImageLinks)
                {
                    var newImage = new Image { Original = item, RecommendId = updateRecommendDto.RecommendId };
                    await unitOfWork.ImageRepository.AddAsync(newImage);
                }
                await unitOfWork.SaveAsync();
            }
        }

        public async Task<Recommend> GetByID(int id)
        {
            return await unitOfWork.RecommendsRepository.GetById(id);
        }

        public async Task DeleteImageFromCloud(string url)
        {
            string publicId = Regex.Match(url, @"\/\w*", RegexOptions.RightToLeft).Value.Substring(1);
            await _cloudinary.DeleteResourcesAsync(ResourceType.Image, publicId);
        }

        public async Task<IEnumerable<Recommend>> GetfromFulltexted(string query)
        {
            return await unitOfWork.RecommendsRepository.GetFullTexted(query);
        }
    }
}
