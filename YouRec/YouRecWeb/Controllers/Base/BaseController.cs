
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace YouRecWeb.Controllers.Base
{
    public class BaseController : Controller
    {
        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected IMapper mapper;

    }
}
