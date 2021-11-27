using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var recentlyUploadedRecommends = await _recommendService.GetStartData();
             var recentlyUploadedRecsDto = mapper.Map<IEnumerable<Recommend>, IEnumerable<RecommendViewModel>>(recentlyUploadedRecommends);
            return new RecommendListViewModel { RecommendList = recentlyUploadedRecsDto };
        }
    }
}
