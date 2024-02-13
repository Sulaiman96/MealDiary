using MealDiary.Core.Data.Models;

namespace MealDiary.Core.Services;

public interface ITokenService
{
    public string CreateToken(AppUser appUser);
}