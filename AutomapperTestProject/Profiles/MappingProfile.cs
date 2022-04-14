using AutoMapper;
using AutomapperTestProject.Entities;
using AutomapperTestProject.Models;

namespace AutomapperTestProject.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Percentage, decimal>().ConvertUsing(x => x.Value);
        CreateMap<ProjectSpecificFactor, ProjectSpecificFactorModel>();
        CreateMap<DiscountFactor, DiscountFactorModel>();
        CreateMap<DiscountPreventiveMaintenanceFactor, DiscountPreventiveMaintenanceFactorModel>();
    }
}