using MealDiary.API.Data;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class MealService : BaseService, IMealService
{
    public MealService(DataContext context) : base(context)
    {
    }
    
    public Task<Meal> CreateMealAsync(Meal mealRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMealAsync(Meal mealRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<Meal?> GetMealByIdAsync(int id)
    {
        return await _context.Meals
            .Include(m => m.Cuisine)
            .Include(m => m.MealCollection)
            .Include(m => m.User)
            .Include(m => m.Ingredients).ThenInclude(m => m.Ingredient)
            .Include(m => m.Photos)
            .FirstOrDefaultAsync(i => i.Id == id);
    }
    
    public async Task<Meal?> GetMealByNameAsync(string mealName)
    {
        return await _context.Meals
            .Include(m => m.Cuisine)
            .Include(m => m.MealCollection)
            .Include(m => m.User)
            .Include(m => m.Ingredients).ThenInclude(m => m.Ingredient)
            .Include(m => m.Photos)
            .FirstOrDefaultAsync(i => i.Name == mealName);
    }

    public async Task<IEnumerable<Meal>> GetMeals()
    {
        return await _context.Meals
            .Include(m => m.Cuisine)
            .Include(m => m.MealCollection)
            .Include(m => m.User)
            .Include(m => m.Ingredients).ThenInclude(m => m.Ingredient)
            .Include(m => m.Photos)
            .ToListAsync();
    }
}