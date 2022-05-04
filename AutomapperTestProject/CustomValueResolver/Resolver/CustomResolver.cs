using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;
using AutomapperTestProject.CustomValueResolver.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutomapperTestProject.CustomValueResolver.Resolver
{
    public class CustomResolver : IValueResolver<Source, Destination, string>
	{
		public string Resolve(Source source, Destination destination, string member, ResolutionContext context)
		{
			var myKeyValuePairList = context.Items["KeyValuePairs"] as List<MyKeyValuePair>;

			if (myKeyValuePairList != null) {
				var existingValue = myKeyValuePairList.FirstOrDefault(x => x.Id == source.Id);
				if (existingValue != null)
				{
					return myKeyValuePairList.First(x => x.Id == source.Id).Name;
				}
				return $"Unknown Pair ({source.Id})";
			}
			return $"Unknown Pair ({source.Id})";
		}
	}
}
