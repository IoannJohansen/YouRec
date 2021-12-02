using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(IMapper  mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await unitOfWork.GroupRepository.GetAllAsync();
        }
    }
}
