using Microsoft.IdentityModel.Tokens;

namespace YouRecWeb.Core.Auth
{
    public static class JwtOptions
    {
        public const string ISSUER = "YouRec";

        public const string AUDIENCE = "YouRec";

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
