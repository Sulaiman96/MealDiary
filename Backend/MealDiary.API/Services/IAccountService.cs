using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;

namespace MealDiary.API.Services;

public interface IAccountService
{
    public Task<User> CreateUserAsync(RegisterRequest registerRequest);
    public Task<User?> Login(LoginRequest loginRequest);
    public Task<bool> UserExists(string username);
}