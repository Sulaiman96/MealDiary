using MealDiary.Core.Data;
using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public class MealService(ApplicationDbContext context) : BaseService(context), IMealService
{
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
        return null;
        // return await Context.Meals
        //     .Include(m => m.Cuisine)
        //     .Include(m => m.MealCollection)
        //     .Include(m => m.User)
        //     .Include(m => m.Ingredients).ThenInclude(m => m.Ingredient)
        //     .Include(m => m.Photos)
        //     .FirstOrDefaultAsync(i => i.Id == id);
    }
    
    public async Task<Meal?> GetMealByNameAsync(string mealName)
    {
        return null;
        // return await Context.Meals
        //     .Include(m => m.Cuisine)
        //     .Include(m => m.MealCollection)
        //     .Include(m => m.User)
        //     .Include(m => m.Ingredients).ThenInclude(m => m.Ingredient)
        //     .Include(m => m.Photos)
        //     .FirstOrDefaultAsync(i => i.Name == mealName);
    }

    public async Task<IEnumerable<Meal>> GetMeals()
    {
        return null;
        // return await Context.Meals
        //     .Include(m => m.Cuisine)
        //     .Include(m => m.MealCollection)
        //     .Include(m => m.User)
        //     .Include(m => m.Ingredients).ThenInclude(m => m.Ingredient)
        //     .Include(m => m.Photos)
        //     .ToListAsync();
    }
}