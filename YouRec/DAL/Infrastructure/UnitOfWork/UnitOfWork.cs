using DAL.Data;
using DAL.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace DAL.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._appDbContext = applicationDbContext;

        }

        private ApplicationDbContext _appDbContext;

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
