using DAL.Data;
using DAL.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace DAL.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext applicationDbContext, IRecommendsRepository recommendsRepository)
        {
            _appDbContext = applicationDbContext;
            _recommendsRepository = recommendsRepository;
        }
        
        private ApplicationDbContext _appDbContext;

        private IRecommendsRepository _recommendsRepository;

        public IRecommendsRepository RecommendsRepository => _recommendsRepository;

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
