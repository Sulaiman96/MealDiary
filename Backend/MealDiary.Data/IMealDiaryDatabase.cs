using MealDiary.Data.Models;
using MealDiary.Data.Models.DTOs;

namespace MealDiary.Data;

public interface IMealDiaryDatabase
{
    public Task<MealDb> CreateMeal(MealDb meal);
    public Task<bool> UpdateMeal(int id, MealDb meal);
    public Task<MealDb> GetMeal(int id);
    public Task<bool> DeleteMeal(int id);
    public Task<UserDb> GetUser(string user);
    public Task<UserDto> RegisterUser(UserDb user);
}