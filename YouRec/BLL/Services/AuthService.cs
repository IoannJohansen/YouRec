using BLL.Core.Auth.Jwt;
using BLL.Core.Auth.MIcrosoft;
using BLL.DTO;
using BLL.Helper;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
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
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.configuration = configuration;
        }

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IConfiguration configuration;

        public async Task<AuthResult> SignIn(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user != null && (await _userManager.CheckPasswordAsync(user, loginRequestDto.Password)))
            {
                var role = await _userManager.GetRolesAsync(user);
                var token = GenerateTokenForUser(user.UserName, user.Email, role.First(), user.Id);
                Log.Warning("Logged in success");
                return new AuthResult { Success = true, Token = token, Username = user.Email, IsAdmin = role.First() == "Admin", UserId = user.Id };
            }
            return new AuthResult { Success = false };
        }

        public async Task<AuthResult> SignUp(RegisterRequestDto registerRequestDto)
        {
            var result = new AuthResult();
            AppUser newUser = new() { Email = registerRequestDto.Email, UserName = registerRequestDto.UserName };
            var resultCreation = await _userManager.CreateAsync(newUser, registerRequestDto.Password);
            if (resultCreation.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                await _userManager.AddToRoleAsync(newUser, UserRole.User.ToString());
                result.Token = GenerateTokenForUser(registerRequestDto.UserName, registerRequestDto.Email, UserRole.User.ToString(), newUser.Id);
                result.Success = true;
                result.Username = registerRequestDto.UserName;
                result.UserId = newUser.Id;
            }
            return result;
        }


        public async Task<AuthResult> LoginGoogle(SocialNetworkRequestDto socialNetworkRequest)
        {
            Payload payload = await ValidateAsync(socialNetworkRequest.Id_token);
            if (payload.Audience.Equals(configuration["AuthenticationGoogleClientId"]))
            {
                var user = await GetExternalUser(socialNetworkRequest.Provider, payload.Subject, payload.Email, payload.GivenName);
                var token = GenerateTokenForUser(payload.GivenName, user.Email, UserRole.User.ToString(), user.Id);
                return new AuthResult { Success = true, Token = token, IsAdmin = false, Username = payload.GivenName, UserId = user.Id };
            }
            return new AuthResult { Success = false };
        }

        public async Task<AuthResult> LoginMicrosoft(SocialNetworkRequestDto socialNetworkRequest)
        {
            var tokenValidator = new TokenValidator(configuration);
            if (await tokenValidator.IsValid(socialNetworkRequest.Id_token))
            {
                var (sub, name, email) = ParseClaims(TokenValidator.UserClaims);
                var user = await GetExternalUser(socialNetworkRequest.Provider, sub, email, name);
                var token = GenerateTokenForUser(name, email, UserRole.User.ToString(), user.Id);
                return new AuthResult { Success = true, Token = token, IsAdmin = false, Username = name, UserId = user.Id };
            }
            return new AuthResult { Success = false };
        }

        private string GenerateTokenForUser(string userName, string email, string userRole, string id)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(ClaimTypes.NameIdentifier, id)
            };
            var signingCredentials = new SigningCredentials(KeyGenerator.GenerateSymmetricKey(JwtOptions.KEY), SecurityAlgorithms.HmacSha256);
            var jwtSecureToken = new JwtSecurityToken(JwtOptions.ISSUER, JwtOptions.AUDIENCE, claims, DateTime.Now, DateTime.Now.AddMinutes(120), signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecureToken);
            return token;
        }

        private (string, string, string) ParseClaims(List<Claim> userClaims)
        {
            var sub = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var name = userClaims.FirstOrDefault(c => c.Type == "name").Value;
            var email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            return (sub, name, email);
        }
        

        private async Task<AppUser> GetExternalUser(string provider, string key, string email, string name)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) return user;
            user = new AppUser { Email = email, UserName = name };
            var resultCreation = await _userManager.CreateAsync(user);
            if (resultCreation.Succeeded)
            {
                var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
                var result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                    return user;
            }
            return null;
        }
    }
}
