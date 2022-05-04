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
    public class MyKeyValuePair {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomValueResolverTests
    {
        [Fact]
        public void Do()
        {
            // Arrange
            var configuration = new MapperConfiguration(x => x.AddProfile<MyCustomValueResolverProfile>());
            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();

            var myList = new List<MyKeyValuePair>
            {
                new MyKeyValuePair { Id = 1, Name = "Herp" },
                new MyKeyValuePair { Id = 2, Name = "Derp" },
            };

            var source = new Source
            {
                Id = 2
            };

            // Act
            var result = mapper.Map<Destination>(source, myList);

            // Assert
            Assert.Equal("Derp", result.Name);
        }
    }

    public static class AutoMapperExtensions
    {
        public static Destination Map<Destination>(
            this IMapper map,
            Source src,
            List<MyKeyValuePair> keyValuePairs
        )
        {
            return map.Map<Destination>(src, opts => opts.Items["KeyValuePairs"] = keyValuePairs);
        }
    }
}
