using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;

namespace MealDiary.API.Services;

public class IngredientService : BaseService, IIngredientService
{
    public IngredientService(DataContext context) : base(context)
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