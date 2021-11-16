using Microsoft.IdentityModel.Tokens;

namespace BLL.Core.Auth
{
    public static class JwtOptions
    {
        public const string ISSUER = "YouRecWeb";

        public const string AUDIENCE = "YouRecClient";

        public const string KEY = "MyLargeSuperSecretSecureKeyForSecurityOfMeinApplication";

        public static TokenValidationParameters GetTokenValidationParameters()
        {
            var key = KeyGenerator.GenerateSymmetricKey(KEY);
            var validationRules = new TokenValidationParameters
            {
                ValidIssuer = ISSUER,
                ValidAudience = AUDIENCE,
                IssuerSigningKey = key,
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = true
            };
            return validationRules;
        }
    }
}
