using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

public class BuggyController : BaseApiController
{
    private readonly DataContext _context;
    
    public BuggyController(DataContext context, IMapper mapper) : base(mapper)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetSecret()
    {
        return "secret text";
    }
    
    [HttpGet("not-found")]
    public ActionResult<User> GetNotFound()
    {
        var thing = _context.Users.Find(-1);
        if (thing == null)
            return NotFound();

        return thing;
    }
    
    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
        var thing = _context.Users.Find(-1);
        var thingToReturn = thing.ToString(); //This will throw an exception, what I want.
        return thingToReturn;
    }
    
    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("This was not a good request");
    }
}