using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealDiary.Core.Data;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Services.Implementation;

public class MealService(ApplicationDbContext context, IMapper mapper) : BaseService(context, mapper), IMealService
{
    public Task<Meal> CreateMealAsync(Meal mealRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMealAsync(Meal mealRequest)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Meal?> GetMealByNameAsync(Expression<Func<Meal, bool>> condition)
    {
        return await Context.Meals
            .Include(m => m.Restaurant)
            .Include(m => m.AppUser)
            .Include(m => m.Cuisine)
            .Include(m => m.Photos)
            .Include(m => m.MealCollections)!.ThenInclude(m => m.MealCollection)
            .Include(m => m.MealIngredients)!.ThenInclude(m => m.Ingredient)
            .FirstOrDefaultAsync(condition);
    }

    public async Task<IEnumerable<Meal>> GetMeals()
    {
        return await Context.Meals
            .Include(m => m.Restaurant)
            .Include(m => m.AppUser)
            .Include(m => m.Cuisine)
            .Include(m => m.Photos)
            .Include(m => m.MealCollections)!.ThenInclude(m => m.MealCollection)
            .Include(m => m.MealIngredients)!.ThenInclude(m => m.Ingredient)
            .ToListAsync();
    }

    public async Task<IEnumerable<MealResponse?>> GetMealResponseAsync()
    {
        return await Context.Meals
            .ProjectTo<MealResponse>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<MealResponse?> GetSingleMealResponseAsync(Expression<Func<Meal, bool>> condition)
    {
        return await Context.Meals
            .Where(condition)
            .ProjectTo<MealResponse>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}