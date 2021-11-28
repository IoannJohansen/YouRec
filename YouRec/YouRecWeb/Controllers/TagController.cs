using AutoMapper;
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
    [Route("api/tags")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    public class TagController : BaseController
    {
        public TagController(ITagService _tagService, IMapper mapper) : base(mapper)
        {
            this._tagService = _tagService;

        }

        private ITagService _tagService;

        [HttpGet]
        [Route("getalltags")]
        [AllowAnonymous]
        public async Task<TagListViewModel> GetTags()
        {
           var tagList = await _tagService.GetTopTags();
            var tagVM = new TagListViewModel();
            tagVM.Tags = mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tagList);
            return tagVM;
        }
    }
}