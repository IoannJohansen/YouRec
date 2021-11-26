using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<Comment> CreateAsync(Comment item)
        {
            return (await _applicationDbContext.AddAsync(item)).Entity;
        }

        public async Task DeleteAsync(Comment item) => await Task.Run(() =>
        {
            _applicationDbContext.Comments.Remove(item);
        });

        public async Task<IEnumerable<Comment>> GetAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await _applicationDbContext.Comments.Where(predicate).ToListAsync();
        }

        public async Task<Comment> GetAsync(int id)
        {
            return await _applicationDbContext.Comments.FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _applicationDbContext.Comments.CountAsync();
        }

        public async Task<IEnumerable<Comment>> GetItemsAsync()
        {
            return await _applicationDbContext.Comments.ToListAsync();
        }

        public async Task<Comment> UpdateAsync(Comment item) => await Task.Run(() =>
        {
            return _applicationDbContext.Comments.Update(item).Entity;
        });
    }
}
