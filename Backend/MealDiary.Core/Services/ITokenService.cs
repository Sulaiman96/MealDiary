using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public interface ITokenService
{
    public Task<string> CreateToken(AppUser appUser);
}