using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : BaseService,  IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork= unitOfWork;

        }

        private IUnitOfWork unitOfWork;

        public async Task<IEnumerable<AppUser>> GetUsersPaged(int page, int pageSize)
        {
            return await unitOfWork.UserRepository.GetUsersPaged(page, pageSize);
        }
    }
}
