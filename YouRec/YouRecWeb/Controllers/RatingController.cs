using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YouRecWeb.Controllers.Base;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/rating")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RatingController : BaseController
    {
        public RatingController(IRatingService ratingService, IMapper mapper) : base(mapper)
        {
            this.ratingService = ratingService;

        }

        private IRatingService ratingService;

        [HttpGet]
        [Route("getRecommendUserInfo")]
        public async Task<UserRecommendRatingInfo> GetRecommendUserReting(string userId, int recommendId)
        {
            return await ratingService.GetUserRecommendRatingInfo(recommendId, userId);
        }

        [HttpPost]
        [Route("addRating")]
        public async Task<Rating> AddRating(RatingDto ratingDto)
        {
            var mapperRating = mapper.Map<RatingDto, Rating>(ratingDto);
            return await ratingService.AddRating(mapperRating);
        }
    }
}
