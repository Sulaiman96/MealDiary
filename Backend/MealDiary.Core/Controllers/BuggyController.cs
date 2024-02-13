using AutoMapper;
using MealDiary.Core.Data;
using MealDiary.Core.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.Core.Controllers;

public class BuggyController : BaseApiController
{
    private readonly ApplicationDbContext _context;
    
    public BuggyController(ApplicationDbContext context, IMapper mapper) : base(mapper)
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
    public ActionResult<AppUser> GetNotFound()
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