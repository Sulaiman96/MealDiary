using System.Linq.Expressions;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public interface IMealService
{
    Task<Meal> CreateMealAsync(Meal mealRequest);
    Task<bool> DeleteMealAsync(Meal mealRequest); 
    Task<Meal?> GetMealByNameAsync(Expression<Func<Meal, bool>> condition);
    Task<IEnumerable<Meal>> GetMeals();
    Task<IEnumerable<MealResponse?>> GetMealResponseAsync();
    Task<MealResponse?> GetSingleMealResponseAsync(Expression<Func<Meal, bool>> condition);
}