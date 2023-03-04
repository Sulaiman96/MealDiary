using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.Services;
using MealDiary.Data.Models;
using MealDiary.Data.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

public class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MealDto))]
    public async Task<IActionResult> CreateMeal(CreateMealDto createMealDto)
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
    
    [HttpGet("{Id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MealDto))]
    public IActionResult GetMeal(int Id)
    {
        return Ok(Id);
    }

    [HttpPut("{Id:int}")]
    public IActionResult UpsertMeal(int Id, UpsertMealDto request)
    {
        return Ok(request);
    }

    [HttpDelete("{Id:int}")]
    public IActionResult DeleteMeal(int Id)
    {
        return Ok(Id);
    }
}