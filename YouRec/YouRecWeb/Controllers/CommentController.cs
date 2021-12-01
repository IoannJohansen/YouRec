using AutoMapper;
using BLL.DTO;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/comments")]
    [ApiController]
    public class CommentController : BaseController
    {
        public CommentController(ICommentService _commentService, IMapper mapper) : base(mapper)
        {
            this._commentService = _commentService;
        }

        private ICommentService _commentService;

        [Route("getcommentpaged")]
        [HttpGet]
        public async Task<PaginatedObjectDto<CommentViewModel>> GetCommentsPaged(int recommendId, int numPage, int pageSize)
        {
            var paginatedComments = await _commentService.GetPagedAsync(recommendId, numPage, pageSize);
            if (paginatedComments.Count() == 0) return null;
            var totalCount = await _commentService.GetCountAsync(recommendId);
            var mappedComments = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(paginatedComments);
            return new PaginatedObjectDto<CommentViewModel> { ItemCount = totalCount, Items = mappedComments };
        }

        [Route("addComment")]
        [HttpPost]
        public async Task<CommentViewModel> AddComment(CommentDto commentDto)
        {
            var mapperComment = mapper.Map<CommentDto, Comment>(commentDto);
            var createdComment = await _commentService.CreateCommentAsync(mapperComment);
            return mapper.Map<Comment, CommentViewModel>(createdComment);
        }
    }
}
