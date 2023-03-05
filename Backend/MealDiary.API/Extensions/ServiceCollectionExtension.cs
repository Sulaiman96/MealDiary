using MealDiary.API.Services;

namespace MealDiary.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMealService, MealService>();
        services.AddScoped<IIngredientService, IngredientService>();
        
    }
}