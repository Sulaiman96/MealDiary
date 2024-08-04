using AutoMapper;
using MealDiary.Core.Data;
using MealDiary.Core.Mappings;
using MealDiary.Core.Services;
using MealDiary.Core.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
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