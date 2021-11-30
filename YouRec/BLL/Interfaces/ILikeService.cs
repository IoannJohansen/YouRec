using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILikeService
    {
        Task<Like> AddLike(Like entity);
        Task RemoveTile(Like entity);
        Task<int> GetCountLikesById(string id);
    }
}
