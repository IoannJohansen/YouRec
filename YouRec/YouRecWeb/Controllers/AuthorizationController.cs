using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YouRecWeb.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public AuthenticationController(IAuthService authService)
        {
            this._authService = authService;
        }
        
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

            return Ok("Hello world!");
        }
    }
}
