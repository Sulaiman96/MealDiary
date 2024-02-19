using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MealDiary.Core.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Data;

public class Seed
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    
    public static async Task SeedCuisine(ApplicationDbContext context)
    {
        if (await context.Cuisines.AnyAsync())
            return;

        var cuisineData = await File.ReadAllTextAsync("Data/Seed Data/CuisineSeedData.json");

        var cuisines = JsonSerializer.Deserialize<List<Cuisine>>(cuisineData, Options);

        foreach (var cuisine in cuisines)
        {
            context.Cuisines.Add(cuisine);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedIngredient(ApplicationDbContext context)
    {
        if (await context.Ingredients.AnyAsync())
            return;

        var ingredientData = await File.ReadAllTextAsync("Data/Seed Data/IngredientSeedData.json");

        var ingredients = JsonSerializer.Deserialize<List<Ingredient>>(ingredientData, Options);

        foreach (var ingredient in ingredients)
        {
            context.Ingredients.Add(ingredient);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedUser(UserManager<AppUser> userManager)
    {
        if (await userManager.Users.AnyAsync())
            return;
    
        var userData = await File.ReadAllTextAsync("Data/Seed Data/UserSeedData.json");
        
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, Options);
    
        foreach (var user in users)
        {
            user.UserName = user.UserName?.ToLower();
            user.Email = user.Email?.ToLower();
            
            await userManager.CreateAsync(user, "Password1");
        }
    }
    
    public static async Task SeedMealCollection(ApplicationDbContext context, UserManager<AppUser> userManager)
    {
        if (await context.MealCollections.AnyAsync())
            return;

        var mealCollectionData = await File.ReadAllTextAsync("Data/Seed Data/MealCollectionSeedData.json");

        var mealCollections = JsonSerializer.Deserialize<List<MealCollection>>(mealCollectionData, Options);

        foreach (var mealCollection in mealCollections)
        {
            var existingUser = userManager.Users.FirstOrDefault(user => user.Id == mealCollection.AppUserId);
            if (existingUser != null)
            {
                mealCollection.AppUser = existingUser;
            }
            context.MealCollections.Add(mealCollection);
        }

        await context.SaveChangesAsync();
    }
    
    public static async Task SeedMeal(ApplicationDbContext context, UserManager<AppUser> userManager )
    {
        if (await context.Meals.AnyAsync())
            return;

        var mealData = await File.ReadAllTextAsync("Data/Seed Data/MealSeedData.json");
        
        var meals = JsonSerializer.Deserialize<List<Meal>>(mealData, Options);

        foreach (var meal in meals)
        {
            var existingUser = userManager.Users.FirstOrDefault(user => user.Id == meal.AppUserId);
            if (existingUser != null)
            {
                meal.AppUser = existingUser;
            }
            context.Meals.Add(meal);
        }

        await context.SaveChangesAsync();
    }
    
    public static async Task SeedMealIngredients(ApplicationDbContext context)
    {
        if (await context.MealIngredients.AnyAsync())
            return;
    
        var mealIngredientsData = await File.ReadAllTextAsync("Data/Seed Data/MealIngredientsSeedData.json");
    
        var mealIngredients = JsonSerializer.Deserialize<List<MealIngredient>>(mealIngredientsData, Options);
    
        foreach (var mealIngredient in mealIngredients)
        {
            context.MealIngredients.Add(mealIngredient);
        }
    
        await context.SaveChangesAsync();
    }

    public static async Task SeedMealMealCollections(ApplicationDbContext context)
    {
        if (await context.MealMealCollections.AnyAsync())
            return;
    
        var mealMealCollectionData = await File.ReadAllTextAsync("Data/Seed Data/MealMealCollectionSeedData.json");
    
        var mealMealCollections = JsonSerializer.Deserialize<List<MealMealCollection>>(mealMealCollectionData, Options);
    
        foreach (var mealMealcollection in mealMealCollections)
        {
            var meal = await context.Meals.FindAsync(mealMealcollection.MealId);
            var mealCollection = await context.MealCollections.FindAsync(mealMealcollection.MealCollectionId);
            if (meal != null && mealCollection != null)
            {
                mealMealcollection.Meal = meal;
                mealMealcollection.MealCollection = mealCollection;
                context.MealMealCollections.Add(mealMealcollection);
            }
            else
            {
                Console.WriteLine($"Skipping MealMealCollection with MealId {mealMealcollection.MealId} and MealCollectionId {mealMealcollection.MealCollectionId} due to missing Meal or MealCollection.");
            }
        }
    
        await context.SaveChangesAsync();
    }

    public static async Task SeedPhoto(ApplicationDbContext context)
    {
        if (await context.Photos.AnyAsync())
            return;

        var photoData = await File.ReadAllTextAsync("Data/Seed Data/PhotoSeedData.json");

        var photos = JsonSerializer.Deserialize<List<Photo>>(photoData, Options);

        foreach (var photo in photos)
        {
            context.Photos.Add(photo);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedRestaurant(ApplicationDbContext context)
    {
        if (await context.Restaurants.AnyAsync())
            return;

        var restaurantData = await File.ReadAllTextAsync("Data/Seed Data/RestaurantSeedData.json");

        var restaurants = JsonSerializer.Deserialize<List<Restaurant>>(restaurantData, Options);

        foreach (var restaurant in restaurants)
        {
            context.Restaurants.Add(restaurant);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedUserRelationships(ApplicationDbContext context)
    {
        throw new NotImplementedException();
    }

    public static void ResetAutoIncrement(ApplicationDbContext context)
    {
        context.ResetAutoIncrementValues();
    }

}