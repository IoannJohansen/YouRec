using AutoMapper;
using DAL.Model;
using System.Collections.Generic;
using System.Linq;
using YouRecWeb.Model;

namespace YouRecWeb.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recommend, RecommendViewModel>(MemberList.None).ForMember(m => m.AverageUserRating, vm => vm.MapFrom(r => r.Ratings.Sum(x => x.Rate) / r.Ratings.Count)).ForMember(m => m.Group, vm => vm.MapFrom(r => r.Group.GroupName)).ForMember(m => m.AuthorName, vm => vm.MapFrom(r => r.User.UserName));

        }
    }
}
