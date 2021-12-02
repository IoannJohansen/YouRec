using AutoMapper;
using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouRecWeb.Controllers.Base;

namespace YouRecWeb.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : BaseController
    {
        public GroupController(IMapper mapper, IGroupService groupService) : base(mapper)
        {
            this.groupSerivce = groupService;
        }

        private IGroupService groupSerivce;

        [HttpGet]
        [Route("getgroups")]
        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await groupSerivce.GetGroups();
        }


    }
}
