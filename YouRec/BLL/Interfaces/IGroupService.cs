using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups();

    }
}
