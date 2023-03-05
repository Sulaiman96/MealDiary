using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Extensions;

public static class ModelBuilderExtension
{
    public static void CreateRelationships(this ModelBuilder modelBuilder)
    {
        //Define the many-to-many relationship between Meal and Ingredient
        modelBuilder.Entity<MealIngredient>()
            .HasKey(mi => new {mi.MealId, mi.IngredientId});
        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Meal)
            .WithMany(m => m.MealIngredients)
            .HasForeignKey(mi => mi.MealId);
        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Ingredient)
            .WithMany(mi => mi.MealIngredients)
            .HasForeignKey(mi => mi.IngredientId);
        
        //Define the one-to-many relationship between User and Meal
        modelBuilder.Entity<User>()
            .HasMany(u => u.Meals)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
        
        //Define the one-to-many relationship between User and MealCollection
        modelBuilder.Entity<User>()
            .HasMany(u => u.MealCollection)
            .WithOne(mc => mc.User)
            .HasForeignKey(m => m.UserId);
        
        //Define the one-to-many relationship between Cuisine and Meal
        modelBuilder.Entity<Cuisine>()
            .HasMany(c => c.Meals)
            .WithOne(m => m.Cuisine)
            .HasForeignKey(m => m.CuisineId);
        
        //Define the one-to-many relationship between MealCollection and Meal
        modelBuilder.Entity<MealCollection>()
            .HasMany(mc => mc.Meals)
            .WithOne(m => m.MealCollection)
            .HasForeignKey(m => m.MealCollectionId);
    }

    public static void AddUniqueConstraint(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>()
            .HasIndex(i => i.Name)
            .IsUnique();

        modelBuilder.Entity<Cuisine>()
            .HasIndex(i => i.Name)
            .IsUnique();
    }
}