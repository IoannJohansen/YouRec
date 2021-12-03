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
        public RecommendController(IRecommendService recommendService, ITagService tagService, IImageService imageService, IRecommendTagService recommendTagService, IMapper mapper) : base(mapper)
        {
            this._recommendService = recommendService;
            this._tagService = tagService;
            this._imageService = imageService;
            this._recommendTagService = recommendTagService;
        }

        private IRecommendService _recommendService;
        private ITagService _tagService;
        private IImageService _imageService;
        private IRecommendTagService _recommendTagService;

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

        [HttpPost]
        [Route("createpost")]
        public async Task<IActionResult> CreateRecommend(CreateRecommendDto createRecommendDto)
        {
            var createdRecommend = await _recommendService.CreateNewRecommend(createRecommendDto);
            await AddTagsToRecommend(createdRecommend, createRecommendDto.Tags);
            await AddImagesToRecommend(createdRecommend, createRecommendDto.ImageLinks);

            return StatusCode(201, createdRecommend);
        }

        private async Task AddTagsToRecommend(Recommend recommend, IEnumerable<string> tags)
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

        private async Task AddImagesToRecommend(Recommend recommend, IEnumerable<string> imageUrls)
        {
            foreach (var imageUrl in imageUrls)
            {
                await _imageService.AddImage(new Image { Original = imageUrl, RecommendId = recommend.Id});
            }
        }
    }
}
