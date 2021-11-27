using AutoMapper;
using BLL.DTO;
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
    public class RecommendService : BaseService, IRecommendService
    {
        public RecommendService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        const int pageSize = 10;

        public async Task<IEnumerable<Recommend>> GetStartData()
        {
            return await unitOfWork.RecommendsRepository.GetRecentlyCreatedAsync(pageSize);
        }


    }
}
