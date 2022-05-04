using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;
using AutomapperTestProject.CustomValueResolver.Models;

namespace AutomapperTestProject.CustomValueResolver.Resolver;

public class CustomResolver : IValueResolver<Source, Destination, string>
{
    public string Resolve(Source source, Destination destination, string member, ResolutionContext context)
    {
        if (context.Items["KeyValuePairs"] is List<MyKeyValuePair> myKeyValuePairList)
        {
            var existingValue = myKeyValuePairList.FirstOrDefault(x => x.Id == source.Id);
            return existingValue != null ? existingValue.Name : $"Unknown Pair ({source.Id})";
        }

        return $"Unknown Pair ({source.Id})";
    }
}