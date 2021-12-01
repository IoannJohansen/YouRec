using DAL.Model;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> AddAsync(Rating rating);
        Task<Rating> GetAsync(string userId, int recommendId);
    }
}
