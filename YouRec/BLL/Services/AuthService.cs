using BLL.Core.Auth;
using BLL.DTO;
using BLL.Helper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<AuthResult> SignIn(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user != null && (await _userManager.CheckPasswordAsync(user, loginRequestDto.Password)))
            {
                var role = await _userManager.GetRolesAsync(user);
                var token = CreateTokenForUser(user.UserName, user.Email, role.First());
                return new AuthResult { Success = true, Token = token, Username = user.UserName , IsAdmin = role.First() == "Admin" };
            }
            return new AuthResult { Success = false };
        }

        public async Task<AuthResult> SignUp(RegisterRequestDto registerRequestDto)
        {
            var result = new AuthResult();
            IdentityUser newUser = new IdentityUser { Email = registerRequestDto.Email, UserName = registerRequestDto.FirstName };
            var resultCreation = await _userManager.CreateAsync(newUser, registerRequestDto.Password);
            if (resultCreation.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                await _userManager.AddToRoleAsync(newUser, UserRole.User.ToString());
                result.Token = CreateTokenForUser(registerRequestDto.FirstName, registerRequestDto.Email, UserRole.User.ToString());
                result.Success = true;
            }
            else
            {
                result.ErrorMsg = resultCreation.Errors;
            }
            return result;
        }

        private string CreateTokenForUser(string firstName, string email, string userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, firstName),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, userRole)
            };
            var signingCredentials = new SigningCredentials(KeyGenerator.GenerateSymmetricKey(JwtOptions.KEY), SecurityAlgorithms.HmacSha256);
            var jwtSecureToken = new JwtSecurityToken(JwtOptions.ISSUER, JwtOptions.AUDIENCE, claims, DateTime.Now, DateTime.Now.AddMinutes(60), signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecureToken);
            return token;
        }
    }
}
