using MealDiary.API.DTOs;

namespace MealDiary.API.Services;

public interface IIngredientService
{
    public IngredientResponse CreateIngredient(IngredientRequest ingredientRequest);
    public IEnumerable<IngredientResponse> GetIngredients();
    public IngredientResponse GetIngredient(int id);
}