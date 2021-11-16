using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using YouRecWeb.Model;

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
                res.Username = $"{registerRequestDto.FirstName} {registerRequestDto.LastName}";
            }
            return res;
        }

        [Route("SignIn")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<UserViewModel> SignIn(LoginRequestDto loginRequestDto)
        {
            await _authService.SignIn(loginRequestDto);
            return new UserViewModel {};
        }

        [Route("SecureTest")]
        [HttpGet]
        public string SecuredMethod()
        {
            return ($"User name: {HttpContext.User.Identity.Name}, Auth: {HttpContext.User.Identity.IsAuthenticated}");
        }
    }
}
