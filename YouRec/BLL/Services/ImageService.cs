using AutoMapper;
using BLL.Interfaces;
using BLL.Services.Base;
using DAL.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ImageService : BaseService, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }



    }
}