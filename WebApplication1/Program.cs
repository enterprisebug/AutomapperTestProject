using AutoMapper;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.

var app = builder.Build();