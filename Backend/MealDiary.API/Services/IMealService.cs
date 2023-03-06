using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;

namespace MealDiary.API.Services;

public interface IMealService
{
    public Task<MealResponse> CreateMeal(MealRequest mealRequest);
    public Task<bool> DeleteMeal(MealRequest mealRequest);
    public Task<MealResponse> GetMealById(int id);
    public Task<IEnumerable<MealResponse>> GetMeals();
}