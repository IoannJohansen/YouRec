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
            var newTask = await unitOfWork.LikeRepository.AddLikeAsync(entity);
            await unitOfWork.SaveAsync();
            return newTask;
        }

        public async Task<int> GetCountLikesById(string id)
        {
            return await unitOfWork.LikeRepository.GetLikesCountByUserIdAsync(id);
        }
    }
}
