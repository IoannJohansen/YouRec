using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task AddTagsRange(List<Tag> tag)
        {
            await unitOfWork.TagRepository.AddFromListAsync(tag);
        }

        public async Task<IEnumerable<Tag>> GetTags(int amount)
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
    }
}
