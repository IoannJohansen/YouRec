using AutoMapper;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouRecWeb.Controllers.Base;
using YouRecWeb.Model;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(ITagService tagService, IRecommendTagService recommendTagService, IUserService userService, IRecommendService recommendService, IImageService imageService, IMapper mapper) : base(mapper)
        {
            this._imageService = imageService;
            this._recommendService = recommendService;
            this._userService = userService;
            this._tagService = tagService;
            this._recommendTagService = recommendTagService;
        }

        private readonly IRecommendService _recommendService;
        private readonly IImageService _imageService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;
        private readonly IRecommendTagService _recommendTagService;


        [HttpGet]
        [Route("getusers")]
        public async Task<UserListViewModel> GetUserList(int pageNum, int pageSize)
        {
            var userViewModel = new UserListViewModel();
            var users = await _userService.GetUsersPaged(pageNum, pageSize);
            userViewModel.Users = mapper.Map<IEnumerable<AppUser>, IEnumerable<UserViewModel>>(users);
            userViewModel.TotalCount = users.Count();
            return userViewModel;
        }

        [HttpPost]
        [Route("createPostWithId")]
        public async Task<IActionResult> CreateRecommend(CreateRecommendDto createRecommendDto)
        {
            var createdRecommend = await _recommendService.CreateNewRecommend(createRecommendDto);
            await AddTagsToRecommend(createdRecommend, createRecommendDto.Tags);
            await AddImagesToRecommend(createdRecommend, createRecommendDto.ImageLinks);
            return StatusCode(StatusCodes.Status201Created, createdRecommend);
        }

        protected async Task AddTagsToRecommend(Recommend recommend, IEnumerable<string> tags)
        {
            foreach (var tag in tags)
            {
                var tagInDb = await _tagService.GetTagByName(tag);
                if (tagInDb != null)
                {
                    await _recommendTagService.AddRecommendTag(new RecommendTag { RecommendId = recommend.Id, TagId = tagInDb.Id });
                }
                else
                {
                    var createdTag = await _tagService.AddTag(new Tag { TagName = tag });
                    await _recommendTagService.AddRecommendTag(new RecommendTag { RecommendId = recommend.Id, TagId = createdTag.Id });
                }
            }
        }

        protected async Task AddImagesToRecommend(Recommend recommend, IEnumerable<string> imageUrls)
        {
            foreach (var imageUrl in imageUrls)
            {
                await _imageService.AddImage(new Image { Original = imageUrl, RecommendId = recommend.Id });
            }
        }

    }
}