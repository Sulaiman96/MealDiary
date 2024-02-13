using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public interface IUserService
{
    public Task<IEnumerable<AppUser?>> GetAllUsersAsync();
    public Task<AppUser?> GetUserByIdAsync(int id);
    public Task<AppUser?> GetUserByUsernameAsync(string username);
    public Task<bool> SaveAllAsync();
}