using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;

namespace MealDiary.API.Services;

public interface IMealService
{
    Task<Meal> CreateMealAsync(Meal mealRequest);
    Task<bool> DeleteMealAsync(Meal mealRequest); 
    Task<Meal?> GetMealByIdAsync(int id);
    Task<Meal?> GetMealByNameAsync(string mealName);
    Task<IEnumerable<Meal>> GetMeals();
}