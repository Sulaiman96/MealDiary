using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public interface IMealService
{
    Task<Meal> CreateMealAsync(Meal mealRequest);
    Task<bool> DeleteMealAsync(Meal mealRequest); 
    Task<Meal?> GetMealByIdAsync(int id);
    Task<Meal?> GetMealByNameAsync(string mealName);
    Task<IEnumerable<Meal>> GetMeals();
}