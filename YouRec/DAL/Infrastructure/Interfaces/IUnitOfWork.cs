using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {


        Task SaveAsync();
    }
}
