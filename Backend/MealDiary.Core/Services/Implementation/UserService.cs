using AutoMapper;
using MealDiary.Core.Data;
using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services.Implementation;

public class UserService(ApplicationDbContext context, IMapper mapper) : BaseService(context, mapper), IUserService
{
    public async Task<IEnumerable<AppUser?>> GetAllUsersAsync()
    {
        return null;
    }

    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await Context.Users.FindAsync(id);
        
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return null;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await Context.SaveChangesAsync() > 0;
    }
}