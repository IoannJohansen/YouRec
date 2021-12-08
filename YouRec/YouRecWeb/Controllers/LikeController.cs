using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YouRecWeb.Controllers.Base;
using YouRecWeb.Model;

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
        [HttpGet]
        public async Task<int> GetLikeCountByUserId(string userId)
        {
            return await likeService.GetCountLikesById(userId);
        }

        [Route("addLike")]
        [HttpPost]
        public async Task<IActionResult> AddLike(LikeDto likeDto)
        {
            var createdLike = await likeService.AddLike(mapper.Map<LikeDto, Like>(likeDto));
            return StatusCode(201, createdLike);
        }
    }
}
