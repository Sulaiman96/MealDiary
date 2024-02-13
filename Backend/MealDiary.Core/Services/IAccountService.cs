using MealDiary.Core.Data.DTOs.Requests;
using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public interface IAccountService
{
    public Task<AppUser> CreateUserAsync(RegisterRequest registerRequest);
    public Task<AppUser?> Login(LoginRequest loginRequest);
    public Task<bool> UserExists(string username);
}