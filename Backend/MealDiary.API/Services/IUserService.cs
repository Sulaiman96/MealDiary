using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;

namespace MealDiary.API.Services;

public interface IUserService
{
    public Task<IEnumerable<User?>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(int id);
    public Task<User?> GetUserByUsernameAsync(string username);
    public Task<bool> SaveAllAsync();
}