using AutoMapper;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.DTOs.Responses;
using MealDiary.Core.Data.Models;
using MealDiary.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Controllers;

public class AccountController(
    IMapper mapper,
    ITokenService tokenService,
    UserManager<AppUser> userManager) : BaseApiController(mapper)
{
    [HttpPost("register")]
    public async Task<ActionResult<LoginResponse>> Register(RegisterRequest registerRequest)
    {
        if (await UserExists(registerRequest.Email))
            return BadRequest("Email Already Exists");

        var user = _mapper.Map<AppUser>(registerRequest);
        user.UserName = user.Email;
        
        var result = await userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        var roleResult = await userManager.AddToRoleAsync(user, "Member");
        
        if (!roleResult.Succeeded)
            return BadRequest(roleResult.Errors);

        var userToReturn = new LoginResponse
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Token = await tokenService.CreateToken(user)
        };

        return Ok(userToReturn);
    }

    private async Task<bool> UserExists(string email)
    {
        return await userManager.Users.AnyAsync(x => x.UserName == email);
    }

    
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
    {
        if (!await UserExists(loginRequest.Email))
            return Unauthorized("Email Does Not Exist");

        var user = await userManager.Users.FirstOrDefaultAsync(user => user.UserName == loginRequest.Email);

        if (user == null)
            return Unauthorized("Password Is Wrong");
        
        var userToReturn = new LoginResponse
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Token = await tokenService.CreateToken(user)
        };
        
        return Ok(userToReturn);
    }
}