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
    public class GroupRepository : IGroupRepository
    {
        public GroupRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;

        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _applicationDbContext.Groups.ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Groups.FindAsync(id);
        }
    }
}
