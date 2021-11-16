using BLL.Core.Auth;
using BLL.DTO;
using BLL.Helper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public Task SignIn(LoginRequestDto loginRequestDto)
        {
            // get claims from jwt
            // find in db user account
            // if found, then generate new token
            // else return error msg with hcode
            return null;
        }

        public async Task<AuthResult> SignUp(RegisterRequestDto registerRequestDto)
        {
            var result = new AuthResult();
            IdentityUser newUser = new IdentityUser { Email = registerRequestDto.Email, UserName = registerRequestDto.FirstName };
            var resultCreation = await _userManager.CreateAsync(newUser, registerRequestDto.Password);
            if (resultCreation.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, true);
                await _userManager.AddToRoleAsync(newUser, UserRole.User.ToString());
                result.Success = true;
            }
            var token = CreateTokenForUser(registerRequestDto, UserRole.User);
            return result;
        }

        private string CreateTokenForUser(RegisterRequestDto registerRequestDto, UserRole userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, registerRequestDto.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, registerRequestDto.Email),
                new Claim("Role", userRole.ToString())
            };
            var signingCredentials = new SigningCredentials(KeyGenerator.GenerateSymmetricKey(JwtOptions.KEY), SecurityAlgorithms.HmacSha256);
            var jwtSecureToken = new JwtSecurityToken(JwtOptions.ISSUER, JwtOptions.AUDIENCE, claims, DateTime.Now, DateTime.Now.AddMinutes(60), signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecureToken);
            return token;
        }
    }
}
