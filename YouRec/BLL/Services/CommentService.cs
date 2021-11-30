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
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> GetCountAsync(int recommendId)
        {
            return await unitOfWork.Commentrepository.GetCountForRecommendAsync(recommendId);
        }

        public async Task<IEnumerable<Comment>> GetPagedAsync(int recommendId, int pageNum, int amount)
        {
            return await unitOfWork.Commentrepository.GetPagedAsync(recommendId, pageNum, amount);
        }
    }
}
