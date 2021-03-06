using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BLL.Core.Auth.Jwt
{
    public class KeyGenerator
    {
        public static SymmetricSecurityKey GenerateSymmetricKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
