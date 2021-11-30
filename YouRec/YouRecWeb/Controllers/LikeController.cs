using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YouRecWeb.Controllers.Base;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/like")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LikeController : BaseController
    {
        public LikeController(ILikeService likeService, IMapper mapper) : base(mapper)
        {
            this.likeService = likeService;
        }

        private ILikeService likeService;

        [Route("getcountforuser")]
        [AllowAnonymous]
        public async Task<int> GetLikeCountByUserId(string userId)
        {
            return await likeService.GetCountLikesById(userId);
        }
    }
}
