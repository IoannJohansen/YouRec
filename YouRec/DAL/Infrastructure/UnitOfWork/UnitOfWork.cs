using BLL.Interfaces;
using BLL.Services;
using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Infrastructure.Repository;
using DAL.Model;
using System.Threading.Tasks;

namespace DAL.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
            _recommendsRepository = new RecommendRepository(applicationDbContext);
            _tagRepository = new TagRepository(applicationDbContext);
            _imageRepository = new ImageRepository(applicationDbContext);
            _groupRepository = new GroupRepository(applicationDbContext);
            _commentrepository = new CommentRepository(applicationDbContext);
            _ratingRepository = new RatingRepository(applicationDbContext);
            _likeRepository = new LikeRepository(applicationDbContext);
            _recommendTagRepository = new RecommendTagRepository(applicationDbContext);
            _userRepository = new UserRepository(applicationDbContext);
        }

        private ApplicationDbContext _appDbContext;

        private readonly IRecommendRepository _recommendsRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ICommentRepository _commentrepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IRecommendTagRepository _recommendTagRepository;
        private readonly IUserRepository _userRepository;

        public IRecommendRepository RecommendsRepository => _recommendsRepository;
        public ITagRepository TagRepository => _tagRepository;
        public IImageRepository ImageRepository => _imageRepository;
        public IGroupRepository GroupRepository => _groupRepository;
        public ICommentRepository CommentRepository => _commentrepository;
        public IRatingRepository RatingRepository => _ratingRepository;
        public ILikeRepository LikeRepository => _likeRepository;
        public IRecommendTagRepository RecommendTagRepository => _recommendTagRepository;

        public IUserRepository UserRepository => _userRepository;

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
