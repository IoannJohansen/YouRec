using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<IActionResult> SignIn();

        public Task<IActionResult> SignUp();

        public Task<IActionResult> IsSignedIn();

        public Task<IActionResult> LogOut();
    }
}
