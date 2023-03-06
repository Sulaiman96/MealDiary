using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class MealService : BaseService, IMealService
{
    public MealService(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public Task<MealResponse> CreateMeal(MealRequest mealRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMeal(MealRequest mealRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<MealResponse> GetMealById(int id)
    {
        var meal = await _context.Meals.FindAsync(id);
        return _mapper.Map<MealResponse>(meal);
    }

    public async Task<IEnumerable<MealResponse>> GetMeals()
    {
        var meals = await _context.Meals.Select(x => _mapper.Map<MealResponse>(x)).ToListAsync();
        return meals;
    }
}