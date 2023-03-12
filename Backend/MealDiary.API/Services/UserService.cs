using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class UserService : BaseService, IUserService
{
    private readonly ITokenService _tokenService;
    public UserService(DataContext context, IMapper mapper, ITokenService tokenService) : base(context, mapper)
    {
        _tokenService = tokenService;
    }
    
    public async Task<IEnumerable<User?>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<UserResponse> CreateUser(RegisterRequest registerRequest)
    {
        var hashedUser = HashedUser(registerRequest.UserName, registerRequest.Password);
        
        _context.Users.Add(hashedUser);
        await _context.SaveChangesAsync();
        
        return new UserResponse
        {
            UserName = hashedUser.UserName,
            Token = _tokenService.CreateToken(hashedUser)
        };
    }

    public async Task<UserResponse?> Login(LoginRequest loginRequest)
    {
        var user = await _context.Users.FirstAsync(x => x.UserName == loginRequest.UserName.ToLower());
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));

        return computedHash.Where((t, i) => t != user.PasswordHash[i]).Any() 
            ? null 
            : new UserResponse 
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
    }

    private static User HashedUser(string username, string password)
    {
        using var hmac = new HMACSHA512();
        var user = new User()
        {
            UserName = username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };
        return user;
    }

    public async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
}