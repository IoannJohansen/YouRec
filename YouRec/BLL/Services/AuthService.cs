using BLL.Core.Auth;
using BLL.DTO;
using BLL.Helper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.configuration = configuration;
        }

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private IConfiguration configuration;

        public async Task<AuthResult> SignIn(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user != null && (await _userManager.CheckPasswordAsync(user, loginRequestDto.Password)))
            {
                var role = await _userManager.GetRolesAsync(user);
                var token = GenerateTokenForUser(user.UserName, user.Email, role.First());
                return new AuthResult { Success = true, Token = token, Username = user.Email, IsAdmin = role.First() == "Admin" };
            }
            return new AuthResult { Success = false };
        }

        public async Task<AuthResult> SignUp(RegisterRequestDto registerRequestDto)
        {
            var result = new AuthResult();
            IdentityUser newUser = new() { Email = registerRequestDto.Email, UserName = registerRequestDto.FirstName };
            var resultCreation = await _userManager.CreateAsync(newUser, registerRequestDto.Password);
            if (resultCreation.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                await _userManager.AddToRoleAsync(newUser, UserRole.User.ToString());
                result.Token = GenerateTokenForUser(registerRequestDto.FirstName, registerRequestDto.Email, UserRole.User.ToString());
                result.Success = true;
                result.Username = registerRequestDto.FirstName;
            }
            result.IdentityError = resultCreation.Errors;
            return result;
        }

        private string GenerateTokenForUser(string firstName, string email, string userRole)
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

        public async Task<AuthResult> LoginGoogle(SocialNetworkRequestDto socialNetworkRequest)
        {
            Payload payload = await ValidateAsync(socialNetworkRequest.Id_token);
            if (payload.Audience.Equals(configuration["Authentication:Google:ClientId"]))
            {
                var user = await GetExternalUser("google", payload.Subject, socialNetworkRequest.Email, payload.GivenName);
                var token = GenerateTokenForUser(payload.GivenName, user.Email, UserRole.User.ToString());
                return new AuthResult { Success = true, Token = token, IsAdmin = false };
            }
            return null;
        }

        public async Task<IdentityUser> GetExternalUser(string provider, string key, string email, string name)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) return user;
            user = new IdentityUser { Email = email, UserName = email };
            var resultCreation = await _userManager.CreateAsync(user);
            if (resultCreation.Succeeded)
            {
                var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
                var result = await _userManager.AddLoginAsync(user, info);
                if (resultCreation.Succeeded)
                    return user;
            }
            return null;
        }
    }
}
