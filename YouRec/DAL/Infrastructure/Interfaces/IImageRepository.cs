using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> AddAsync(Image image);
        Task DeleteAsync(Image image);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<Image>> GetByRecommendIdAsync(int recommendId);
        Task<Image> GetByIdAsync(int id);
    }
}
