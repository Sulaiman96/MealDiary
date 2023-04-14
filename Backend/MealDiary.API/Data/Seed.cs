using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Data;

public class Seed
{
    public static async Task SeedCuisine(DataContext context)
    {
        if (await context.Cuisines.AnyAsync())
            return;

        var cuisineData = await File.ReadAllTextAsync("Data/Seed Data/CuisineSeedData.json");

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

        var cuisines = JsonSerializer.Deserialize<List<Cuisine>>(cuisineData, options);

        foreach (var cuisine in cuisines)
        {
            context.Cuisines.Add(cuisine);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedIngredient(DataContext context)
    {
        if (await context.Ingredients.AnyAsync())
            return;

        var ingredientData = await File.ReadAllTextAsync("Data/Seed Data/IngredientSeedData.json");

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

        var ingredients = JsonSerializer.Deserialize<List<Ingredient>>(ingredientData, options);

        foreach (var ingredient in ingredients)
        {
            context.Ingredients.Add(ingredient);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedUser(DataContext context)
    {
        if (await context.Users.AnyAsync())
            return;

        var userData = await File.ReadAllTextAsync("Data/Seed Data/UserSeedData.json");

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

        var users = JsonSerializer.Deserialize<List<User>>(userData, options);

        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();

            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
            user.PasswordSalt = hmac.Key;
            
            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }
    
    public static async Task SeedMealCollection(DataContext context)
    {
        if (await context.MealCollections.AnyAsync())
            return;

        var mealCollectionData = await File.ReadAllTextAsync("Data/Seed Data/MealCollectionSeedData.json");

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

        var mealCollections = JsonSerializer.Deserialize<List<MealCollection>>(mealCollectionData, options);

        foreach (var mealCollection in mealCollections)
        {
            context.MealCollections.Add(mealCollection);
        }

        await context.SaveChangesAsync();
    }
    
    public static async Task SeedMeal(DataContext context)
    {
        if (await context.Meals.AnyAsync())
            return;

        var mealData = await File.ReadAllTextAsync("Data/Seed Data/MealSeedData.json");

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

        var meals = JsonSerializer.Deserialize<List<Meal>>(mealData, options);

        foreach (var meal in meals)
        {
            context.Meals.Add(meal);
        }

        await context.SaveChangesAsync();
    }
    
    public static async Task SeedMealIngredients(DataContext context)
    {
        if (await context.MealIngredients.AnyAsync())
            return;

        var mealIngredientsData = await File.ReadAllTextAsync("Data/Seed Data/MealIngredientsSeedData.json");

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

        var mealIngredients = JsonSerializer.Deserialize<List<MealIngredient>>(mealIngredientsData, options);

        foreach (var mealIngredient in mealIngredients)
        {
            context.MealIngredients.Add(mealIngredient);
        }

        await context.SaveChangesAsync();
    }
}