using MealDiary.Core.Data;
using MealDiary.Core.Data.Models;
using MealDiary.Core.Extensions;
using MealDiary.Core.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddCors();
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddIdentityServices(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:3000", "http://localhost:3000"));
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        await context.Database.MigrateAsync();
        
        await Seed.SeedUser(userManager);
        await Seed.SeedRestaurant(context);
        await Seed.SeedCuisine(context);
        await Seed.SeedIngredient(context);
        await Seed.SeedMealCollection(context);
        await Seed.SeedMeal(context);
        await Seed.SeedPhoto(context);
        
        //With Relationships
        await Seed.SeedMealIngredients(context);
        await Seed.SeedMealMealCollections(context);
        
        // await Seed.SeedUserRelationships(context);

    }
    catch (Exception ex)
    {
        var logger = services.GetService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migration");
    }
    
    app.Run();
}
