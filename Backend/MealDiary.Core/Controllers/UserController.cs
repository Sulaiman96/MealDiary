using AutoMapper;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.Core.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService, IMapper mapper) : base(mapper)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
    {
        var users = await _userService.GetAllUsersAsync();
        if (!users.Any())
            return NotFound("No Users Found");
        
        var usersToReturn = _mapper.Map<IEnumerable<UserResponse>>(users);
        
        return Ok(usersToReturn);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<UserResponse>> GetUser(string username)
    {
        var user = await _userService.GetUserByUsernameAsync(username);
        if (user == null)
            return NotFound();
        
        var userToReturn = _mapper.Map<UserResponse>(user);
        
        return Ok(userToReturn);
    }
}