using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;

namespace MealDiary.API.Services;

public interface IIngredientService
{
    public IngredientResponse CreateIngredient(IngredientRequest ingredientRequest);
    public IEnumerable<IngredientResponse> GetIngredients();
    public IngredientResponse GetIngredient(int id);
}