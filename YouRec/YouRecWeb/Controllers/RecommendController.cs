using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/recommends")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    public class RecommendController : Controller
    {
        public RecommendController(IRecommendService recommendService)
        {
            this._recommendService = recommendService;

        }

        private IRecommendService _recommendService;

        [HttpGet]
        [Route("data")]
        public async Task<IActionResult> GetData()
        {
            return Ok("Okss");
        }

    }
}
