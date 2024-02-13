using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;

namespace MealDiary.Core.Services;

public interface IIngredientService
{
    public IngredientResponse CreateIngredient(IngredientRequest ingredientRequest);
    public IEnumerable<IngredientResponse> GetIngredients();
    public IngredientResponse GetIngredient(int id);
}