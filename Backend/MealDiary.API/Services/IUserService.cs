using MealDiary.API.Entities;

namespace MealDiary.API.Services;

public interface IUserService
{
    public Task<IEnumerable<User?>> GetAllUsers();
    public Task<User?> GetUser(int id);
}