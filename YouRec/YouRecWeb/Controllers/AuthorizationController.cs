using BLL.DTO;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using YouRecWeb.Model;

namespace YouRecWeb.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public AuthenticationController(IAuthService authenticationService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._authenticationService = authenticationService;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        private IAuthService _authenticationService;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(RequestLoginDto signInData)
        {
            Console.WriteLine(signInData);
            return Created("Success", signInData);
        }

        [HttpPost]

        [Route("SignUp")]
        public async Task<IActionResult> SignUp()
        {

            return null;
        }

        public async Task<IActionResult> Logout()
        {
            return null;
        }

        public async Task<IActionResult> IsLoggedId()
        {

            return null;
        }
    }
}
