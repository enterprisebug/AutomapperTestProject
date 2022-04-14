using AutoMapper;
using AutomapperTestProject.Unflattening.Entities;
using AutomapperTestProject.Unflattening.Models;

namespace AutomapperTestProject.Unflattening.Profiles;

public class UnflatteningMappingProfile : Profile
{
    public UnflatteningMappingProfile()
    {
        CreateMap<Percentage, decimal>().ConvertUsing(x => x.Value);
        CreateMap<ProjectSpecificFactor, ProjectSpecificFactorModel>();
        CreateMap<DiscountFactor, DiscountSpecificFactorModel>();
        CreateMap<DiscountFactor, DiscountFactorModel>()
            .ForMember(dest => dest.DiscountSpecificFactor, opts => opts.MapFrom(src => src))
            ;
        CreateMap<DiscountPreventiveMaintenanceFactor, DiscountPreventiveMaintenanceFactorModel>();
    }
}