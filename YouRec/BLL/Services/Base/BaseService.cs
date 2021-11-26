using AutoMapper;
using DAL.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Base
{
    public class BaseService
    {
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
    }
}
