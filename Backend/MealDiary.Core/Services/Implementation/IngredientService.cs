using AutoMapper;
using MealDiary.Core.Data;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;

namespace MealDiary.Core.Services.Implementation;

public class IngredientService(ApplicationDbContext context, IMapper mapper)
    : BaseService(context, mapper), IIngredientService
{
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