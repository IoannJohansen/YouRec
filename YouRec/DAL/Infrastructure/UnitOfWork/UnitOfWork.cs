﻿using DAL.Data;
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
        }

        private ApplicationDbContext _appDbContext;

        private IRecommendRepository _recommendsRepository;
        private ITagRepository _tagRepository;
        private IImageRepository _imageRepository;
        private IGroupRepository _groupRepository;
        private ICommentRepository _commentrepository;
        private IRatingRepository _ratingRepository;
        private ILikeRepository _likeRepository;

        public IRecommendRepository RecommendsRepository => _recommendsRepository;
        public ITagRepository TagRepository => _tagRepository;
        public IImageRepository ImageRepository => _imageRepository;
        public IGroupRepository GroupRepository => _groupRepository;
        public ICommentRepository Commentrepository => _commentrepository;
        public IRatingRepository RatingRepository => _ratingRepository;
        public ILikeRepository LikeRepository => _likeRepository;


        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
