using AutoMapper;
using AutomapperTestProject.CustomValueResolver.Entities;
using AutomapperTestProject.CustomValueResolver.Models;

namespace AutomapperTestProject.CustomValueResolver.Resolver
{
    public class CustomResolver : IValueResolver<Source, Destination, int>
	{
		public int Resolve(Source source, Destination destination, int member, ResolutionContext context)
		{
			return source.Value1 + source.Value2;
		}
	}
}
