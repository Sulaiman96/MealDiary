using AutoMapper;
using MealDiary.Data;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly IMealDiaryDatabase _mealDiaryDatabase;
    public BaseApiController(IMapper mapper, IMealDiaryDatabase mealDiaryDatabase)
    {
        _mapper = mapper;
        _mealDiaryDatabase = mealDiaryDatabase;
    }
}