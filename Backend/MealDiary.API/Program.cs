using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.Extensions;
using MealDiary.API.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });
    builder.Services.AddSingleton(mapperConfig.CreateMapper());
    builder.Services.AddCors();
    
    builder.Services.RegisterServices();
}


var app = builder.Build();
{
    app.UseCors(b => b.AllowAnyHeader().WithOrigins("http://localhost:4200"));
    app.MapControllers();
    app.Run();
}

