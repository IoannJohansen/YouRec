using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class RatingRepository : IRatingRepository
    {
        public RatingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<Rating> AddAsync(Rating rating)
        {
            return (await _applicationDbContext.Ratings.AddAsync(rating)).Entity;
        }

        public async Task<Rating> UpdateAsync(Rating rating) => await Task.Run(() =>
        {
            return _applicationDbContext.Ratings.Update(rating).Entity;
        });

        public async Task DeleteAsync(int id) => await Task.Run(() =>
        {
            var ratingInDb = _applicationDbContext.Ratings.FindAsync(id).Result;
            _applicationDbContext.Ratings.Remove(ratingInDb);
        });
    }
}
