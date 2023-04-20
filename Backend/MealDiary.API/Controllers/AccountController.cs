using AutoMapper;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealDiary.API.Controllers;

public class AccountController: BaseApiController
{
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    
    public AccountController(IMapper mapper, IAccountService accountService, ITokenService tokenService) : base(mapper)
    {
        _accountService = accountService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccountResponse>> Register(RegisterRequest registerRequest)
    {
        if (await _accountService.UserExists(registerRequest.UserName))
            return BadRequest("Username Already Exists");
        
        var registeredUser = await _accountService.CreateUserAsync(registerRequest);

        var userToReturn = new AccountResponse
        {
            UserName = registeredUser.UserName,
            Token = _tokenService.CreateToken(registeredUser)
        };

        return Ok(userToReturn);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AccountResponse>> Login(LoginRequest loginRequest)
    {
        if (!await _accountService.UserExists(loginRequest.UserName))
            return Unauthorized("Username Does Not Exist");

        var user = await _accountService.Login(loginRequest);

        if (user == null)
            return Unauthorized("Password Is Wrong");
        
        var userToReturn = new AccountResponse
        {
            UserName = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
        
        return Ok(userToReturn);
    }
}