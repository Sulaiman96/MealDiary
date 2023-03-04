using MealDiary.Data.Models.DTOs;

namespace MealDiary.API.Services;

public interface IMealService
{
    public MealDto CreateMeal(MealDto mealDto);
    public bool DeleteMeal(MealDto mealDto);
    public MealDto UpdateMeal(MealDto mealDto);
}