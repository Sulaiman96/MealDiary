using System.Security.Cryptography;
using System.Text;
using MealDiary.Core.Data;
using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.Core.Services;

public class AccountService(ApplicationDbContext context) : BaseService(context), IAccountService
{
    public async Task<AppUser> CreateUserAsync(RegisterRequest registerRequest)
    {
        var hashedUser = HashedUser(registerRequest.UserName, registerRequest.Password);
        
        Context.Users.Add(hashedUser);
        await Context.SaveChangesAsync();

        return hashedUser;
    }

    public async Task<AppUser?> Login(LoginRequest loginRequest)
    {
        return new AppUser();
    }

    public async Task<bool> UserExists(string username)
    {
        return await Context.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
    
    private static AppUser HashedUser(string username, string password)
    {
        var user = new AppUser();
        return user;
    }
    
}