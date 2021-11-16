using BLL.DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> SignIn(LoginRequestDto loginRequestDto);
        Task<AuthResult> SignUp(RegisterRequestDto registerRequestDto);

    }
}
