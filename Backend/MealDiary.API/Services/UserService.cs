using AutoMapper;
using MealDiary.API.Data;
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
}