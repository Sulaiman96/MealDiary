using System.Security.Cryptography;
using System.Text;
using MealDiary.API.Data;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class UserService : BaseService, IUserService
{
    public UserService(DataContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<User?>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Meals)
            .Include(u => u.MealCollection)
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
        
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Meals)
            .Include(u => u.MealCollection)
            .SingleOrDefaultAsync(user => user.UserName == username.ToLower());
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}