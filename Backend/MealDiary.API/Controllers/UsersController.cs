using System.Security.Cryptography;
using System.Text;
using MealDiary.API.Entities;
using MealDiary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = await _userService.GetAllUsers();
        if (!users.Any())
            return NotFound("No Users Found");
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // [HttpPost("register")]
    // public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    // {
    //     // try
    //     // {
    //     //     var registeredUser = await _mealDiaryDatabase.RegisterUser(HashedUser(registerDto));
    //     //     return CreatedAtAction(nameof(Login), registeredUser);
    //     // }
    //     // catch (Exception exception)
    //     // {
    //     //     return BadRequest(exception.Message.Contains("unique_email")
    //     //         ? "Email already exists"
    //     //         : "An error occurred while registering the user");
    //     // }
    //     return Ok();
    // }
    //
    // private static UserDb HashedUser(RegisterDto userDto)
    // {
    //     using var hmac = new HMACSHA512();
    //     var user = new UserDb()
    //     {
    //         Email = userDto.Email.ToLower(),
    //         PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
    //         PasswordSalt = hmac.Key
    //     };
    //     return user;
    // }
}