using AutoMapper;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouRecWeb.Controllers.Base;
using YouRecWeb.Model;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/recommends")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    public class RecommendController : BaseController
    {
        public RecommendController(IRecommendService recommendService, IMapper mapper) : base(mapper)
        {
            _recommendService = recommendService;
        }

        private IRecommendService _recommendService;

        [HttpGet]
        [Route("recentlyuploaded")]
        [AllowAnonymous]
        public async Task<RecommendListViewModel> GetRecentlyUploaded()
        {
            var recentlyUploadedRecommends = await _recommendService.GetRecentlyUploaded();
            var recentlyUploadedRecsDto = mapper.Map<IEnumerable<Recommend>, IEnumerable<RecommendViewModel>>(recentlyUploadedRecommends);
            return new RecommendListViewModel { Recommends = recentlyUploadedRecsDto, CurrentCount = recentlyUploadedRecsDto.Count() };
        }

        [HttpGet]
        [Route("mostrated")]
        [AllowAnonymous]
        public async Task<RecommendListViewModel> GetMostRated()
        {
            var recentlyUploadedRecommends = await _recommendService.GetMostRated();
            var recentlyUploadedRecsDto = mapper.Map<IEnumerable<Recommend>, IEnumerable<RecommendViewModel>>(recentlyUploadedRecommends);
            return new RecommendListViewModel { Recommends = recentlyUploadedRecsDto, CurrentCount = recentlyUploadedRecsDto.Count() };
        }

        [HttpGet]
        [Route("getrecommend")]
        [AllowAnonymous]
        public async Task<RecommendDescriptionViewModel> GetRecommendDescription(int id)
        {
            var recommendDescription = await _recommendService.GetRecommendDescription(id);
            return mapper.Map<Recommend, RecommendDescriptionViewModel>(recommendDescription);
        }
    }
}
