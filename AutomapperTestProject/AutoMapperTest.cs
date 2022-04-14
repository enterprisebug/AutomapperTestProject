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
        var projectSpecificFactor = new ProjectSpecificFactor
        {
            DiscountFactor = new DiscountFactor
            {
                Periphery = new Percentage
                {
                    Value = 4
                },
                DiscountPreventiveMaintenanceFactor = new DiscountPreventiveMaintenanceFactor
                {
                    Labor = new Percentage
                    {
                        Value = 5
                    }
                }
            }
        };

        var projectSpecificFactorModel = new ProjectSpecificFactorModel
        {
            DiscountFactor = new DiscountFactorModel
            {
                DiscountSpecificFactor = new DiscountSpecificFactorModel
                {
                    Periphery = 4
                },
                DiscountPreventiveMaintenanceFactor = new DiscountPreventiveMaintenanceFactorModel
                {
                    Labor = 5
                }
            }
        };

        var configuration = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
        configuration.AssertConfigurationIsValid();
        var mapper = configuration.CreateMapper();

        // Act
        var actual = mapper.Map<ProjectSpecificFactorModel>(projectSpecificFactor);

        // Assert
        Assert.Equal(4, actual.DiscountFactor!.DiscountSpecificFactor.Periphery);
        Assert.Equal(5, actual.DiscountFactor!.DiscountPreventiveMaintenanceFactor.Labor);
    }
}