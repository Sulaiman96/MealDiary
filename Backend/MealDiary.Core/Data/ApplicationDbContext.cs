using MealDiary.Core.Data.Models;
using MealDiary.Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Data;

//Note To Self: All of these implementations are simply due to wanting to use integer as key from Identity Provider.
public class ApplicationDbContext(DbContextOptions options)
    : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
{
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealCollection> MealCollections { get; set; }
    public DbSet<MealIngredient> MealIngredients { get; set; }
    public DbSet<MealMealCollection> MealMealCollections { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<SharedMeal> SharedMeals { get; set; }
    public DbSet<SharedMealCollection> SharedMealCollections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.CreateRelationships();
        
        modelBuilder.AddUniqueConstraint();
    }
}