using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Core.Auth.MIcrosoft
{
    public class TokenValidator
    {
        public TokenValidator(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.tenantId = configuration["AuthenticationMicrosoftTenantId"];
        }

        private readonly string tenantId;

        private readonly IConfiguration configuration;

        public static List<Claim> UserClaims { get; set; }

        public async Task<bool> IsValid(string token)
        {
            try
            {
                var openidConfigManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    string.Format(MicrosoftTokenParameteres.METADATAADRESS, tenantId),
                    new OpenIdConnectConfigurationRetriever(),
                    new HttpDocumentRetriever());

                var openIdConfiguration = await openidConfigManager.GetConfigurationAsync();
                var validationParameteres = MicrosoftTokenParameteres.GetParameteres(openIdConfiguration, configuration);
                var tokenHandler = new JwtSecurityTokenHandler();

                UserClaims = new List<Claim>(tokenHandler.ValidateToken(token, validationParameteres, out _).Identities.FirstOrDefault().Claims);

                Log.Warning("Microsoft token successfully validated");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
