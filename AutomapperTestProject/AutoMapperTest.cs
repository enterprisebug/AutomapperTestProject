using AutoMapper;
using AutomapperTestProject.Entities;
using AutomapperTestProject.Models;
using AutomapperTestProject.Profiles;
using Xunit;

namespace AutomapperTestProject;

public class AutoMapperTest
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
        configuration.AssertConfigurationIsValid();
        var mapper = configuration.CreateMapper();

        // Act
        var actual = mapper.Map<ProjectSpecificFactorModel>(source);

        // Assert
        Assert.Equal(4, actual.DiscountFactor!.DiscountSpecificFactor.Periphery);
        Assert.Equal(5, actual.DiscountFactor!.DiscountPreventiveMaintenanceFactor.Labor);
    }
}