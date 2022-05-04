using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;
using AutomapperTestProject.CustomValueResolver.Models;
using AutomapperTestProject.CustomValueResolver.Resolver;

namespace AutomapperTestProject.CustomValueResolver.Profiles
{
    public class MyCustomValueResolverProfile : Profile
    {
        public MyCustomValueResolverProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom<CustomResolver>());
        }
    }
}
