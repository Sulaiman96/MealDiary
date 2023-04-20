using System.Security.Cryptography;
using System.Text;
using MealDiary.API.Data;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class AccountService : BaseService, IAccountService
{
    public AccountService(DataContext context) : base(context)
    {
    }
    
    public async Task<User> CreateUserAsync(RegisterRequest registerRequest)
    {
        var hashedUser = HashedUser(registerRequest.UserName, registerRequest.Password);
        
        _context.Users.Add(hashedUser);
        await _context.SaveChangesAsync();

        return hashedUser;
    }

    public async Task<User?> Login(LoginRequest loginRequest)
    {
        var user = await _context.Users.FirstAsync(x => x.UserName == loginRequest.UserName.ToLower());
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));

        return computedHash.Where((t, i) => t != user.PasswordHash[i]).Any()
            ? null
            : user;
    }

    public async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
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
    
}