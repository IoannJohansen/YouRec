using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._appDbContext = applicationDbContext;
            _groupRepository = new GroupRepository(applicationDbContext);
        }

        private ApplicationDbContext _appDbContext;

        private IGroupRepository _groupRepository;



        public IGroupRepository GroupRepository => _groupRepository;

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
