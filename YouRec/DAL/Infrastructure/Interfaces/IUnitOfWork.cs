using System.Threading.Tasks;
using DAL.Infrastructure.Interfaces;

namespace DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {

        IRecommendsRepository RecommendsRepository { get; }

        Task SaveAsync();
    }
}
