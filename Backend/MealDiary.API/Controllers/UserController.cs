using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;
using MealDiary.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
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
    
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest)
    {
        if (await _userService.UserExists(registerRequest.UserName))
            return BadRequest("Username Already Exists");
        
        var registeredUser = await _userService.CreateUser(registerRequest);
        return Ok(registeredUser);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
    {
        if (!await _userService.UserExists(loginRequest.UserName))
            return Unauthorized("Username Does Not Exist");

        var user = await _userService.Login(loginRequest);

        if (user == null)
            return Unauthorized("Password Is Wrong");

        return user;
    }
}