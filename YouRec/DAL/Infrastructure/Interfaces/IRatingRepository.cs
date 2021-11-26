using DAL.Model;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> AddAsync(Rating rating);
        Task<Rating> UpdateAsync(Rating rating);
        Task DeleteAsync(int id);
    }
}
