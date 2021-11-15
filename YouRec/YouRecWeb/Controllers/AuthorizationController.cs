using BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YouRecWeb.Core.Auth;

namespace YouRecWeb.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        [Route("SignUp")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignUp(RegisterRequestDto registerRequestDto)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, registerRequestDto.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, registerRequestDto.Email)
            };
            var signingCredentials = new SigningCredentials(KeyGenerator.GenerateSymmetricKey(JwtOptions.KEY), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(JwtOptions.ISSUER, JwtOptions.AUDIENCE, claims, DateTime.Now, DateTime.Now.AddMinutes(60), signingCredentials );
            var value = new JwtSecurityTokenHandler().WriteToken(token);
            Console.WriteLine(value);
            return Ok(200);
        }

        [Authorize]
        [Route("Secure")]
        public IActionResult SecuredMethod()
        {
            return Ok(200);
        }
    }
}
