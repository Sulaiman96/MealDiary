using MealDiary.API.Data;
using MealDiary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealDiary.API.Services;

public class UserService : IUserService
{
    private readonly DataContext _context;
    
    public UserService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User?>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}