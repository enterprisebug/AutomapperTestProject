using System.Collections.Generic;
using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;

namespace AutomapperTestProject.CustomValueResolver.Profiles;

public static class AutoMapperExtensions
{
    public static TDestination Map<TDestination>(this IMapper map, Source src, List<MyKeyValuePair> keyValuePairs)
    {
        return map.Map<TDestination>(src, opts => opts.Items["KeyValuePairs"] = keyValuePairs);
    }
}