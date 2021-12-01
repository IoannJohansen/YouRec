using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RatingService : BaseService, IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            var newRating = await unitOfWork.RatingRepository.AddAsync(rating);
            await unitOfWork.SaveAsync();
            return newRating;
        }

        public async Task<UserRecommendRatingInfo> GetUserRecommendRatingInfo(int recommendId, string userId)
        {
            var rating = await unitOfWork.RatingRepository.GetAsync(userId, recommendId);
            var isLiked = await unitOfWork.LikeRepository.IsLiked(userId, recommendId);
            return new UserRecommendRatingInfo { IsLiked = isLiked, IsRated = rating != null, RatingValue = rating!=null?rating.Rate:-1 };
        }
    }
}
