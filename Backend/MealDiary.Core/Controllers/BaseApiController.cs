using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMapper _mapper;
    public BaseApiController(IMapper mapper)
    {
        _mapper = mapper;
    }
}