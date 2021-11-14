using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    public class GroupRepository : IGroupRepository
    {
        public GroupRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        public async Task AddAsync(Group group)
        {
            await _dbContext.Groups.AddAsync(group);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _dbContext.Groups.ToListAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _dbContext.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
