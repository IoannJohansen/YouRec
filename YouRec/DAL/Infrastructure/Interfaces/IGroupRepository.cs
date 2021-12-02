using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Infrastructure.Repository;

namespace DAL.Infrastructure.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(int id);
        Task<Group> AddAsync(Group group);
    }
}
