using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
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

        public async Task<TopRecommendsListDto> GetStartData()
        {
            var res = new TopRecommendsListDto
            {
                Recommends = await unitOfWork.RecommendsRepository.GetRecentlyCreatedAsync(TopRecommendsListDto.PageSize)
            };
            res.CurrentCount = res.Recommends.Count();
            return res;
        }
    }
}
