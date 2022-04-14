using AutoMapper;
using Xunit;

namespace AutomapperTestProject;

#region Entities

public class ProjectSpecificFactor
{
    public DiscountFactor DiscountFactor { get; set; } = null!;
}

public class DiscountFactor
{
    public DiscountPreventiveMaintenanceFactor DiscountPreventiveMaintenanceFactor { get; set; } = null!;
    public Percentage Periphery { get; set; } = null!;
}

public class DiscountPreventiveMaintenanceFactor
{
    public Percentage Labor { get; set; } = null!;
}

public class Percentage
{
    public decimal Value { get; set; }
}

#endregion

#region Models

public class ProjectSpecificFactorModel
{
    public DiscountFactorModel? DiscountFactor { get; set; }
}

public class DiscountFactorModel
{
    public DiscountPreventiveMaintenanceFactorModel DiscountPreventiveMaintenanceFactor { get; set; } = new();
    public DiscountSpecificFactorModel DiscountSpecificFactor { get; set; } = new();
}

public class DiscountPreventiveMaintenanceFactorModel
{
    public decimal Labor { get; set; }
}

public class DiscountSpecificFactorModel
{
    public decimal Periphery { get; set; }
}

#endregion

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Percentage, decimal>().ConvertUsing(x => x.Value);
        CreateMap<ProjectSpecificFactor, ProjectSpecificFactorModel>();
        CreateMap<DiscountPreventiveMaintenanceFactor, DiscountPreventiveMaintenanceFactorModel>();
    }
}

public class AutoMapper
{
    [Fact]
    public void Ensure_Configs_Valid()
    {
        // Arrange
        var source = new ProjectSpecificFactor
        {
            DiscountFactor = new DiscountFactor
            {
                Periphery = new Percentage { Value = 4 },
                DiscountPreventiveMaintenanceFactor = new DiscountPreventiveMaintenanceFactor
                {
                    Labor = new Percentage { Value = 5 }
                }
            }
        };

        var configuration = new MapperConfiguration(x => x.AddProfile<MappingProfile>());

        // Act && Assert
        configuration.AssertConfigurationIsValid();
    }
}