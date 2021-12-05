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
    public class UserRepository : IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;

        }

        private ApplicationDbContext _applicationDbContext;

        public async Task<IEnumerable<AppUser>> GetUsersPaged(int page, int pageSize)
        {
            return await _applicationDbContext.Users.Skip(page * pageSize).Take(pageSize).ToArrayAsync();
        }



    }
}
