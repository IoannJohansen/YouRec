using DAL.Model;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {

        IRecommendRepository RecommendsRepository { get; }
        ITagRepository TagRepository { get; }
        IImageRepository ImageRepository { get; }
        IGroupRepository GroupRepository { get; }
        IRepository<Comment> Commentrepository { get; }
        IRatingRepository RatingRepository { get; }
        ILikeRepository LikeRepository { get; }

        Task SaveAsync();
    }
}
