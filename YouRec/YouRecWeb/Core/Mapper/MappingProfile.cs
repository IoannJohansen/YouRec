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
            CreateMap<Recommend, RecommendViewModel>().ForMember(m => m.AverageUserRating,  memberOptions =>
            {
                memberOptions.PreCondition(x=>x.Ratings.Count > 0);
                memberOptions.MapFrom(r => r.Ratings.Sum(x => x.Rate) / r.Ratings.Count);
            }).ForMember(m => m.Group, vm => vm.MapFrom(r => r.Group.GroupName)).ForMember(m => m.AuthorName, vm => vm.MapFrom(r => r.User.UserName));
            
            CreateMap<Tag, TagViewModel>().ForMember(m => m.Value, f => f.MapFrom(m => m.TagName)).ForMember(m=>m.Count, vm => vm.MapFrom(m=>m.RecommendTags.Count));

            CreateMap<Recommend, RecommendDescriptionViewModel>().ForMember(m => m.Tags, vm => vm.MapFrom(f => f.RecommendTags.Select(t => t.Tag.TagName))).ForMember(m => m.GroupName, vm => vm.MapFrom(f => f.Group.GroupName)).ForMember(t => t.ImageLinks, vm => vm.MapFrom(f => f.Images)).ForMember(t=>t.UserName, vm => vm.MapFrom(t => t.User.UserName));


        }
    }
}
