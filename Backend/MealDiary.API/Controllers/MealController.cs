using AutoMapper;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;
using MealDiary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

public class MealController : BaseApiController
{
    private readonly IMealService _mealService;
    public MealController(IMealService mealService, IMapper mapper) : base(mapper)
    {
        _mealService = mealService;
    }

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
        var meals = await _mealService.GetMeals();

        if(!meals.Any())
            return NotFound("No Meals Found");

        var mealsToReturn = _mapper.Map<IEnumerable<MealResponse>>(meals);

        return Ok(mealsToReturn);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MealResponse>> GetMealById(int id)
    {
        var meal = await _mealService.GetMealByIdAsync(id);
        
        if(meal is null)
            return NotFound("No Meal Found");

        var mealToReturn = _mapper.Map<MealResponse>(meal);

        return Ok(mealToReturn);
    }
    
    [HttpGet("{mealName}")]
    public async Task<ActionResult<MealResponse>> GetMealByName(string mealName)
    {
        var meal = await _mealService.GetMealByNameAsync(mealName);
        
        if(meal is null)
            return NotFound("No Meal Found");

        var mealToReturn = _mapper.Map<MealResponse>(meal);

        return Ok(mealToReturn);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteMeal(int id)
    {
        return Ok(id);
    }
}