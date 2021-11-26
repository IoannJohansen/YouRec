using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class ImageRepository : IImageRepository
    {
        public ImageRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<Image> AddAsync(Image image)
        {
            return (await _applicationDbContext.Images.AddAsync(image)).Entity;
        }

        public async Task DeleteAsync(Image image) => await Task.Run(() =>
        {
            _applicationDbContext.Images.Remove(image);
        });

        public async Task DeleteByIdAsync(int id) => await Task.Run(async () =>
        {
            var imageInDb = await _applicationDbContext.Images.FindAsync(id);
            _applicationDbContext.Images.Remove(imageInDb);
        });

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Images.FindAsync(id);
        }

        public async Task<IEnumerable<Image>> GetByRecommendIdAsync(int recommendId) => await Task.Run(() =>
        {
            return _applicationDbContext.Images.Where(i => i.Id == recommendId);
        });
    }
}
