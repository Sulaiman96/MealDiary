using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MealDiary.Data;
using MealDiary.Data.Models;
using MealDiary.Data.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MealDiary.API.Controllers;

public class UserController : BaseApiController
{
    public UserController(IMapper mapper, IMealDiaryDatabase mealDiaryDatabase) : base(mapper, mealDiaryDatabase)
    {
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDb>> Login(RegisterDto registerDto)
    {
        var userDb = await _mealDiaryDatabase.GetUser(registerDto.Email);

        if (userDb == default) 
            return Unauthorized("User Not Found");

        using var hmac = new HMACSHA512(userDb.PasswordSalt);

        var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));

        if (computeHash.Where((b, index) => b != userDb.PasswordHash[index]).Any())
            return Unauthorized("Invalid Password");

        return Ok($"Welcome back: {userDb.Email}");
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        try
        {
            var registeredUser = await _mealDiaryDatabase.RegisterUser(HashedUser(registerDto));
            return CreatedAtAction(nameof(Login), registeredUser);
        }
        catch (NpgsqlException exception)
        {
            return BadRequest(exception.Message.Contains("unique_email")
                ? "Email already exists"
                : "An error occurred while registering the user");
        }
    }

    private static UserDb HashedUser(RegisterDto userDto)
    {
        using var hmac = new HMACSHA512();
        var user = new UserDb()
        {
            Email = userDto.Email.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
            PasswordSalt = hmac.Key
        };
        return user;
    }
}