using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

public class MealController : BaseApiController
{
    private readonly IMealService _mealService;
    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MealResponse))]
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
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MealResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetMeal(int id)
    {
        return Ok(id);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteMeal(int id)
    {
        return Ok(id);
    }
}