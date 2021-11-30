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
    public class LikeService : BaseService, ILikeService
    {
        public LikeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<Like> AddLike(Like entity)
        {
            return await unitOfWork.LikeRepository.AddLikeAsync(entity);
        }

        public async Task<int> GetCountLikesById(string id)
        {
            return await unitOfWork.LikeRepository.GetLikesCountByUserIdAsync(id);
        }

        public async Task RemoveTile(Like entity)
        {
            await unitOfWork.LikeRepository.RemoveLikeAsync(entity);
        }
    }
}
