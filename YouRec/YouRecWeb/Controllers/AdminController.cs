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
    [Route("api/admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(IUserService userService, IRecommendService recommendService, IImageService imageService, IMapper mapper) : base(mapper)
        {
            this._imageService = imageService;
            this._recommendService = recommendService;
            this._userService = userService;
        }

        private IRecommendService _recommendService;
        private IImageService _imageService;
        IUserService _userService;

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
    }
}
