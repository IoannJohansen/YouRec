using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class RecommendRepository : IRecommendRepository
    {
        public RecommendRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<Recommend> CreateAsync(Recommend item)
        {
            return (await _applicationDbContext.Recommends.AddAsync(item)).Entity;
        }

        public async Task DeleteByIdAsync(int id) => await Task.Run(() =>
        {
            var recommend = _applicationDbContext.Recommends.FindAsync(id).Result;
            _applicationDbContext.Recommends.Remove(recommend);
        });

        public async Task<Recommend> GetDescriptionAsync(int id)
        {
            return await _applicationDbContext.Recommends.Include(t=>t.RecommendTags).ThenInclude(t=>t.Tag).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).FirstOrDefaultAsync(r=>r.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _applicationDbContext.Recommends.CountAsync();
        }

        public async Task<IEnumerable<Recommend>> GetItemsAsync()
        {
            return await _applicationDbContext.Recommends.ToListAsync();
        }

        public async Task<Recommend> UpdateAsync(Recommend item) => await Task.Run(() =>
        {
            return _applicationDbContext.Recommends.Update(item).Entity;
        });

        public async Task<IEnumerable<Recommend>> GetFiltered(Expression<Func<Recommend, bool>> predicate)
        {
            return await _applicationDbContext.Recommends.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Recommend>> GetRecentlyUploaded(int amount)
        {
            return await _applicationDbContext.Recommends.OrderByDescending(r => r.CreationDate).Take(amount).Include(r => r.Ratings).Include(r => r.Group).Include(r => r.Images).Include(r=>r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetMostRatedAsync(int amount)
        {
            return await _applicationDbContext.Recommends.OrderByDescending(r => r.Ratings.Average(a=>a.Rate)).Take(amount).Include(r => r.Ratings).Include(r => r.Group).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetSortedByNameAscPaged(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).Skip(numPage * amount).Take(amount).OrderBy(r => r.Name).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetSortedByNameDescPaged(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).Skip(numPage * amount).Take(amount).OrderByDescending(r => r.Name).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetSortedByDateDescPaged(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).Skip(numPage * amount).Take(amount).OrderByDescending(r => r.CreationDate).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetSortedByDateAscPaged(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).Skip(numPage * amount).Take(amount).OrderBy(r => r.CreationDate).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetSortedByRatingDescPaged(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).OrderByDescending(r => r.Ratings.Average(r => r.Rate)).Skip(numPage * amount).Take(amount).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetSortedByRatingAscPaged(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).OrderBy(r => r.Ratings.Average(r => r.Rate)).Skip(numPage * amount).Take(amount).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<IEnumerable<Recommend>> GetForUserId(int amount, int numPage, string userId)
        {
            return await _applicationDbContext.Recommends.Where(r => r.UserId == userId).Skip(numPage * amount).Take(amount).OrderBy(r=>r.Name).Include(r => r.Group).Include(r => r.Ratings).Include(r => r.Images).Include(r => r.User).ToArrayAsync();
        }

        public async Task<int> GetCountForUserIdAsync(string userId)
        {
            return await _applicationDbContext.Recommends.CountAsync(r=>r.UserId==userId);
        }
    }
}