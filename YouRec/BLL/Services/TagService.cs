using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<IEnumerable<Tag>> GetMostUsedTags(int amount)
        {
            return await unitOfWork.TagRepository.GetTopTagsAsync(amount);
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await unitOfWork.TagRepository.GetAllAsync();
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            return await unitOfWork.TagRepository.UpdateAsync(tag);
        }

        const int CountOfTagsToSelect = 20;

        public async Task<IEnumerable<Tag>> GetTopTags()
        {
            return await unitOfWork.TagRepository.GetTopTags(CountOfTagsToSelect);
        }

        public async Task<Tag> GetTagByName(string name)
        {
            return await unitOfWork.TagRepository.GetTagByName(name);
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            var createdTag = await unitOfWork.TagRepository.AddAsync(tag);
                await unitOfWork.SaveAsync();
            return createdTag;
        }
    }
}
