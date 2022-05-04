using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;
using AutomapperTestProject.CustomValueResolver.Models;
using AutomapperTestProject.CustomValueResolver.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutomapperTestProject.CustomValueResolver
{
    public class CustomValueResolverTests
    {
        [Fact]
        public void Do()
        {
            // Arrange
            var configuration = new MapperConfiguration(x => x.AddProfile<MyCustomValueResolverProfile>());
            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();

            var source = new Source
            {
                Value1 = 5,
                Value2 = 7
            };

            // Act
            var result = mapper.Map<Source, Destination>(source);

            // Assert
            Assert.Equal(12, result.Total);
        }
    }
}
