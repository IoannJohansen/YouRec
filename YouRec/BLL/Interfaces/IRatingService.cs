using BLL.DTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRatingService
    {
        Task<Rating> AddRating(Rating rating);
        Task<UserRecommendRatingInfo> GetUserRecommendRatingInfo(int recommendId, string userId);
    }
}
