using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.Mappings;
using MealDiary.API.Services;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMealService, MealService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}