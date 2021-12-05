using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ImageService : BaseService, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        

        public async Task<Image> AddImage(Image image)
        {
            var newImage = await unitOfWork.ImageRepository.AddAsync(image);
            await unitOfWork.SaveAsync();
            return newImage;
        }

        public async Task DeleteByLink(string link)
        {
            await unitOfWork.ImageRepository.DeleteByLinkAsync(link);
        }
    }
}