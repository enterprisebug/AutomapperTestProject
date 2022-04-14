using AutoMapper;
using AutomapperTestProject.Unflattening.Entities;
using AutomapperTestProject.Unflattening.Models;
using AutomapperTestProject.Unflattening.Profiles;
using Xunit;

namespace AutomapperTestProject;

public class AutoMapperTest
{
    [Fact]
    public void Ensure_Unflattening()
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

        // Target Structure
        //var projectSpecificFactorModel = new ProjectSpecificFactorModel
        //{
        //    DiscountFactor = new DiscountFactorModel
        //    {
        //        DiscountSpecificFactor = new DiscountSpecificFactorModel
        //        {
        //            Periphery = 4
        //        },
        //        DiscountPreventiveMaintenanceFactor = new DiscountPreventiveMaintenanceFactorModel
        //        {
        //            Labor = 5
        //        }
        //    }
        //};

        var configuration = new MapperConfiguration(x => x.AddProfile<UnflatteningMappingProfile>());
        configuration.AssertConfigurationIsValid();
        var mapper = configuration.CreateMapper();

        // Act
        var actual = mapper.Map<ProjectSpecificFactorModel>(projectSpecificFactor);

        // Assert
        Assert.Equal(4, actual.DiscountFactor!.DiscountSpecificFactor.Periphery);
        Assert.Equal(5, actual.DiscountFactor!.DiscountPreventiveMaintenanceFactor.Labor);
    }
}