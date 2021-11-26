using System.Threading.Tasks;
using DAL.Infrastructure.Interfaces;
using DAL.Model;

namespace DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {

        IRepository<Recommend> RecommendsRepository { get; }
        ITagRepository TagRepository { get; }
        IImageRepository ImageRepository { get; }   
        IGroupRepository GroupRepository { get; }
        IRepository<Comment> Commentrepository { get; }

        Task SaveAsync();
    }
}
