using MealDiary.API.Entities;

namespace MealDiary.API.Services;

public interface ITokenService
{
    public string CreateToken(User user);
}