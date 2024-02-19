using MealDiary.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Extensions;

public static class ModelBuilderExtension
{
    public static void CreateRelationships(this ModelBuilder modelBuilder)
    {
        //TODO - Due to the Deletion Restriction applied to so many tables, need to handle the removal of records that have been orphaned manually.
        modelBuilder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        modelBuilder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        
        modelBuilder.Entity<Photo>()
            .HasOne(p => p.Meal)
            .WithMany(m => m.Photos)
            .HasForeignKey(p => p.MealId);
        
        modelBuilder.Entity<Meal>()
            .HasOne(m => m.Cuisine)
            .WithMany(c => c.Meals)
            .HasForeignKey(m => m.CuisineId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Meal>()
            .HasOne(m => m.AppUser)
            .WithMany(u => u.Meals)
            .HasForeignKey(m => m.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Meal>()
            .HasOne(m => m.Restaurant)
            .WithMany(r => r.Meals)
            .HasForeignKey(m => m.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MealCollection>()
            .HasOne(mc => mc.AppUser)
            .WithMany(au => au.MealCollection)
            .HasForeignKey(mc => mc.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<MealIngredient>()
            .HasKey(mi => new { mi.MealId, mi.IngredientId });

        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Meal)
            .WithMany(m => m.MealIngredients)
            .HasForeignKey(mi => mi.MealId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Ingredient)
            .WithMany(i => i.MealIngredients)
            .HasForeignKey(mi => mi.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MealMealCollection>()
            .HasKey(mmc => new {mmc.MealId, mmc.MealCollectionId});

        modelBuilder.Entity<MealMealCollection>()
            .HasOne(mmc => mmc.Meal)
            .WithMany(m => m.MealCollections)
            .HasForeignKey(mmc => mmc.MealId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<MealMealCollection>()
            .HasOne(mmc => mmc.MealCollection)
            .WithMany(m => m.Meals)
            .HasForeignKey(mmc => mmc.MealCollectionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SharedMeal>()
            .HasOne(sm => sm.Meal)
            .WithMany(m => m.SharedMeals) 
            .HasForeignKey(sm => sm.MealId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SharedMeal>()
            .HasOne(sm => sm.SharedByAppUser)
            .WithMany(u => u.SharedMeals)
            .HasForeignKey(sm => sm.SharedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SharedMeal>()
            .HasOne(sm => sm.SharedWithAppUser)
            .WithMany(u => u.ReceivedMeals) 
            .HasForeignKey(sm => sm.SharedWithUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SharedMealCollection>()
            .HasOne(smc => smc.MealCollection)
            .WithMany(mc => mc.SharedMealCollections) 
            .HasForeignKey(smc => smc.MealCollectionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SharedMealCollection>()
            .HasOne(smc => smc.SharedByAppUser)
            .WithMany(u => u.SharedMealCollections) 
            .HasForeignKey(smc => smc.SharedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SharedMealCollection>()
            .HasOne(smc => smc.SharedWithAppUser)
            .WithMany(u => u.ReceivedMealCollections) 
            .HasForeignKey(smc => smc.SharedWithUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public static void AddUniqueConstraint(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>()
            .HasIndex(i => i.Name)
            .IsUnique();

        modelBuilder.Entity<Cuisine>()
            .HasIndex(i => i.Name)
            .IsUnique();

        modelBuilder.Entity<Restaurant>()
            .HasIndex(i => i.Name)
            .IsUnique();
    }
}