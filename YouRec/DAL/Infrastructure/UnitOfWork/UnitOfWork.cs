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
            _tagRepository = new TagRepository(applicationDbContext);

        }

        private ApplicationDbContext _appDbContext;

        private IGroupRepository _groupRepository;

        private ITagRepository _tagRepository;

        public IGroupRepository GroupRepository => _groupRepository;

        public ITagRepository TagRepository => _tagRepository;



        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
