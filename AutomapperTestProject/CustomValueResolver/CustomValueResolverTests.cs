using System.Collections.Generic;
using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;
using AutomapperTestProject.CustomValueResolver.Models;
using AutomapperTestProject.CustomValueResolver.Profiles;
using Xunit;

namespace AutomapperTestProject.CustomValueResolver;

public record MyKeyValuePair(int Id, string Name);

public class CustomValueResolverTests
{
    [Fact]
    public void Ensure_MyCustomValueResolver()
    {
        // Arrange
        var configuration = new MapperConfiguration(x => x.AddProfile<MyCustomValueResolverProfile>());
        configuration.AssertConfigurationIsValid();
        var mapper = configuration.CreateMapper();

        var myKeyValuePairs = new List<MyKeyValuePair>
        {
            new(1, "Herp"), new(2, "Derp")
        };

        var source = new Source
        {
            Id = 2
        };

        // Act
        var result = mapper.Map<Destination>(source, myKeyValuePairs);

        // Assert
        Assert.Equal("Derp", result.Name);
    }
}