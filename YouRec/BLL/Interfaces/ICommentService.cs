using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<int> GetCountAsync(int recommendId);

        Task<IEnumerable<Comment>> GetPagedAsync(int recommendId, int pageNum, int amount);

        Task<Comment> CreateCommentAsync(Comment comment);
    }
}
