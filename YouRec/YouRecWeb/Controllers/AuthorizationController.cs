using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YouRecWeb.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController
    {
        public AuthorizationController()
        {

        }

        [HttpGet]
        [Route("peptar")]
        public async Task<IActionResult> HelloKitty()
        {

            return null;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn()
        {

            return null;
        }

        [HttpPost]

        [Route("SignUp")]
        public async Task<IActionResult> SignUp()
        {

            return null;
        }
    }
}
