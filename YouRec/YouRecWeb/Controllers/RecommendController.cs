using AutoMapper;
using BLL.DTO;
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
    [Route("api/recommends")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecommendController : BaseController
    {
        public RecommendController(IRecommendService recommendService, ITagService tagService, IImageService imageService, IRecommendTagService recommendTagService, IMapper mapper) : base(mapper)
        {
            this._recommendService = recommendService;
            this._tagService = tagService;
            this._imageService = imageService;
            this._recommendTagService = recommendTagService;
        }

        private readonly IRecommendService _recommendService;
        private readonly ITagService _tagService;
        private readonly IImageService _imageService;
        private readonly IRecommendTagService _recommendTagService;

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

        [HttpGet]
        [Route("sort")]
        public async Task<MyRecommendsPaged> GetSorted([FromQuery] RecommendsSorteddDto sortDto)
        {
            var (res, totalCount) = await _recommendService.GetSorted(sortDto);
            var myRecommendsPaged = new MyRecommendsPaged { maxCount = totalCount };
            myRecommendsPaged.Recommends = mapper.Map<IEnumerable<Recommend>, IEnumerable<RecommendViewModel>>(res);
            return myRecommendsPaged;
        }

        [HttpGet]
        [Route("myrecommends")]
        public async Task<MyRecommendsPaged> GetRecommendsForUser([FromQuery] RecommendsSorteddDto sortDto)
        {
            var (res, totalCount) = await _recommendService.GetForUserId(sortDto);
            var myRecommendsPaged = new MyRecommendsPaged { maxCount = totalCount };
            myRecommendsPaged.Recommends = mapper.Map<IEnumerable<Recommend>, IEnumerable<RecommendViewModel>>(res);
            return myRecommendsPaged;
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRecommend(int recommendId)
        {
            await _recommendService.DeleteById(recommendId);
            return Ok(StatusCodes.Status200OK);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRecommend(UpdateRecommendDto updateRecommendDto)
        {
            await _recommendService.UpdateImages(updateRecommendDto);
            await _recommendService.UpdateRecommendInfo(updateRecommendDto);
            var recommend = await _recommendService.GetByID(updateRecommendDto.RecommendId);
            await AddTagsToRecommend(recommend, updateRecommendDto.Tags);
            return Ok(recommend);
        }

        [HttpGet]
        [Route("fulltext")]
        [AllowAnonymous]
        public async Task<int> GetRecommendfromFullTexted(string searchParameteres)
        {
            var res = await _recommendService.GetfromFulltexted(searchParameteres);
            return res.Count();
        }

    }
}
