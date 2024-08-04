using System.Linq.Expressions;
using AutoMapper;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.Core.Controllers;

public class MealController(IMealService mealService, IMapper mapper) : BaseApiController(mapper)
{
    [HttpPost]
    public async Task<IActionResult> CreateMeal(MealRequest mealRequest)
    {
        // var mappedMealDb = _mapper.Map<MealDb>(createMealDto);
        // mappedMealDb.DateAdded = DateTime.UtcNow;
        // var insertedMealDb = await _mealDiaryDatabase.CreateMeal(mappedMealDb);
        // insertedMealDb.UsersId = int.MaxValue;
        //
        // var mappedMealDto = _mapper.Map<MealDto>(insertedMealDb);
        // return CreatedAtAction(nameof(GetMeal),new {id = mappedMealDto.Id} , mappedMealDto);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MealResponse>>> GetMeals()
    {
        var meals = await mealService.GetMealResponseAsync();

        if(!meals.Any())
            return NotFound("No Meals Found");

        var mealsToReturn = _mapper.Map<IEnumerable<MealResponse>>(meals);

        return Ok(mealsToReturn);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MealResponse>> GetMealById(int id)
    {
        var mealResponse = await mealService.GetSingleMealResponseAsync(m => m.Id == id);
        
        if(mealResponse is null)
            return NotFound("No Meal Found");

        return Ok(mealResponse);
    }
    
    [HttpGet("{mealName}")]
    public async Task<ActionResult<MealResponse>> GetMealByName(string mealName)
    {
        var mealResponse = await mealService.GetSingleMealResponseAsync(m => m.Name == mealName);
        
        if(mealResponse is null)
            return NotFound("No Meal Found");

        return Ok(mealResponse);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteMeal(int id)
    {
        return Ok(id);
    }
}