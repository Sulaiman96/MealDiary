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
        if (await UserExists(registerRequest.UserName, registerRequest.Email))
            return BadRequest("Username Or Email Already Exists");

        var user = _mapper.Map<AppUser>(registerRequest);
        
        var result = await userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        var roleResult = await userManager.AddToRoleAsync(user, "Member");
        
        if (!roleResult.Succeeded)
            return BadRequest(roleResult.Errors);

        var userToReturn = new LoginResponse
        {
            UserName = user.UserName,
            Token = await tokenService.CreateToken(user),
            Email = user.Email
        };

        return Ok(userToReturn);
    }

    private async Task<bool> UserExists(string userName, string email)
    {
        return await userManager.Users.AnyAsync(x => x.UserName == userName || x.Email == email);
    }

    
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
    {
        if (!await UserExists(loginRequest.UserName, loginRequest.Email))
            return Unauthorized("Username & Email Does Not Exist");

        var user = await userManager.Users.FirstOrDefaultAsync(user => user.UserName == loginRequest.UserName 
                                                                       || user.Email == loginRequest.Email);

        if (user == null)
            return Unauthorized("Password Is Wrong");
        
        var userToReturn = new LoginResponse
        {
            UserName = user.UserName,
            Email = user.Email,
            Token = await tokenService.CreateToken(user)
        };
        
        return Ok(userToReturn);
    }
}