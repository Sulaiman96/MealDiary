using MealDiary.API.Entities;
using MealDiary.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealCollection> MealCollections { get; set; }
    public DbSet<MealIngredient> MealIngredients { get; set; }
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.CreateRelationships();
        
        modelBuilder.AddUniqueConstraint();
    }
}