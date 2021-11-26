using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/tags")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    public class TagController : Controller
    {
        public TagController(ITagService _tagService)
        {
            this._tagService = _tagService;

        }

        private ITagService _tagService;

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetTags()
        {
            var tagList = await _tagService.GetAllTags();
            return Ok(tagList);
        }

        [HttpPost]
        [Route("updateTag")]
        public async Task<IActionResult> UpdateTag(Tag tag)
        {
            var res = await _tagService.UpdateTag(tag);
            return Ok(res);
        }
    }
}