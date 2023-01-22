using MealDiary.API.DTOModels;
using MealDiary.Services.QueryCommands;
using MealDiary.Services.StoreCommands;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MealController : ControllerBase
{
    private readonly IMealQueryCommand _mealQueryCommand;
    private readonly IMealStoreCommand _mealStoreCommand;

    public MealController(IMealStoreCommand mealStoreCommand, IMealQueryCommand mealQueryCommand)
    {
        _mealQueryCommand = mealQueryCommand;
        _mealStoreCommand = mealStoreCommand;
    }

    [HttpPost]
    public IActionResult CreateMeal(CreateMealRequest request)
    {
        return Ok(request);
    }
    
    [HttpGet("{Id:int}")]
    public IActionResult GetMeal(int Id)
    {
        return Ok(Id);
    }

    [HttpPut("{Id:int}")]
    public IActionResult UpsertMeal(int Id, UpsertMealRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{Id:int}")]
    public IActionResult DeleteMeal(int Id)
    {
        return Ok(Id);
    }
}