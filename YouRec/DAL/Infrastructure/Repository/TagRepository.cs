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
    public class TagRepository : ITagRepository
    {
        public TagRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<Tag> AddAsync(Tag tag)
        {
            return (await _applicationDbContext.Tags.AddAsync(tag)).Entity;
        }

        public async Task AddFromListAsync(List<Tag> tags)
        {
            await _applicationDbContext.Tags.AddRangeAsync(tags);
        }

        public async Task DeleteAsync(int id) => await Task.Run(() =>
        {
            var item = _applicationDbContext.Tags.Find(id);
            _applicationDbContext.Tags.Remove(item);
        });

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _applicationDbContext.Tags.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetTopTagsAsync(int amount)
        {
            return await _applicationDbContext.Tags.Take(amount).ToListAsync();
        }

        public async Task<bool> TagIsExistAsync(Tag tag) => await Task.Run(() =>
        {
            var tagInDb = _applicationDbContext.Tags.FirstOrDefault(t => t.Id == tag.Id);
            return tagInDb != null;
        });

        public async Task<Tag> UpdateAsync(Tag tag) => await Task.Run(() =>
        {
            return _applicationDbContext.Tags.Update(tag).Entity;
        });

        public async Task<IEnumerable<Tag>> GetTopTags(int amount)
        {
            return await _applicationDbContext.Tags.OrderByDescending(t => t.RecommendTags.Count()).Take(amount).Include(t=>t.RecommendTags).ToListAsync();
        }

        public async Task<Tag> GetTagByName(string name)
        {
            return await _applicationDbContext.Tags.FirstOrDefaultAsync(t=>t.TagName==name);
        }
    }
}
