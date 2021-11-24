using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core.Auth.MIcrosoft
{
    public class MicrosoftTokenParameteres
    {
        public static TokenValidationParameters GetParameteres(OpenIdConnectConfiguration config, IConfiguration configuration)
        {
            return new TokenValidationParameters() {
                    RequireAudience = true,
                    RequireExpirationTime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidAudiences = new[] { configuration["Authentication:Microsoft:AppId"] },
                    ValidIssuer = string.Format(VALIDISSUER, configuration["Authentication:Microsoft:TenantId"]) ,
                    IssuerSigningKeys = config.SigningKeys 
            };
        }

        public const string METADATAADRESS = "https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration";

        public const string VALIDISSUER = "https://login.microsoftonline.com/{0}/v2.0";

    }
}
