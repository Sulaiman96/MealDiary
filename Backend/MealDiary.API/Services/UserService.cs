using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MealDiary.API.Data;
using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class UserService : BaseService, IUserService
{
    public UserService(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public async Task<IEnumerable<User?>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUser(RegisterRequest registerRequest)
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
            ? null : user;
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