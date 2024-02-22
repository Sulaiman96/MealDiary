using MealDiary.Core.Data;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;

namespace MealDiary.Core.Services;

public class IngredientService : BaseService, IIngredientService
{
    public IngredientService(ApplicationDbContext context) : base(context)
    {
    }
    public IngredientResponse CreateIngredient(IngredientRequest ingredientRequest)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IngredientResponse> GetIngredients()
    {
        throw new NotImplementedException();
    }

    public IngredientResponse GetIngredient(int id)
    {
        throw new NotImplementedException();
    }
}