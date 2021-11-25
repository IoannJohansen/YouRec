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
    public class RecommendRepository : IRecommendsRepository
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

        public async Task Delete(Recommend item) => await Task.Run(() =>
        {
            _applicationDbContext.Remove(item);
        });

        public async Task<Recommend> GetAsync(int id)
        {
            return await _applicationDbContext.Recommends.FindAsync(id);
        }

        public async Task<int> GetCount()
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

        public async Task<IEnumerable<Recommend>> Get(Expression<Func<Recommend, bool>> predicate)
        {
            return await _applicationDbContext.Recommends.Where(predicate).ToListAsync();
        }
    }
}