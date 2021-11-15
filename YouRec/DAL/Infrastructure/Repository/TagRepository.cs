using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    internal class TagRepository : ITagRepository
    {
        public TagRepository(ApplicationDbContext applicationDbContext)
        {
            this._dbContext = applicationDbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        public async Task<Tag> CreateAsync(Tag item) =>
            (await _dbContext.Tags.AddAsync(item)).Entity;


        public async Task Delete(Tag item) => await Task.Run(() =>
        {
            _dbContext.Tags.Remove(item);
        });

        public async Task<Tag> GetAsync(int id)
        {
            return await _dbContext.Tags.FirstOrDefaultAsync(t=>t.Id== id);
        }

        public async Task<int> GetCount()
        {
            return await _dbContext.Tags.CountAsync();
        }

        public async Task<IEnumerable<Tag>> GetItemsAsync()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag> UpdateAsync(Tag item) => await Task.Run(() =>
        {
            return _dbContext.Tags.Update(item).Entity;
        });

        public async Task<bool> IsExist(Tag item) => await Task.Run(() =>
        {
            var tag = _dbContext.Tags.FirstOrDefaultAsync(t => t.Id == item.Id);
            return tag != null;
        });

        public async Task AddTags(IEnumerable<Tag> items)
        {
            await _dbContext.Tags.AddRangeAsync(items);
        }
    }
}
