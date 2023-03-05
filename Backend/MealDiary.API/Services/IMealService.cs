using MealDiary.API.DTOs;

namespace MealDiary.API.Services;

public interface IMealService
{
    public MealResponse CreateMeal(MealRequest mealRequest);
    public bool DeleteMeal(MealRequest mealRequest);
    public MealResponse GetMealById(int id);
    public IEnumerable<MealResponse> GetMeals();
}