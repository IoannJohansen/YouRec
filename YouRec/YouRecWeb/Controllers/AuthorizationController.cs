using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace YouRecWeb.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public AuthenticationController(IAuthService authService, SignInManager<IdentityUser> signInManager)
        {
            this._authService = authService;
            this.signInManager = signInManager;
        }

        private SignInManager<IdentityUser> signInManager;

        private IAuthService _authService;

        [Route("SignUp")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<AuthResult> SignUp(RegisterRequestDto registerRequestDto)
        {
            var res = await _authService.SignUp(registerRequestDto);
            if (res.Success)
            {
                res.IsAdmin = false;
                res.Username = registerRequestDto.FirstName;
            }
            return res;
        }

        [Route("SignIn")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<AuthResult> SignIn(LoginRequestDto loginRequestDto)
        {
            return await _authService.SignIn(loginRequestDto);
        }

        [Authorize(Roles = "User")]
        [Route("Test")]
        public async Task<IActionResult> Test()
        {
            Log.Logger.Information($"User {HttpContext.User.Identity.Name} logged in");
            return Ok("Hello world!");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("google")]
        public async Task<AuthResult> LoginGoogle(SocialNetworkRequestDto socialNetworkRequest)
        {
            return await _authService.LoginGoogle(socialNetworkRequest);
        }
    }
}
