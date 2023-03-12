using MealDiary.API.DTOs;
using MealDiary.API.DTOs.Requests;
using MealDiary.API.DTOs.Responses;
using MealDiary.API.Entities;

namespace MealDiary.API.Services;

public interface IUserService
{
    public Task<IEnumerable<User?>> GetAllUsers();
    public Task<User?> GetUser(int id);
    public Task<UserResponse> CreateUser(RegisterRequest registerRequest);
    public Task<UserResponse?> Login(LoginRequest loginRequest);
    public Task<bool> UserExists(string username);
}